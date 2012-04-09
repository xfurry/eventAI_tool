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
    public partial class NewCreatureDialog : Form
    {
        private bool bIsCreature;

        public NewCreatureDialog(bool bIsCreature)
        {
            InitializeComponent();
            this.bIsCreature = bIsCreature;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Int32 test;
            //string strin = "";
            //if (e.KeyChar.ToString() == "\b" && (sender as TextBox).Text.Length != 0)
            //{
            //    strin = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            //}
            //else
            //{
            //    strin = (sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.KeyChar.ToString());
            //}
            //bool tes = Int32.TryParse(strin, out test);
            //if ("1234567890\b".IndexOf(e.KeyChar.ToString()) < 0 || !tes)
            //{
            //    e.Handled = true;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length == 0)
            {
                MessageBox.Show("The id cannot be blank.");
                return;
            }

            string str = textBox1.Text.Trim();
            Int64 value;
            bool isNum = Int64.TryParse(str, out value);
            if (!isNum)
            {
                MessageBox.Show("The script id should be a number. Please enter a number.");
                return;
            }

            if (bIsCreature)
            {

                if (Datastores.dbused && !creatures.npcsAvailable.Contains(System.Convert.ToUInt32(textBox1.Text)))
                {
                    MessageBox.Show("This Creature is NOT in creature_template");
                    return;
                }

                creature newcreature = new creature(System.Convert.ToUInt32(textBox1.Text), "");
                if (!creatures.AddCreature(newcreature))
                    MessageBox.Show("ID already Exists!");
                else
                {
                    this.Hide();

                    (this.MdiParent as Hauptfenster).ShowNewForm(newcreature.creature_id);
                    (this.MdiParent as Hauptfenster).UpdateNPCListBox();
                }
            }
            else
            {
                db_script newscript = new db_script(System.Convert.ToUInt32(textBox1.Text));
                if (!db_scripts.AddScript(newscript))
                    MessageBox.Show("ID already Exists!");
                else
                {
                    this.Hide();

                    (this.MdiParent as Hauptfenster).ShowNewForm(newscript.id);
                    (this.MdiParent as Hauptfenster).UpdateNPCListBox();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
