namespace OneRosterMatchingTool
{
    partial class missingTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(missingTable));
            this.missingUserGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.missingUserGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // missingUserGrid
            // 
            this.missingUserGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.missingUserGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.missingUserGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.missingUserGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.missingUserGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.missingUserGrid.Location = new System.Drawing.Point(0, 0);
            this.missingUserGrid.Name = "missingUserGrid";
            this.missingUserGrid.RowHeadersVisible = false;
            this.missingUserGrid.Size = new System.Drawing.Size(1036, 770);
            this.missingUserGrid.TabIndex = 29;
            this.missingUserGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.missingUserGrid_CellContentClick);
            // 
            // missingTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 770);
            this.Controls.Add(this.missingUserGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "missingTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Missing Users";
            ((System.ComponentModel.ISupportInitialize)(this.missingUserGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView missingUserGrid;
    }
}