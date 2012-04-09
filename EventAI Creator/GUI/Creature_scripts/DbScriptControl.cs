using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventAI_Creator
{
    public partial class DbScriptControl : UserControl
    {
        int eventid;
        uint script_id;
        bool locked = true;

        public DbScriptControl(Event_dataset_script Data, Int32 ID, uint id)
        {
            InitializeComponent();

            this.Name = ID.ToString();
            eventid = ID;
            script_id = id;
            this.eventCheckbox.Text = "Event: " + ID.ToString();

            this.eventCheckbox.Checked = true;

            for (int n = 0; n < Info.ScriptCommands.GetLength(0); n++)
                this.comboBoxAction.Items.Add(Info.ScriptCommands[n, 0]);

            // set width
            comboBoxAction.DropDownWidth = DropDownWidth(comboBoxAction);
            comboBoxAction.DropDownStyle = ComboBoxStyle.DropDownList;

            this.comboBoxAction.SelectedIndex = Data.command;
            this.textBoxDelay.Text = Data.delay.ToString();

            this.textBox_datalong.Text = Data.datalong.ToString();
            this.textBox_datalong2.Text = Data.datalong2.ToString();

            this.textBox_buddy.Text = Data.buddy.ToString();
            this.textBox_radius.Text = Data.radius.ToString();
            this.textBox_flags.Text = Data.dataflags.ToString();

            this.textBox_dataint1.Text = Data.dataint.ToString();
            this.textBox_dataint2.Text = Data.dataint2.ToString();
            this.textBox_dataint3.Text = Data.dataint3.ToString();
            this.textBox_dataint4.Text = Data.dataint4.ToString();

            this.textBox_posX.Text = Data.position_x.ToString();
            this.textBox_posY.Text = Data.position_y.ToString();
            this.textBox_posZ.Text = Data.position_z.ToString();
            this.textBox_orientation.Text = Data.orientation.ToString();

            this.commentTextbox.Text = Data.comment;
        }

        public Event_dataset_script GetEventData()
        {
            Event_dataset_script Data = new Event_dataset_script();

            return Data;
        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label_test = new Label();

            foreach (var obj in myCombo.Items)
            {
                label_test.Text = obj.ToString();
                temp = label_test.PreferredWidth;
                if (temp > maxWidth)
                    maxWidth = temp;
            }
            label_test.Dispose();
            return maxWidth;
        }
    }
}
