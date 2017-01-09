using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using OneRosterMatchingTool.Objects;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using OneRosterOAuth;

namespace OneRosterMatchingTool
{
    public partial class OneRosterDebugTool : Form
    {
        public OneRosterDebugTool()
        {
            InitializeComponent();
            // set up connection test background workers
            adTestWorker.DoWork += adTestWorker_DoWork;
            adTestWorker.RunWorkerCompleted += adTestWorker_Complete;
            orTestWorker.DoWork += orTestWorker_DoWork;
            orTestWorker.RunWorkerCompleted += orTestWorker_Complete;

            // set default labels
            statusLabel.Text = string.Empty;
            totalUsers_label.Text = string.Empty;
            storedUsers_label.Text = string.Empty;

            // get all domains in forest
            _domainList = getAllDomain();

            // filter by active and only take needed fields
            _options = "&filter=status%3D%27active%27&fields=username%2CsourcedId%2CgivenName%2CfamilyName%2Crole%2Cemail";

            // initialize placeholder
            oneUrl.Text = OneUrlPlaceholder;

            // load user settings
            loadSettings();
        }

        private readonly string _options;
        private readonly List<string> _domainList;
        private OneRosterConnection _oneRoster;
        private List<OneUser> _missingList;
        private List<OneUser> _foundList;
        private List<OneUser> _oneRosterList;
        private List<BackgroundWorker> _bgList;
        private const int NumWorker = 10;
        private Mutex _missingMutex;
        private Mutex _foundMutex;
        private const string OneUrlPlaceholder = "https://example.oneroster.com/learningdata/v1";

        /// <summary>
        /// Runs when "Start" is pressed
        /// gets all users from oneroster and 
        /// splits list into 10 parts to 
        /// send to the worker helpers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _oneRosterList = getOneRosterUsers();
            if (_oneRosterList == null) return;
            _bgList = new List<BackgroundWorker>();
            var q = 0;
            var splitList = from item in _oneRosterList
                            group item by q++ % NumWorker
                            into part
                            select part.AsEnumerable();
            foreach (var list in splitList)
            {
                var newWorker = new WorkerHelper();
                newWorker.DoWork += bgList_DoWork;
                newWorker.RunWorkerCompleted += bgList_Complete;
                newWorker.oneUserList = list.ToList();
                _bgList.Add(newWorker);
            }
        }

