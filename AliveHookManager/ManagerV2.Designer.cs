namespace AliveHookManager
{
    partial class ManagerV2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerV2));
            this.listViewFunctions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxSearch = new AliveHookManager.ToolStripTextBoxNew();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSaveLaunch = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStripListSingle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripListMulti = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFuncs = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButtonSaveLaunchDebug = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStripListSingle.SuspendLayout();
            this.contextMenuStripListMulti.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFunctions
            // 
            this.listViewFunctions.CheckBoxes = true;
            this.listViewFunctions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFunctions.Location = new System.Drawing.Point(0, 25);
            this.listViewFunctions.Name = "listViewFunctions";
            this.listViewFunctions.Size = new System.Drawing.Size(800, 403);
            this.listViewFunctions.TabIndex = 0;
            this.listViewFunctions.UseCompatibleStateImageBehavior = false;
            this.listViewFunctions.View = System.Windows.Forms.View.Details;
            this.listViewFunctions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewFunctions_ItemChecked);
            this.listViewFunctions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewFunctions_MouseClick);
            this.listViewFunctions.Validated += new System.EventHandler(this.listViewFunctions_Validated);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Function";
            this.columnHeader1.Width = 311;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Address";
            this.columnHeader2.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Group";
            this.columnHeader3.Width = 340;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripTextBoxSearch,
            this.toolStripButtonSearch,
            this.toolStripSeparator2,
            this.toolStripButtonSave,
            this.toolStripSeparator3,
            this.toolStripButtonSaveLaunch,
            this.toolStripSeparator4,
            this.toolStripButtonSaveLaunchDebug});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.ForeColor = System.Drawing.Color.Gray;
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Placeholder = "Search...";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(200, 25);
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(46, 22);
            this.toolStripButtonSearch.Text = "Search";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSaveLaunch
            // 
            this.toolStripButtonSaveLaunch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSaveLaunch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveLaunch.Image")));
            this.toolStripButtonSaveLaunch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveLaunch.Name = "toolStripButtonSaveLaunch";
            this.toolStripButtonSaveLaunch.Size = new System.Drawing.Size(88, 22);
            this.toolStripButtonSaveLaunch.Text = "Save + Launch";
            this.toolStripButtonSaveLaunch.Click += new System.EventHandler(this.toolStripButtonSaveLaunch_Click);
            // 
            // contextMenuStripListSingle
            // 
            this.contextMenuStripListSingle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableGroupToolStripMenuItem,
            this.disableGroupToolStripMenuItem});
            this.contextMenuStripListSingle.Name = "contextMenuStripListSingle";
            this.contextMenuStripListSingle.Size = new System.Drawing.Size(149, 48);
            // 
            // enableGroupToolStripMenuItem
            // 
            this.enableGroupToolStripMenuItem.Name = "enableGroupToolStripMenuItem";
            this.enableGroupToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.enableGroupToolStripMenuItem.Text = "Enable Group";
            this.enableGroupToolStripMenuItem.Click += new System.EventHandler(this.enableGroupToolStripMenuItem_Click);
            // 
            // disableGroupToolStripMenuItem
            // 
            this.disableGroupToolStripMenuItem.Name = "disableGroupToolStripMenuItem";
            this.disableGroupToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.disableGroupToolStripMenuItem.Text = "Disable Group";
            this.disableGroupToolStripMenuItem.Click += new System.EventHandler(this.disableGroupToolStripMenuItem_Click);
            // 
            // contextMenuStripListMulti
            // 
            this.contextMenuStripListMulti.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableSelectedToolStripMenuItem,
            this.disableSelectedToolStripMenuItem});
            this.contextMenuStripListMulti.Name = "contextMenuStripListMulti";
            this.contextMenuStripListMulti.Size = new System.Drawing.Size(160, 48);
            // 
            // enableSelectedToolStripMenuItem
            // 
            this.enableSelectedToolStripMenuItem.Name = "enableSelectedToolStripMenuItem";
            this.enableSelectedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.enableSelectedToolStripMenuItem.Text = "Enable Selected";
            this.enableSelectedToolStripMenuItem.Click += new System.EventHandler(this.enableSelectedToolStripMenuItem_Click);
            // 
            // disableSelectedToolStripMenuItem
            // 
            this.disableSelectedToolStripMenuItem.Name = "disableSelectedToolStripMenuItem";
            this.disableSelectedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.disableSelectedToolStripMenuItem.Text = "Disable Selected";
            this.disableSelectedToolStripMenuItem.Click += new System.EventHandler(this.disableSelectedToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFuncs});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelFuncs
            // 
            this.toolStripStatusLabelFuncs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelFuncs.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelFuncs.Name = "toolStripStatusLabelFuncs";
            this.toolStripStatusLabelFuncs.Size = new System.Drawing.Size(119, 17);
            this.toolStripStatusLabelFuncs.Text = "toolStripStatusLabel1";
            // 
            // toolStripButtonSaveLaunchDebug
            // 
            this.toolStripButtonSaveLaunchDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSaveLaunchDebug.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveLaunchDebug.Image")));
            this.toolStripButtonSaveLaunchDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveLaunchDebug.Name = "toolStripButtonSaveLaunchDebug";
            this.toolStripButtonSaveLaunchDebug.Size = new System.Drawing.Size(145, 22);
            this.toolStripButtonSaveLaunchDebug.Text = "Save + Launch + Console";
            this.toolStripButtonSaveLaunchDebug.Click += new System.EventHandler(this.toolStripButtonSaveLaunchDebug_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ManagerV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewFunctions);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManagerV2";
            this.Text = "Alive Hook Manager";
            this.Load += new System.EventHandler(this.ManagerV2_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStripListSingle.ResumeLayout(false);
            this.contextMenuStripListMulti.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewFunctions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ToolStripTextBoxNew toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveLaunch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListSingle;
        private System.Windows.Forms.ToolStripMenuItem disableGroupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListMulti;
        private System.Windows.Forms.ToolStripMenuItem disableSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableSelectedToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFuncs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveLaunchDebug;
    }
}