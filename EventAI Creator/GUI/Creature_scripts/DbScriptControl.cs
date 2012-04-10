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

            //switch (comboBoxAction.SelectedIndex)
            //{
            //    case 0:     // talk
            //        textBox_dataint1.ReadOnly = false;
            //        textBox_dataint2.ReadOnly = false;
            //        textBox_dataint3.ReadOnly = false;
            //        textBox_dataint4.ReadOnly = false;
            //        break;
            //    case 3:     // move
            //    case 6:     // teleport
            //    case 10:    // summon
            //        textBox_posX.ReadOnly = false;
            //        textBox_posY.ReadOnly = false;
            //        textBox_posZ.ReadOnly = false;
            //        textBox_orientation.ReadOnly = false;
            //        break;
            //}

            locked = false;
        }

        // Load event data to list
        public Event_dataset_script GetEventData()
        {
            Event_dataset_script Data = new Event_dataset_script();

            Data.command = comboBoxAction.SelectedIndex;
            if (textBoxDelay.Text.Length != 0)          Data.delay = Convert.ToUInt32(textBoxDelay.Text);

            if (textBox_datalong.Text.Length != 0)      Data.datalong = Convert.ToUInt32(textBox_datalong.Text);
            if (textBox_datalong2.Text.Length != 0)     Data.datalong2 = Convert.ToUInt32(textBox_datalong2.Text);

            if (textBox_dataint1.Text.Length != 0)      Data.dataint = Convert.ToUInt32(textBox_dataint1.Text);
            if (textBox_dataint2.Text.Length != 0)      Data.dataint = Convert.ToUInt32(textBox_dataint2.Text);
            if (textBox_dataint3.Text.Length != 0)      Data.dataint = Convert.ToUInt32(textBox_dataint3.Text);
            if (textBox_dataint4.Text.Length != 0)      Data.dataint = Convert.ToUInt32(textBox_dataint4.Text);

            if (textBox_posX.Text.Length != 0)          Data.position_x = float.Parse(textBox_posX.Text);
            if (textBox_posY.Text.Length != 0)          Data.position_x = float.Parse(textBox_posY.Text);
            if (textBox_posZ.Text.Length != 0)          Data.position_x = float.Parse(textBox_posZ.Text);
            if (textBox_orientation.Text.Length != 0)   Data.position_x = float.Parse(textBox_orientation.Text);

            if (textBox_buddy.Text.Length != 0)         Data.buddy = Convert.ToUInt32(textBox_buddy.Text);
            if (textBox_radius.Text.Length != 0)        Data.radius = Convert.ToUInt32(textBox_radius.Text);
            if (textBox_flags.Text.Length != 0)         Data.dataflags = Convert.ToUInt32(textBox_flags.Text);

            if (commentTextbox.Text.Length != 0)        Data.comment = commentTextbox.Text;

            db_scripts.scriptList[script_id].line[eventid] = Data;
            db_scripts.scriptList[script_id].changed = true;
            return Data;
        }

        // wrapper to handle the width of the combo box
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

        // Expand / collapse events
        private void eventCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.eventCheckbox.Checked)
                this.Height = 287;
            else
                this.Height = 20;
        }

        // Switch command GUI
        private void comboBoxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset text boxes
            textBox_dataint1.ReadOnly = true;
            textBox_dataint2.ReadOnly = true;
            textBox_dataint3.ReadOnly = true;
            textBox_dataint4.ReadOnly = true;
            textBox_posX.ReadOnly = true;
            textBox_posY.ReadOnly = true;
            textBox_posZ.ReadOnly = true;
            textBox_orientation.ReadOnly = true;

            textBox_datalong2.ReadOnly = false;
            textBox_datalong.ReadOnly = false;
            label_datalong.Text = "Datalong";
            label_datalong2.Text = "Datalong2";

            switch (comboBoxAction.SelectedIndex)
            {
                case 0:     // talk
                    textBox_dataint1.ReadOnly = false;
                    textBox_dataint2.ReadOnly = false;
                    textBox_dataint3.ReadOnly = false;
                    textBox_dataint4.ReadOnly = false;
                    break;
                case 3:     // move
                case 6:     // teleport
                case 10:    // summon
                    textBox_posX.ReadOnly = false;
                    textBox_posY.ReadOnly = false;
                    textBox_posZ.ReadOnly = false;
                    textBox_orientation.ReadOnly = false;
                    break;
            }

            // Set all to 0
            textBox_datalong.Text = "0";
            textBox_datalong2.Text = "0";

            textBox_posX.Text = "0";
            textBox_posY.Text = "0";
            textBox_posZ.Text = "0";
            textBox_orientation.Text = "0";

            textBox_dataint1.Text = "0";
            textBox_dataint2.Text = "0";
            textBox_dataint3.Text = "0";
            textBox_dataint4.Text = "0";

            // Datalong labels
            if (Info.ScriptCommands[comboBoxAction.SelectedIndex, 1] != "")
                label_datalong.Text = Info.ScriptCommands[comboBoxAction.SelectedIndex, 1];
            else
                textBox_datalong.ReadOnly = true;

            if (Info.ScriptCommands[comboBoxAction.SelectedIndex, 2] != "")
                label_datalong2.Text = Info.ScriptCommands[comboBoxAction.SelectedIndex, 2];
            else
                textBox_datalong2.ReadOnly = true;

            if (!locked)
                GetEventData();
        }

        // Delete event
        private void button_delete_event_Click(object sender, EventArgs e)
        {
            Form parent = this.ParentForm;
            NPCEditor editor = parent as NPCEditor;
            uint id = editor.Id;
            db_scripts.scriptList[id].line.RemoveAt(eventid);
            editor.Redraw(id);
        }

        // Handle if the text is number
        private void txtBox_leave(object sender, EventArgs e)
        {
            string str = (sender as TextBox).Text.Trim();
            UInt64 value;
            bool isNum = UInt64.TryParse(str, out value);
            if (isNum)
            {
                if (!locked)
                    GetEventData();
            }
            else
                (sender as TextBox).Text = "0";
        }

        // Handle the comment text leave
        private void txtBox_comment_leave(object sender, EventArgs e)
        {
            if (!locked)
                GetEventData();
        }

        // Handle the float numbers for xyzo textboxes
        private void txtBox_leave_location(object sender, EventArgs e)
        {
            string str = (sender as TextBox).Text.Trim();
            float value;
            bool isNum = float.TryParse(str, out value);
            if (isNum)
            {
                if (!locked)
                    GetEventData();
            }
            else
                (sender as TextBox).Text = "0";
        }

        // Data flags load
        private void button_flags_Click(object sender, EventArgs e)
        {
            EventFlag dialog = new EventFlag(this, Convert.ToInt32(textBox_flags.Text), Info.ScriptFlags, 5, 0);
            dialog.ShowDialog(this);
        }

        // SetD DataFlags in the text box
        public void SetDataFlags(Int64 flagValue)
        {
            textBox_flags.Text = flagValue.ToString();

            if (!locked)
                GetEventData();
        }
    }
}
