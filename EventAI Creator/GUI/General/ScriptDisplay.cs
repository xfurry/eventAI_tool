using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventAI_Creator.GUI.General
{
    public partial class ScriptDisplay : Form
    {
        public ScriptDisplay(string query)
        {
            InitializeComponent();
            textBox_query.ScrollBars = ScrollBars.Both;
            textBox_query.Text = query;
        }

        private void button_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_copy_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(textBox_query.Text);
        }
    }
}