        /// <summary>
        /// start worker helpers on original worker completion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            startWorkers();
        }

        /// <summary>
        /// creates mutex and fires off workers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(oneKey.Text) || 
                string.IsNullOrEmpty(oneSecret.Text) ||
                string.IsNullOrEmpty(oneUrl.Text) || 
                string.IsNullOrEmpty(adUser.Text) ||
                string.IsNullOrEmpty(adPassword.Text) || 
                string.IsNullOrEmpty(adDomain.Text))
            {
                MessageBox.Show(@"Please enter all fields.");
                return;
            }

            // start oneRosterConnection
            _oneRoster = new OneRosterConnection(oneKey.Text, oneSecret.Text);

            // reset list
            _missingList = new List<OneUser>();
            _foundList = new List<OneUser>();
            _missingMutex = new Mutex();
            _foundMutex = new Mutex();
            // start worker 
            statusProgressBar.Value = 0;
            storedUsers_label.Text = @"0";
            totalUsers_label.Text = @"0";
            startBtn.Enabled = false;

            var worker1 = new BackgroundWorker();
            worker1.DoWork += worker_DoWork;
            worker1.RunWorkerCompleted += worker_Complete;
            worker1.RunWorkerAsync();
        }

        /// <summary>
        /// Gets oneroster users
        /// </summary>
        /// <returns></returns>
        private List<OneUser> getOneRosterUsers()
        {
            try
            {
                // get total count before getting all users
                var uri = $"{oneUrl.Text.TrimEnd('/')}/users?limit=1&filter=status%3D%27active%27";
                var getTask = _oneRoster.makeRequest(uri);
                Task.WaitAll(getTask);
                HttpResponseMessage response = getTask.Result;
                int totalNumUsers;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    int.TryParse(response.Headers.GetValues("X-Total-Count")?.FirstOrDefault(), result: out totalNumUsers);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
                
                // update form with number of users
                Invoke(new Action(() =>
                {
                    statusLabel.Text = $@"Found {totalNumUsers}";

                    // set progressbar max to (grabbing users)+(searching users)
                    statusProgressBar.Maximum = totalNumUsers * 2;
                    statusProgressBar.Step = 1;
                    totalUsers_label.Text = totalNumUsers.ToString();
                }));


                var userList = new List<OneUser>();
                // only grab 1000 users per api call
                var limit = 1000;
                if (totalNumUsers < limit) limit = totalNumUsers;
                var currentOffset = 0;
                while (limit + currentOffset <= totalNumUsers && limit != 0)
                {
                    var limit1 = limit;
                    Invoke(new Action(() =>
                    {
                        statusLabel.Text = $@"Grabbing next {limit1} users from OneRoster";
                    }));
                    // create next url
                    uri = $"{oneUrl.Text.TrimEnd('/')}/users?limit={limit}&offset={currentOffset}&{_options}";
                    getTask = _oneRoster.makeRequest(uri);
                    Task.WaitAll(getTask);
                    response = getTask.Result;

                    // get result string
                    var readResult = response.Content.ReadAsStringAsync();
                    Task.WaitAll(readResult);
                    var returnString = readResult.Result;
                    var tempList = JsonConvert.DeserializeObject<OneRoster>(returnString);
                    foreach (OneUser usr in tempList.user)
                    {
                        userList.Add(usr);
                        Invoke(new Action(() =>
                        {
                            statusProgressBar.PerformStep();
                            storedUsers_label.Text = (int.Parse(storedUsers_label.Text) + 1).ToString();
                        }));
                    }
                    currentOffset += limit;
                    if (limit + currentOffset > totalNumUsers)
                    {
                        limit = totalNumUsers - currentOffset;
                    }
                }
                return userList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"OneRoster Get Error");
            }
            return null;
        }

        /// <summary>
        /// Searches AD for user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        private bool findUser(string username, string domain)
        {
            try
            {
                using (var ctx = new PrincipalContext(ContextType.Domain, adDomain.Text, domain,
                        adUser.Text, adPassword.Text))
                using (UserPrincipal userHandle = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, username))
                {
                    return userHandle != null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"FindUser error");
                return false;
            }
        }

        /// <summary>
        /// Gets all domains in forest
        /// </summary>
        /// <returns></returns>
        private static List<string> getAllDomain()
        {
            try
            {
                using (Forest forest = Forest.GetCurrentForest())
                {
                    return (from Domain d in forest.Domains select d.Name)
                        .Select(domain => domain.Replace(".", ",dc="))
                        .Select(tdomain => "dc=" + tdomain).ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Could not locate the active directory server: 
"+e.Message);
                Environment.Exit(-1);
            }
            return null;
        }

        /// <summary>
        /// Tests connection to Active Directory for each domain in the forest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testAD_Click(object sender, EventArgs e)
        {
            testAD.Enabled = false;
            adTestWorker.RunWorkerAsync();
        }

        /// <summary>
        /// worker to do actual test to free up form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adTestWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(adUser.Text) ||
                 string.IsNullOrEmpty(adPassword.Text) ||
                 string.IsNullOrEmpty(adDomain.Text))
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show(@"Please enter all AD Credentials");
                }));
                
                return;
            }
            var domainList = getAllDomain();
            foreach (var domain in domainList)
            {
                try
                {
                    using (var ctx = new PrincipalContext(
                        ContextType.Domain,
                        adDomain.Text,
                        domain))
                    {
                        if (!ctx.ValidateCredentials(adUser.Text, adPassword.Text))
                        {
                            MessageBox.Show(
                                $@"Could not connect to Active Directory on Domain: {domain} using username: {adUser
                                    .Text}");
                            return;
                        }

                    }
                    MessageBox.Show(@"Active Directory Connection Established");
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }

            }
        }

        /// <summary>
        /// re-enable button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adTestWorker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            testAD.Enabled = true;
        }

        /// <summary>
        /// Test OneRoster credentials using OAuth v1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orTestWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(oneUrl.Text) ||
                 string.IsNullOrEmpty(oneKey.Text) ||
                 string.IsNullOrEmpty(oneSecret.Text))
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show(@"Please enter all OneRoster Credentials");
                }));

                return;
            }
            try
            {
                var uri = $"{oneUrl.Text.TrimEnd('/')}/users?limit=1";
                var getTask = _oneRoster.makeRequest(uri);
                Task.WaitAll(getTask);
                HttpResponseMessage response = getTask.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    MessageBox.Show(@"OneRoster Connection Established");
                else
                {
                    throw new Exception(response.StatusCode.ToString(), null);
                }
            }
            catch(Exception a)
            {
                MessageBox.Show($@"OneRoster Test: {a.Message}");
            }
        }

        /// <summary>
        /// re-enable button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orTestWorker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            testOR.Enabled = true;
        }

        /// <summary>
        /// fire off OneRoster worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testOR_Click(object sender, EventArgs e)
        {
            // set params in oauth
            _oneRoster = new OneRosterConnection(oneKey.Text, oneSecret.Text);
            testOR.Enabled = false;
            orTestWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Generate CSV from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string createCsvTextFile<T>(IEnumerable<T> data)
        {
            var properties = typeof(T).GetProperties();
            var result = new StringBuilder();
            result.AppendLine(string.Join(",", new List<string>
            {
                "username",
                "sourcedId",
                "givenName",
                "familyName",
                "role",
                "email"
            }));
            if (data == null) return result.ToString();
            foreach (T row in data)
            {
                var values = properties.Select(p => p.GetValue(row, null))
                                       .Select(v => stringToCsvCell(Convert.ToString(v)));
                var line = string.Join(",", values);
                result.AppendLine(line);
            }

            return result.ToString();
        }

        /// <summary>
        /// force string to play nice with cells
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string stringToCsvCell(string str)
        {
            var mustQuote = (str.Contains(",") || str.Contains("\"") || str.Contains("\r") || str.Contains("\n"));
            if (!mustQuote) return str;
            var sb = new StringBuilder();
            sb.Append("\"");
            foreach (var nextChar in str)
            {
                sb.Append(nextChar);
                if (nextChar == '"')
                    sb.Append("\"");
            }
            sb.Append("\"");
            return sb.ToString();
        }

        /// <summary>
        /// create CSV file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createCSV_Click(object sender, EventArgs e)
        {
            createCSV.Enabled = false;
            var fileName = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")+".csv";
            _missingMutex.WaitOne();
            var csvText = createCsvTextFile(_missingList);
            _missingMutex.ReleaseMutex();
            TextWriter tw = new StreamWriter(fileName, true);
            tw.Write(csvText, true);
            tw.Close();
            MessageBox.Show($@"File saved as {fileName}");
            createCSV.Enabled = true;
        }

        // Open table of missing users in popup
        private void viewTable_Click(object sender, EventArgs e)
        {
            var popup = new missingTable(_missingList);
            popup.ShowDialog();
            popup.Dispose();
        }

        // bgWorkerList
        private void bgList_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgWorker = (WorkerHelper) sender;
            bgWorker.missingUsers = new List<OneUser>();
            bgWorker.foundUsers = new List<OneUser>();
            
            if (bgWorker.oneUserList== null) return;
            foreach (OneUser user in bgWorker.oneUserList)
            {
                Invoke(new Action(() =>
                {
                    statusLabel.Text = $@"Searching for {user.username}...";
                }));

                if (!_domainList.Any(d => findUser(user.username, d)))
                {
                    bgWorker.missingUsers.Add(user);
                    _missingMutex.WaitOne();
                    _missingList.Add(user);
                    _missingMutex.ReleaseMutex();
                }
                else
                {
                    bgWorker.foundUsers.Add(user);
                    _foundMutex.WaitOne();
                    _foundList.Add(user);
                    _foundMutex.ReleaseMutex();
                }
                Invoke(new Action(() =>
                {
                    missingLabel.Text = _missingList.Count.ToString();
                    foundUsers.Text = _foundList.Count.ToString();
                    statusProgressBar.PerformStep();
                }));
            }
        }

        private void bgList_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            var worker = (WorkerHelper) sender;
            _bgList.Remove(worker);
            worker.Dispose();
            if (_bgList.Count != 0) return;
            Invoke(new Action(() =>
            {
                statusLabel.Text = @"Search complete.";
            }));
            Invoke(new Action(() =>
            {
                startBtn.Enabled = true;
            }));
        }

        private void startWorkers()
        {
            foreach(BackgroundWorker bgWorker in _bgList)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        // placeholder text for oneUrl
        private void oneUrl_Enter(object sender, EventArgs e)
        {
            if (oneUrl.Text == OneUrlPlaceholder)
            {
                oneUrl.Text = string.Empty;
            }
        }

        private void oneUrl_Leave(object sender, EventArgs e)
        {
            if (oneUrl.Text == string.Empty)
            {
                oneUrl.Text = OneUrlPlaceholder;
            }
        }

        private void saveSettings_Click(object sender, EventArgs e)
        {
            saveSettings.Enabled = false;
            // Check if any settings are filled in
            // if set, warn for overwrite
            if (!string.IsNullOrEmpty(Properties.Settings.Default["oneUrl"].ToString()) ||
                !string.IsNullOrEmpty(Properties.Settings.Default["oneKey"].ToString()) ||
                !string.IsNullOrEmpty(Properties.Settings.Default["oneSecret"].ToString()) ||
                !string.IsNullOrEmpty(Properties.Settings.Default["adUser"].ToString()) ||
                !string.IsNullOrEmpty(Properties.Settings.Default["adPass"].ToString()) ||
                !string.IsNullOrEmpty(Properties.Settings.Default["adDomain"].ToString()))
            {
                DialogResult response = MessageBox.Show(@"Some settings are already set
Overwrite?", @"Save Settings",
                    MessageBoxButtons.YesNo);
                if (response == DialogResult.Yes)
                {
                    MessageBox.Show(updateSettings() ? @"Settings updated" : @"An error occured while saving settings");
                }
                else
                {
                    MessageBox.Show(@"Settings not updated");
                }
            }
            else
            {
                MessageBox.Show(updateSettings() ? @"Settings saved" : @"An error occured while saving settings");
            }
            saveSettings.Enabled = true;
        }

        private bool updateSettings()
        {
            try
            {
                Properties.Settings.Default["oneUrl"] = oneUrl.Text;
                Properties.Settings.Default["oneKey"] = oneKey.Text;
                Properties.Settings.Default["oneSecret"] = oneSecret.Text;
                Properties.Settings.Default["adUser"] = adUser.Text;
                Properties.Settings.Default["adPass"] = adPassword.Text;
                Properties.Settings.Default["adDomain"] = adDomain.Text;
                Properties.Settings.Default.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool loadSettings()
        {
            try
            {
                oneUrl.Text = Properties.Settings.Default.oneUrl;
                oneKey.Text = Properties.Settings.Default.oneKey;
                oneSecret.Text = Properties.Settings.Default.oneSecret;
                adUser.Text = Properties.Settings.Default.adUser;
                adPassword.Text = Properties.Settings.Default.adPass;
                adDomain.Text = Properties.Settings.Default.adDomain;
                Properties.Settings.Default.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
