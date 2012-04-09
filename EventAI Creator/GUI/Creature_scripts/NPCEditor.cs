using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventAI_Creator
{
    public partial class NPCEditor : Form
    {
        public List<string> EventsList = new List<string>();
        public uint id;
        private bool bIsCreature;

        public NPCEditor(uint id, bool bIsCreature)
        {
            this.id = id;
            this.bIsCreature = bIsCreature;

            InitializeComponent();

            if (bIsCreature)
            {
                this.Text = "NPC:" + this.id;
                this.Name = "editor:" + this.id;

                if (creatures.npcList[this.id].activectemplate)
                    setInCreaturetemplateToolStripMenuItem.Text = "Remove scriptname";
                else
                    setInCreaturetemplateToolStripMenuItem.Text = "Set scriptname";

                Redraw(id);
            }
            else
            {
                this.Text = "SCRIPT:" + this.id;
                this.Name = "editor:" + this.id;

                LoadScript(id);
            }
        }

        // Load DB scripts form
        public void LoadScript(uint uiId)
        {
        }

        // Load Creature AI form
        public void Redraw(uint creature_id)
        {
            if (creatures.npcList[this.id].line.Count != 0 || splitContainer1.Panel2.Controls.Count != 0)
            {
                uint index = 0;
                EventsList.Clear();

                this.splitContainer1.Panel2.Controls.Clear();
                foreach (Event_dataset item in creatures.npcList[this.id].line)
                {
                    EventsList.Add(index.ToString());
                    index++;
                }

                foreach (string item in EventsList)
                {
                    EventControl newControl = new EventControl(creatures.npcList[this.id].line[Convert.ToInt32(item)], Convert.ToInt32(item), this.id);
                    this.splitContainer1.Panel2.Controls.Add(newControl);
                    newControl.Dock = DockStyle.Top;
                    newControl.Show();
                }
            }
            creatures.npcList[creature_id].changed = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            creatures.GetCreature(this.id).AddEvent();
            EventControl bla = new EventControl(creatures.GetCreature(this.id).line[creatures.GetCreature(this.id).line.Count - 1], (creatures.GetCreature(this.id).line.Count - 1), this.id);
            this.splitContainer1.Panel2.Controls.Add(bla);
            bla.Dock = DockStyle.Top;
            //(this.MdiParent as Hauptfenster).UpdateNPCListBox();
            EventsList.Add((creatures.GetCreature(this.id).line.Count - 1).ToString());
        }

        public void SaveEventsToNPCList()
        {
            foreach (string item in EventsList)
                (this.splitContainer1.Panel2.Controls.Find(item, false)[0] as EventControl).GetEventData();
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveEventsToNPCList();
        }

        private void NPCEditor_ControlRemoved(object sender, ControlEventArgs e)
        {
            Redraw(this.id);
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            SQLCommonExecutes.SaveOneItemTODB(creatures.npcList[this.id]);
        }

        private void databaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            SQLCommonExecutes.SaveAllItemsToDB(creatures.npcList);
        }

        private void sQLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                creatures.PrintCreatureToFile(this.id, FileName);
            }
        }

        private void sQLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                creatures.PrintALLCreaturesToFile(FileName);
            }
        }

        private void setInCreaturetemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Datastores.dbused)
            {
                if (creatures.npcList[this.id].activectemplate)
                {
                    if (SQLCommonExecutes.setScriptnameInCreature_template(this.id, true))
                    {
                        creatures.npcList[this.id].activectemplate = false;
                        setInCreaturetemplateToolStripMenuItem.Text = "Set scriptname";
                    }
                }
                else
                {
                    if (SQLCommonExecutes.setScriptnameInCreature_template(this.id, false))
                    {
                        creatures.npcList[this.id].activectemplate = true;
                        setInCreaturetemplateToolStripMenuItem.Text = "Remove scriptname";
                    }
                }
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            if (bIsCreature)
                System.Diagnostics.Process.Start("https://raw.github.com/mangos/mangos/master/doc/EventAI.txt");
            else
                System.Diagnostics.Process.Start("https://raw.github.com/mangos/mangos/master/doc/script_commands.txt");
        }

        private void queryWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            ScriptDisplay sd = new ScriptDisplay(creatures.PrintCreatureToWindow(this.id));
            sd.ShowDialog();
        }
    }
}
