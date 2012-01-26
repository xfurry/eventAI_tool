using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace EventAI_Creator
{
    public partial class Hauptfenster : Form
    {
        //private int childFormNumber = 0;

        public Hauptfenster()
        {
            InitializeComponent();
        }

        public void ShowNewForm(uint creature_id)
        {
            NPCEditor childForm = new NPCEditor(creature_id);
            childForm.MdiParent = this;
            childForm.Text = "NPC:  " + creature_id;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveAllNPCsTocreatures();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                creatures.PrintALLCreaturesToFile(FileName);
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
                childForm.Close();
        }

        public void UpdateNPCListBox(bool updateoff)
        {
            CheckedListBox npcListbox = panel1.Controls.Find("npclistbox", true)[0] as CheckedListBox;
            npcListbox.Items.Clear();
            IList<uint> list;

            list = creatures.npcList.Keys;
            for (int i = 0; i < list.Count; i++)
            {
                npcListbox.Items.Add(list[i].ToString());
                npcListbox.SetItemChecked(npcListbox.Items.Count - 1, false);
            }
        }

        private void ShowNewCreatureDialog(object sender, EventArgs e)
        {
            NewCreatureDialog dialog = new NewCreatureDialog();
            dialog.MdiParent = this;
            dialog.Show();
        }

        public void SaveAllNPCsTocreatures()
        {
            foreach (Form item in MdiChildren)
            {
                if(item is NPCEditor)
                 (item as NPCEditor).SaveEventsToNPCList();
            }
        }

        private void npclistbox_Click(object sender, EventArgs e)
        {
            if (this.npclistbox.SelectedIndex != -1)
            {
                bool makenew = true;
                foreach (Form item in MdiChildren)
                {
                    if (item is NPCEditor)
                    {
                        if ((item as NPCEditor).npc_id.ToString() == this.npclistbox.Items[this.npclistbox.SelectedIndex].ToString())
                        {
                            (item as NPCEditor).Show();
                            (item as NPCEditor).Activate();
                            makenew = false;
                        }
                    }
                }
                if (makenew)
                    this.ShowNewForm(System.Convert.ToUInt32(this.npclistbox.Items[this.npclistbox.SelectedIndex]));
            }
        }

        private void npclistbox_DoubleClick(object sender, EventArgs e)
        {
            if (this.npclistbox.SelectedIndex != -1)
            {
                bool makenew = true;
                foreach (Form item in MdiChildren)
                {
                    if (item is NPCEditor)
                    {
                        if ((item as NPCEditor).npc_id.ToString() == this.npclistbox.Items[this.npclistbox.SelectedIndex].ToString())
                        {
                            (item as NPCEditor).Show();
                            (item as NPCEditor).Activate();

                            if ((item as NPCEditor).WindowState == FormWindowState.Maximized)
                                (item as NPCEditor).WindowState = FormWindowState.Normal;
                            else (item as NPCEditor).WindowState = FormWindowState.Maximized;

                            makenew = false;
                        }
                    }
                }
                if (makenew)
                    this.ShowNewForm(System.Convert.ToUInt32(this.npclistbox.Items[this.npclistbox.SelectedIndex]));

            }
        }

        private void localizedTextsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool alreadyexist = false ;
            foreach (Form item in MdiChildren)
            {
                if (item is GUI.General.localestext.TEXTEditor)
                {
                    alreadyexist = true;
                    item.Show();
                }
            }
            if (!alreadyexist)
            {
                GUI.General.localestext.TEXTEditor newForm = new EventAI_Creator.GUI.General.localestext.TEXTEditor();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void summonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool alreadyexist = false;
            foreach (Form item in MdiChildren)
            {
                if (item is SummonsEditor)
                { alreadyexist = true; item.Show(); }
            }
            if (!alreadyexist)
            {
                SummonsEditor newForm = new SummonsEditor();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Datastores.dbused && (npclistbox.SelectedIndex != -1))
            {
                switch (MessageBox.Show("Do you want to Remove it from Database Now? (Executing delete Query", "Remove from Database?", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        string query = SQLcreator.CreateDeleteQuery(creatures.GetCreature(System.Convert.ToUInt32(this.npclistbox.Items[npclistbox.SelectedIndex])),"");
                        MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
                        try
                        {
                            if (npclistbox.SelectedIndex != -1)
                            {
                                foreach (Form item in MdiChildren)
                                {
                                    if (item is NPCEditor)
                                    {
                                        if ((item as NPCEditor).npc_id == System.Convert.ToInt32(this.npclistbox.Items[npclistbox.SelectedIndex]))
                                        {
                                            (item as NPCEditor).Close();
                                        }
                                    }
                                }
                                c.ExecuteNonQuery();
                                creatures.DelCreature(System.Convert.ToUInt32(this.npclistbox.Items[npclistbox.SelectedIndex]));
                                UpdateNPCListBox(false);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case DialogResult.No:
                        if (npclistbox.SelectedIndex != -1)
                        {
                            foreach (Form item in MdiChildren)
                            {
                                if (item is NPCEditor)
                                {
                                    if ((item as NPCEditor).npc_id == System.Convert.ToInt32(this.npclistbox.Items[npclistbox.SelectedIndex]))
                                    {
                                        (item as NPCEditor).Close();
                                    }
                                }
                            }

                            creatures.DelCreature(System.Convert.ToUInt32(this.npclistbox.Items[npclistbox.SelectedIndex]));
                            UpdateNPCListBox(false);
                        }
                        break;
                    case DialogResult.Cancel:
                        break;

                }
            }
            else
            {
                if (npclistbox.SelectedIndex != -1)
                {
                    //foreach (Form item in MdiChildren)
                    //{
                    //    if (item is NPCEditor)
                    //    {
                    //        if ((item as NPCEditor).npc_id == System.Convert.ToInt32(this.npclistbox.Items[npcofflistbox.SelectedIndex]))
                    //        {
                    //            (item as NPCEditor).Close();
                    //        }
                    //    }
                    //}

                    //creatures.DelCreature(System.Convert.ToUInt32(this.npclistbox.Items[npcofflistbox.SelectedIndex]));
                    //UpdateNPCListBox(false);
                }
            }
        }

        private void Hauptfenster_Load(object sender, EventArgs e)
        {
            Datastores.ReloadDB();
            UpdateNPCListBox(true);
        }

        private void Hauptfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLConnection.DisConnect();
            SSHConnection.DisConnect();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.General.eAICreator temp= new EventAI_Creator.GUI.General.eAICreator();
            temp.Show();
        }

        private void reloadDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form item in MdiChildren)
            {
                item.Close();
            }
            creatures.npcList.Clear();
            creatures.npcsAvailable.Clear();
            summons.map.Clear();
            localized_texts.map.Clear();
            Datastores.ReloadDB();
            UpdateNPCListBox(true);
        }

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool alreadyexist = false;
            foreach (Form item in MdiChildren)
            {
                if (item is GUI.General.ControlPanel)
                { alreadyexist = true; item.Show(); }
            }
            if (!alreadyexist)
            {
                GUI.General.ControlPanel newForm = new EventAI_Creator.GUI.General.ControlPanel();
                newForm.MdiParent = this;
                newForm.Show();
            }
        }
    }
}
