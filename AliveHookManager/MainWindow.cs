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

        private void Form1_Load(object sender, EventArgs e)
        {
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
                    if (existingFuncs.Contains(((LinkerMapParser.LinkerMapFunction)listBoxFunctions.Items[i]).Address.ToString("X")))
                        listBoxFunctions.SetSelected(i, true);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignoreGroupChange)
                return;

            listBoxFunctions.SelectedItems.Clear();

            List<LinkerMapParser.LinkerMapFunction> selectedFunctions = new List<LinkerMapParser.LinkerMapFunction>();

            foreach(var o in listBoxFunctions.Items)
            {
                LinkerMapParser.LinkerMapFunction func = (LinkerMapParser.LinkerMapFunction)o;
                var selectedObjects = new List<object>();
                foreach (var l in listBoxGroups.SelectedItems)
                    selectedObjects.Add(l);

                foreach (var l in listBoxGroups.Items)
                {
                    if (selectedObjects.Contains(l) && func.Object == (string)l)
                    {
                        selectedFunctions.Add(func);
                        break;
                    }
                }
            }

            foreach(var o in selectedFunctions)
            {
                listBoxFunctions.SelectedItems.Add(o);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ignoreGroupChange = true;
            for (int i = 0; i < listBoxGroups.Items.Count; i++)
                listBoxGroups.SetSelected(i, true);
            ignoreGroupChange = false;
            for (int i = 0; i < listBoxFunctions.Items.Count; i++)
                listBoxFunctions.SetSelected(i, true);
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
            ignoreGroupChange = true;
            for (int i = 0; i < listBoxGroups.Items.Count; i++)
                listBoxGroups.SetSelected(i, false);
            ignoreGroupChange = false;
            for (int i = 0; i < listBoxFunctions.Items.Count; i++)
                listBoxFunctions.SetSelected(i, false);
        }
    }
}
