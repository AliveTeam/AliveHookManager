using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AliveHookManager
{
    public partial class ManagerV2 : Form
    {
        public ManagerV2()
        {
            InitializeComponent();
        }

        class AbeFunction
        {
            public LinkerMapParser.LinkerMapFunction LinkerFunc { get; set; }
            public bool Disabled { get; set; }
        }

        List<AbeFunction> mAbeFuncs = new List<AbeFunction>();

        const string sHookMapFile = "hook_map.txt";

        void LoadDisabledFunctions()
        {
            if (File.Exists(sHookMapFile))
            {
                string[] existingFuncs = File.ReadAllLines("hook_map.txt");

                for (int i = 0; i < mAbeFuncs.Count; i++)
                {
                    if (existingFuncs.Contains(mAbeFuncs[i].LinkerFunc.Address.ToString("X")))
                    {
                        mAbeFuncs[i].Disabled = true;
                    }
                }
            }
        }

        void SaveDisabledFunctions()
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (var f in mAbeFuncs.Where(x=>x.Disabled))
            {
                strBuilder.AppendLine(f.LinkerFunc.Address.ToString("X"));
            }

            try
            {
                File.WriteAllText(sHookMapFile, strBuilder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to save hook map.\n\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LaunchGame(string args)
        {
            Process p;

            if (File.Exists("Exoddus_AliveDllAE.exe"))
            {
                p = Process.Start("Exoddus_AliveDllAE.exe", args);
            }

            else if (File.Exists("AbeWin_AliveDllAO.exe"))
            {
                p = Process.Start("AbeWin_AliveDllAO.exe", args);
            }

            else
            {
                MessageBox.Show($"Exoddus_AliveDllAE.exe nor AbeWin_AliveDllAO.exe was found. Make sure to put this app into the game directory.", $"No executable found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hide();
            p.WaitForExit();
            Show();
        }

        bool LoadLinkerMap(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            LinkerMapParser parser = new LinkerMapParser();
            parser.Parse(File.ReadAllText(fileName));

            mAbeFuncs.Clear();

            foreach (var f in parser.Functions)
            {
                mAbeFuncs.Add(new AbeFunction() { LinkerFunc = f, Disabled = false });
            }
            return true;
        }

        void LoadLinkerData()
        {
            if (!LoadLinkerMap("AliveDllAO.map"))
            {
                if (!LoadLinkerMap("AliveDllAE.map"))
                {
                    MessageBox.Show($"AliveDllAO.map nor AliveDllAE.map was found. Make sure to put this app into the game directory.", $"No linker maps found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

        }

        private void ManagerV2_Load(object sender, EventArgs e)
        {
            LoadLinkerData();
            LoadDisabledFunctions();

            UpdateList();
        }

        void UpdateList()
        {
            listViewFunctions.BeginUpdate();

            List<AbeFunction> funcList = mAbeFuncs;

            string searchText = toolStripTextBoxSearch.Text;

            if (searchText != null && searchText != "")
            {
                searchText = searchText.ToLower();
                funcList = funcList.Where(x => x.LinkerFunc.Name.ToLower().Contains(searchText) || x.LinkerFunc.Object.ToLower().Contains(searchText)).ToList();
            }

            listViewFunctions.Items.Clear();

            foreach (var f in funcList)
            {
                ListViewItem item = new ListViewItem(f.LinkerFunc.Name);

                item.Tag = f;
                item.Checked = f.Disabled;
                item.SubItems.Add(f.LinkerFunc.Address.ToString("X"));
                item.SubItems.Add(f.LinkerFunc.Object);

                listViewFunctions.Items.Add(item);
            }

            listViewFunctions.EndUpdate();
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void listViewFunctions_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listViewFunctions.SelectedItems.Count == 1)
                {
                    // Single Selected item context menu
                    contextMenuStripListSingle.Show(listViewFunctions, e.Location);
                }
                else if (listViewFunctions.SelectedItems.Count > 1)
                {
                    // Disable multiple items etc...
                    contextMenuStripListMulti.Show(listViewFunctions, e.Location);
                }
            }
        }

        AbeFunction GetSelectedFunction()
        {
            if (listViewFunctions.SelectedItems.Count > 0)
            {
                return (AbeFunction)listViewFunctions.SelectedItems[0].Tag;
            }
            else
            {
                return null;
            }
        }

        AbeFunction[] GetSelectedFunctionList()
        {
            List<AbeFunction> funcs = new List<AbeFunction>();

            foreach(ListViewItem i in listViewFunctions.SelectedItems)
            {
                funcs.Add((AbeFunction)i.Tag);
            }

            return funcs.ToArray();
        }

        private void enableGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string group = GetSelectedFunction().LinkerFunc.Object;

            foreach(ListViewItem item in listViewFunctions.Items)
            {
                AbeFunction abeFunc = (AbeFunction)item.Tag;
                
                if (abeFunc.LinkerFunc.Object == group)
                {
                    abeFunc.Disabled = false;
                    item.Checked = false;
                }
            }

            foreach (var func in mAbeFuncs.Where(x => x.LinkerFunc.Object == group))
            {
                func.Disabled = false;
            }
        }

        private void disableGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string group = GetSelectedFunction().LinkerFunc.Object;

            foreach (ListViewItem item in listViewFunctions.Items)
            {
                AbeFunction abeFunc = (AbeFunction)item.Tag;

                if (abeFunc.LinkerFunc.Object == group)
                {
                    abeFunc.Disabled = true;
                    item.Checked = true;
                }
            }

            foreach(var func in mAbeFuncs.Where(x=>x.LinkerFunc.Object == group))
            {
                func.Disabled = true;
            }
        }

        private void enableSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFunctions.SelectedItems)
            {
                AbeFunction abeFunc = (AbeFunction)item.Tag;

                abeFunc.Disabled = false;
                item.Checked = false;
            }
        }

        private void disableSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFunctions.SelectedItems)
            {
                AbeFunction abeFunc = (AbeFunction)item.Tag;

                abeFunc.Disabled = true;
                item.Checked = true;
            }
        }

        void UpdateStatusText()
        {
            toolStripStatusLabelFuncs.Text = string.Format("{0} / {1} functions disabled", mAbeFuncs.Where(x => x.Disabled).Count(), mAbeFuncs.Count);
        }

        private void listViewFunctions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ((AbeFunction)e.Item.Tag).Disabled = e.Item.Checked;

            UpdateStatusText();
        }

        private void listViewFunctions_Validated(object sender, EventArgs e)
        {
            UpdateStatusText();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveDisabledFunctions();
        }

        private void toolStripButtonSaveLaunch_Click(object sender, EventArgs e)
        {
            SaveDisabledFunctions();
            LaunchGame("");
        }

        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                toolStripButtonSearch_Click(this, null);
            }
        }

        private void toolStripButtonSaveLaunchDebug_Click(object sender, EventArgs e)
        {
            SaveDisabledFunctions();
            LaunchGame("-debug");
        }

        private void fixedFloatUtilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FixedFloatHelper helper = new FixedFloatHelper();
            helper.Show();
        }

        private void toolStripButton_clear_funcs_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFunctions.Items)
            {
                AbeFunction abeFunc = (AbeFunction)item.Tag;

                abeFunc.Disabled = true;
                item.Checked = true;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GetSelectedFunction().LinkerFunc.Name);
        }

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copy = "";

            foreach (ListViewItem item in listViewFunctions.SelectedItems)
            {
                AbeFunction abeFunc = (AbeFunction)item.Tag;

                abeFunc.Disabled = false;
                item.Checked = false;

                copy += abeFunc.LinkerFunc.Name + "\n";
            }

            Clipboard.SetText(copy);
        }

        private void toolStripButton_enableall_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFunctions.Items)
            {
                AbeFunction abeFunc = (AbeFunction)item.Tag;

                abeFunc.Disabled = false;
                item.Checked = false;
            }
        }
    }
}
