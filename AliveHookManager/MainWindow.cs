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

namespace AliveHookManager
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        LinkerMapParser mParser = new LinkerMapParser();
        bool ignoreGroupChange = false;

        void SuspendLists()
        {
            listBoxFunctions.SuspendLayout();
            listBoxGroups.SuspendLayout();
        }

        void ResumeLists()
        {
            listBoxFunctions.ResumeLayout();
            listBoxGroups.ResumeLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLists();

            if (!File.Exists("AliveDll.map"))
            {
                MessageBox.Show("AliveDll.map not found. Make sure to put this app into the game directory.", "AliveDll.map not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            mParser.Parse(File.ReadAllText("AliveDll.map"));

            foreach(var f in mParser.Functions)
            {
                listBoxFunctions.Items.Add(f);
            }

            foreach (var f in mParser.Functions)
            {
                if (!listBoxGroups.Items.Contains(f.Object))
                    listBoxGroups.Items.Add(f.Object);
            }

            if (File.Exists("hook_map.txt"))
            {
                string[] existingFuncs = File.ReadAllLines("hook_map.txt");

                for (int i = 0; i < listBoxFunctions.Items.Count; i++)
                {
                    var func = ((LinkerMapParser.LinkerMapFunction)listBoxFunctions.Items[i]);
                    if (existingFuncs.Contains(func.Address.ToString("X")))
                        listBoxFunctions.SetSelected(i, true);
                }
            }

            ResumeLists();

            UpdateStatsLabel();
        }

        List<int> previousSelectedGroupInds = new List<int>();

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SuspendLists();

            if (!ignoreGroupChange)
            {
                List<int> removedInds = new List<int>();
                foreach(var i in previousSelectedGroupInds)
                {
                    if (!listBoxGroups.SelectedIndices.Contains(i))
                        removedInds.Add(i);
                }
                List<int> newInds = new List<int>();
                foreach (var i in listBoxGroups.SelectedIndices)
                    newInds.Add((int)i);
                foreach (var i in previousSelectedGroupInds)
                    newInds.Remove(i);

                newInds.AddRange(removedInds.ToArray());
                
                foreach(var i in newInds)
                {
                    bool selected = listBoxGroups.GetSelected(i);
                    string groupName = (string)listBoxGroups.Items[i];

                    for (int x = 0; x < listBoxFunctions.Items.Count; x++)
                    {
                        LinkerMapParser.LinkerMapFunction func = (LinkerMapParser.LinkerMapFunction)listBoxFunctions.Items[x];

                        if (func.Object == groupName)
                            listBoxFunctions.SetSelected(x, selected);
                    }
                    
                }
            }

            previousSelectedGroupInds.Clear();
            foreach (var i in listBoxGroups.SelectedIndices)
                previousSelectedGroupInds.Add((int)i);

            UpdateStatsLabel();

            ResumeLists();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SuspendLists();

            ignoreGroupChange = true;
            for (int i = 0; i < listBoxGroups.Items.Count; i++)
                listBoxGroups.SetSelected(i, true);
            ignoreGroupChange = false;
            for (int i = 0; i < listBoxFunctions.Items.Count; i++)
                listBoxFunctions.SetSelected(i, true);

            ResumeLists();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach(var f in listBoxFunctions.SelectedItems)
            {
                LinkerMapParser.LinkerMapFunction func = (LinkerMapParser.LinkerMapFunction)f;
                strBuilder.AppendLine(func.Address.ToString("X"));
            }

            try
            {
                File.WriteAllText("hook_map.txt", strBuilder.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured while trying to save hook map.\n\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuspendLists();

            ignoreGroupChange = true;
            for (int i = 0; i < listBoxGroups.Items.Count; i++)
                listBoxGroups.SetSelected(i, false);
            ignoreGroupChange = false;
            for (int i = 0; i < listBoxFunctions.Items.Count; i++)
                listBoxFunctions.SetSelected(i, false);

            ResumeLists();
        }

        void UpdateSelectedGroups()
        {
            SuspendLists();

            for (int i = 0; i < listBoxGroups.Items.Count; i++)
            {
                string groupName = (string)listBoxGroups.Items[i];

                bool foundFunc = false;

                foreach(var f in listBoxFunctions.SelectedItems)
                {
                    LinkerMapParser.LinkerMapFunction func = (LinkerMapParser.LinkerMapFunction)f;

                    if (func.Object == groupName)
                    {
                        foundFunc = true;
                        break;
                    }
                }

                ignoreGroupChange = true;
                listBoxGroups.SetSelected(i, foundFunc);
                ignoreGroupChange = false;
            }

            ResumeLists();
        }

        private void listBoxFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedGroups();
            UpdateStatsLabel();
        }

        void UpdateStatsLabel()
        {
            label2.Text = $"{listBoxFunctions.SelectedItems.Count}/{listBoxFunctions.Items.Count} functions disabled";
        }
    }
}
