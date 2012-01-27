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
    public partial class EventFlag : Form
    {
        private EventControl parent;

        public EventFlag(EventControl control, int flag_value)
        {
            InitializeComponent();
            parent = control;

            // Check only the lists for the given event mask
            for (int i = checkedListBox_flags.Items.Count; i >= 0; i--)
            {
                if (Convert.ToInt32(Math.Pow(2, i)) <= flag_value)
                {
                    checkedListBox_flags.SetItemChecked(i, true);
                    flag_value -= Convert.ToInt32(Math.Pow(2, i));
                }
            }
        }

        private void button_flag_ok_Click(object sender, EventArgs e)
        {
            int flag_value = 0;

            foreach (int indexChecked in checkedListBox_flags.CheckedIndices)
                flag_value += Convert.ToInt32(Math.Pow(2, indexChecked));

            parent.set_event_flags(flag_value);
            this.Close();
        }
    }
}
