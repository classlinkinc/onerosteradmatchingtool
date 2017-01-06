using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneRosterMatchingTool.Objects;

namespace OneRosterMatchingTool
{
    public partial class missingTable : Form
    {
        public missingTable(List<OneUser> userList)
        {
            InitializeComponent();
            missingUserGrid.DataSource = userList;
            missingUserGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            missingUserGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            missingUserGrid.AllowUserToOrderColumns = true;
            missingUserGrid.AllowUserToResizeColumns = true;
        }

        private void missingUserGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
