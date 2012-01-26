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

namespace EventAI_Creator.GUI.General.localestext
{
    public partial class TEXTEditor : Form
    {
        uint text_id;
        public TEXTEditor()
        {
            InitializeComponent();
        }

        private void UpdateListBox(bool updateofficial)
        {
            if (updateofficial)
            {
                listBoxtexts.Items.Clear();
                foreach (KeyValuePair<uint, localized_text> item in localized_texts.OffList)
                {
                    listBoxtexts.Items.Add(item.Key);
                }
            }
            customlistBoxtexts.Items.Clear();
            foreach (KeyValuePair<uint, localized_text> item in localized_texts.map)
            {
                customlistBoxtexts.Items.Add(item.Key);
                if (item.Value.overwritesofficial)
                    customlistBoxtexts.SetItemChecked(customlistBoxtexts.Items.Count - 1, true);
            }
        }

        private void TEXTEditor_Load(object sender, EventArgs e)
        {
            UpdateListBox(true);
            if(customlistBoxtexts.Items.Count != 0)
            this.customlistBoxtexts.SelectedIndex = 0;
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            if (this.textboxadd.Text.Length != 0)
            {
                if (localized_texts.Add(System.Convert.ToUInt32(this.textboxadd.Text)))
                {
                    text_id = System.Convert.ToUInt32(this.textboxadd.Text);
                    textlocalID.Text = this.textboxadd.Text;
                    UpdateListBox(false);
                    TextBoxlocal0.Text = ""; TextBoxlocal1.Text = ""; TextBoxlocal2.Text = ""; TextBoxlocal3.Text = "";
                    TextBoxlocal4.Text = ""; TextBoxlocal5.Text = ""; TextBoxlocal6.Text = ""; TextBoxlocal7.Text = "";
                    TextBoxlocal8.Text = ""; textboxcomment.Text = "";

                    int i = 0;
                    foreach (uint item in customlistBoxtexts.Items)
                    {
                        if (item.ToString() == textlocalID.Text)
                        {
                            customlistBoxtexts.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
            }
        }

        private void listBoxtexts_Click(object sender, EventArgs e)
        {
            if (localized_texts.map.ContainsKey(Convert.ToUInt32(listBoxtexts.SelectedItem)))
            {
                customlistBoxtexts.SelectedIndex = customlistBoxtexts.Items.IndexOf(listBoxtexts.SelectedItem);
            }
            else
            {
                localized_texts.map.Add(Convert.ToUInt32(listBoxtexts.SelectedItem), localized_texts.OffList[Convert.ToUInt32(listBoxtexts.SelectedItem)]);
                UpdateListBox(false);
                customlistBoxtexts.SelectedIndex = customlistBoxtexts.Items.IndexOf(listBoxtexts.SelectedItem);
            }
        }

        private void customlistBoxtexts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                text_id = System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex]);
                textlocalID.Text = text_id.ToString();
                TextBoxlocal0.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_0;
                TextBoxlocal1.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_1;
                TextBoxlocal2.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_2;
                TextBoxlocal3.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_3;
                TextBoxlocal4.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_4;
                TextBoxlocal5.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_5;
                TextBoxlocal6.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_6;
                TextBoxlocal7.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_7;
                TextBoxlocal8.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_8;
                textboxcomment.Text = localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].comment;
                localized_texts.map[System.Convert.ToUInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].changed = true;
            }
        }

        private void numberbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Int32 test;
            string strin = "";
            if (e.KeyChar.ToString() == "\b" && (sender as TextBox).Text.Length != 0)
            {
                strin = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }
            else
            {
                strin = (sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.KeyChar.ToString());
            }
            if (strin != "")
            {
                bool tes = Int32.TryParse(strin, out test);
                if ("1234567890\b".IndexOf(e.KeyChar.ToString()) < 0 || !tes)
                {
                    e.Handled = true;
                }
            }
            else e.Handled = false;
        }

        private void stringbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ("\"\'".IndexOf(e.KeyChar.ToString()) < 0)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void localetextbox_TextChanged(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                if ((sender as RichTextBox) == TextBoxlocal0)
                    localized_texts.map[text_id].locale_0 = TextBoxlocal0.Text;
                if ((sender as RichTextBox) == TextBoxlocal1)
                    localized_texts.map[text_id].locale_1 = TextBoxlocal1.Text;
                if ((sender as RichTextBox) == TextBoxlocal2)
                    localized_texts.map[text_id].locale_2 = TextBoxlocal2.Text;
                if ((sender as RichTextBox) == TextBoxlocal3)
                    localized_texts.map[text_id].locale_3 = TextBoxlocal3.Text;
                if ((sender as RichTextBox) == TextBoxlocal4)
                    localized_texts.map[text_id].locale_4 = TextBoxlocal4.Text;
                if ((sender as RichTextBox) == TextBoxlocal5)
                    localized_texts.map[text_id].locale_5 = TextBoxlocal5.Text;
                if ((sender as RichTextBox) == TextBoxlocal6)
                    localized_texts.map[text_id].locale_6 = TextBoxlocal6.Text;
                if ((sender as RichTextBox) == TextBoxlocal7)
                    localized_texts.map[text_id].locale_7 = TextBoxlocal7.Text;
                if ((sender as RichTextBox) == TextBoxlocal8)
                    localized_texts.map[text_id].locale_8 = TextBoxlocal8.Text;
                if ((sender as TextBox) == textboxcomment)
                    localized_texts.map[text_id].comment = textboxcomment.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Datastores.dbused)
            {
                switch (MessageBox.Show("Do you want to Remove it from Database Now? (Executing delete Query", "Remove from Database?", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        string query = SQLcreator.CreateDeleteQuery(localized_texts.map[text_id],"");
                        MySqlCommand c = new MySqlCommand(query,SQLConnection.conn);
                        try
                        {
                            c.ExecuteNonQuery();
                            localized_texts.map.Remove(text_id);
                            UpdateListBox(false);
                            if (customlistBoxtexts.Items.Count != 0)
                                customlistBoxtexts.SelectedIndex = 0;
                            else customlistBoxtexts.SelectedIndex = -1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case DialogResult.No:
                        localized_texts.map.Remove(text_id);
                        UpdateListBox(false);
                        if (customlistBoxtexts.Items.Count != 0)
                            customlistBoxtexts.SelectedIndex = 0;
                        else customlistBoxtexts.SelectedIndex = -1;
                        break;
                    case DialogResult.Cancel:
                        break;

                }
            }
            else
            {
                localized_texts.map.Remove(text_id);
                UpdateListBox(false);
                if (customlistBoxtexts.Items.Count != 0)
                    customlistBoxtexts.SelectedIndex = 0;
                else customlistBoxtexts.SelectedIndex = -1;
            }
        }

        private void toDBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                SQLCommonExecutes.SaveOneItemTODB(localized_texts.map[text_id]);
            }
            else MessageBox.Show("No Items");
        }

        private void toDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                SQLCommonExecutes.SaveAllItemsToDB(localized_texts.map);
            }
            else MessageBox.Show("No Items");
        }

        private void toFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = saveFileDialog.FileName;
                    localized_texts.PrintALLLocalsToFile(FileName);
                }
            }
            else MessageBox.Show("No Items");
            
        }

        private void toFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = saveFileDialog.FileName;
                    localized_texts.PrintLocalToFile(text_id, FileName);
                }
            }
            else MessageBox.Show("No Items");
        }

        private void customlistBoxtexts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                if (customlistBoxtexts.GetItemChecked(customlistBoxtexts.SelectedIndex))
                {
                    SQLConnection.DoNONREADSD2Query("DELETE FROM info_locals WHERE entry = " + Convert.ToUInt32(customlistBoxtexts.SelectedItem) + ";", false);
                    localized_texts.map[Convert.ToUInt32(customlistBoxtexts.SelectedItem)].overwritesofficial = false;
                }
                else
                {
                    SQLConnection.DoNONREADSD2Query("INSERT INTO info_locals VALUES(" + Convert.ToUInt32(customlistBoxtexts.SelectedItem) + ");", false);
                    localized_texts.map[Convert.ToUInt32(customlistBoxtexts.SelectedItem)].overwritesofficial = true;
                }
            }
        }
    }
}
