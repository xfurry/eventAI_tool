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
    public partial class EventControl : UserControl
    {
        int eventid;
        uint creature_id;
        bool locked = true;
        
        public EventControl(Event_dataset Data,Int32 ID,uint creatureid)
        {
            InitializeComponent();
            this.Name = ID.ToString();
            eventid = ID;
            creature_id = creatureid;
            this.eventnumber.Text = "Event: " + ID.ToString();

            this.expand.Checked = true;

            for(int n=0; n < Info.EventListInfo.GetLength(0);n++)
            {
                this.EventTypeCBox.Items.Add(Info.EventListInfo[n,0]);
            }
            for (int n = 0; n < Info.ActionListInfo.GetLength(0); n++)
            {
                this.Action1TypeCBox.Items.Add(Info.ActionListInfo[n, 0]);
                this.Action2TypeCBox.Items.Add(Info.ActionListInfo[n, 0]);
                this.Action3TypeCBox.Items.Add(Info.ActionListInfo[n, 0]);
            }

            this.Action1TypeCBox.SelectedIndex      =       Data.action1_type;
            this.Action1Param1Tbox.Text             =       Data.action1_param1.ToString();
            this.Action1Param2Tbox.Text             =       Data.action1_param2.ToString();
            this.Action1Param3Tbox.Text             =       Data.action1_param3.ToString();

            this.Action2TypeCBox.SelectedIndex      =       Data.action2_type;
            this.Action2Param1Tbox.Text             =       Data.action2_param1.ToString();
            this.Action2Param2Tbox.Text             =       Data.action2_param2.ToString();
            this.Action2Param3Tbox.Text             =       Data.action2_param3.ToString();

            this.Action3TypeCBox.SelectedIndex      =       Data.action3_type;
            this.Action3Param1Tbox.Text             =       Data.action3_param1.ToString();
            this.Action3Param2Tbox.Text             =       Data.action3_param2.ToString();
            this.Action3Param3Tbox.Text             =       Data.action3_param3.ToString();

            this.EventTypeCBox.SelectedIndex = Data.event_type;
            this.EventParam1.Text                   =       Data.event_param1.ToString();
            this.EventParam2.Text                   =       Data.event_param2.ToString();
            this.EventParam3.Text                   =       Data.event_param3.ToString();
            this.EventParam4.Text                   =       Data.event_param4.ToString();

            this.EventChanceTBox.Text               =       Data.event_chance.ToString();
            this.EventFlagTBox.Text                 =       Data.event_flags.ToString();
            this.txtBoxComment.Text                  =       Data.comment;

            this.SetInversePhaseMask(Data.event_inverse_phase_mask);

            this.EventTypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Action1TypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Action2TypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Action3TypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            locked = false;
        }

        private void SetInversePhaseMask(uint map)
        {
            uint bla;
            for (int i = 32; i > 0; i--)
            {
                bla = 0;
                for (int ii = 0; ii < i; ii++)
                {
                    bla = bla * 2;
                    if (bla == 0)
                        bla++;
                }
                if (map >= bla)
                {
                    switch (bla)
                    {
                        case 1:
                            this.PhaseCheckBox01.Checked = true;
                            break;
                        case 2:
                            this.PhaseCheckBox02.Checked = true;
                            break;
                        case 4:
                            this.PhaseCheckBox03.Checked = true;
                            break;
                        case 8:
                            this.PhaseCheckBox04.Checked = true;
                            break;
                        case 16:
                            this.PhaseCheckBox05.Checked = true;
                            break;
                        case 32:
                            this.PhaseCheckBox06.Checked = true;
                            break;
                        case 64:
                            this.PhaseCheckBox07.Checked = true;
                            break;
                        case 128:
                            this.PhaseCheckBox08.Checked = true;
                            break;
                        case 256:
                            this.PhaseCheckBox09.Checked = true;
                            break;
                        case 512:
                            this.PhaseCheckBox10.Checked = true;
                            break;
                        case 1024:
                            this.PhaseCheckBox11.Checked = true;
                            break;
                        case 2048:
                            this.PhaseCheckBox12.Checked = true;
                            break;
                        case 4096:
                            this.PhaseCheckBox13.Checked = true;
                            break;
                        case 8192:
                            this.PhaseCheckBox14.Checked = true;
                            break;
                        case 16384:
                            this.PhaseCheckBox15.Checked = true;
                            break;
                        case 32768:
                            this.PhaseCheckBox16.Checked = true;
                            break;
                        case 65536:
                            this.PhaseCheckBox17.Checked = true;
                            break;
                        case 131072:
                            this.PhaseCheckBox18.Checked = true;
                            break;
                        case 262144:
                            this.PhaseCheckBox19.Checked = true;
                            break;
                        case 524288:
                            this.PhaseCheckBox20.Checked = true;
                            break;
                        case 1048576:
                            this.PhaseCheckBox21.Checked = true;
                            break;
                        case 2097152:
                            this.PhaseCheckBox22.Checked = true;
                            break;
                        case 4194304:
                            this.PhaseCheckBox23.Checked = true;
                            break;
                        case 8388608:
                            this.PhaseCheckBox24.Checked = true;
                            break;
                        case 16777216:
                            this.PhaseCheckBox25.Checked = true;
                            break;
                        case 33554432:
                            this.PhaseCheckBox26.Checked = true;
                            break;
                        case 67108864:
                            this.PhaseCheckBox27.Checked = true;
                            break;
                        case 134217728:
                            this.PhaseCheckBox28.Checked = true;
                            break;
                        case 268435456:
                            this.PhaseCheckBox29.Checked = true;
                            break;
                        case 536870912:
                            this.PhaseCheckBox30.Checked = true;
                            break;
                        case 1073741824:
                            this.PhaseCheckBox31.Checked = true;
                            break;
                        case 2147483648:
                            this.PhaseCheckBox32.Checked = true;
                            break;
                    }
                    map -= bla;
                }
            }
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public Event_dataset GetEventData()
        {
                Event_dataset Data = new Event_dataset();

                Data.action1_type = this.Action1TypeCBox.SelectedIndex;
                if (Action1Param1Tbox.Text.Length != 0 && Action1Param1Tbox.Text != "-") Data.action1_param1 = System.Convert.ToInt32(this.Action1Param1Tbox.Text);
                if (Action1Param2Tbox.Text.Length != 0 && Action1Param2Tbox.Text != "-") Data.action1_param2 = System.Convert.ToInt32(this.Action1Param2Tbox.Text);
                if (Action1Param3Tbox.Text.Length != 0 && Action1Param3Tbox.Text != "-") Data.action1_param3 = System.Convert.ToInt32(this.Action1Param3Tbox.Text);

                Data.action2_type = this.Action2TypeCBox.SelectedIndex;
                if (Action2Param1Tbox.Text.Length != 0 && Action2Param1Tbox.Text != "-") Data.action2_param1 = System.Convert.ToInt32(this.Action2Param1Tbox.Text);
                if (Action2Param2Tbox.Text.Length != 0 && Action2Param2Tbox.Text != "-") Data.action2_param2 = System.Convert.ToInt32(this.Action2Param2Tbox.Text);
                if (Action2Param3Tbox.Text.Length != 0 && Action2Param3Tbox.Text != "-") Data.action2_param3 = System.Convert.ToInt32(this.Action2Param3Tbox.Text);

                Data.action3_type = this.Action3TypeCBox.SelectedIndex;
                if (Action3Param1Tbox.Text.Length != 0 && Action3Param1Tbox.Text != "-") Data.action3_param1 = System.Convert.ToInt32(this.Action3Param1Tbox.Text);
                if (Action3Param2Tbox.Text.Length != 0 && Action3Param2Tbox.Text != "-") Data.action3_param2 = System.Convert.ToInt32(this.Action3Param2Tbox.Text);
                if (Action3Param3Tbox.Text.Length != 0 && Action3Param3Tbox.Text != "-") Data.action3_param3 = System.Convert.ToInt32(this.Action3Param3Tbox.Text);

                Data.event_type = this.EventTypeCBox.SelectedIndex;
                if (EventParam1.Text.Length != 0 && EventParam1.Text != "-") Data.event_param1 = System.Convert.ToInt32(this.EventParam1.Text);
                if (EventParam2.Text.Length != 0 && EventParam2.Text != "-") Data.event_param2 = System.Convert.ToInt32(this.EventParam2.Text);
                if (EventParam3.Text.Length != 0 && EventParam3.Text != "-") Data.event_param3 = System.Convert.ToInt32(this.EventParam3.Text);
                if (EventParam4.Text.Length != 0 && EventParam4.Text != "-") Data.event_param4 = System.Convert.ToInt32(this.EventParam4.Text);

                if (EventChanceTBox.Text.Length != 0 && EventChanceTBox.Text != "-") Data.event_chance = System.Convert.ToInt32(this.EventChanceTBox.Text);
                if (EventFlagTBox.Text.Length != 0 && EventFlagTBox.Text != "-") Data.event_flags = System.Convert.ToInt32(this.EventFlagTBox.Text);
                if (txtBoxComment.Text.Length != 0 && txtBoxComment.Text != "-") Data.comment = this.txtBoxComment.Text;

                Data.event_inverse_phase_mask = 0;

                if (this.PhaseCheckBox01.Checked) Data.event_inverse_phase_mask += 1;
                if (this.PhaseCheckBox02.Checked) Data.event_inverse_phase_mask += 2;
                if (this.PhaseCheckBox03.Checked) Data.event_inverse_phase_mask += 4;
                if (this.PhaseCheckBox04.Checked) Data.event_inverse_phase_mask += 8;
                if (this.PhaseCheckBox05.Checked) Data.event_inverse_phase_mask += 16;
                if (this.PhaseCheckBox06.Checked) Data.event_inverse_phase_mask += 32;
                if (this.PhaseCheckBox07.Checked) Data.event_inverse_phase_mask += 64;
                if (this.PhaseCheckBox08.Checked) Data.event_inverse_phase_mask += 128;
                if (this.PhaseCheckBox09.Checked) Data.event_inverse_phase_mask += 256;
                if (this.PhaseCheckBox10.Checked) Data.event_inverse_phase_mask += 512;
                if (this.PhaseCheckBox11.Checked) Data.event_inverse_phase_mask += 1024;
                if (this.PhaseCheckBox12.Checked) Data.event_inverse_phase_mask += 2048;
                if (this.PhaseCheckBox13.Checked) Data.event_inverse_phase_mask += 4096;
                if (this.PhaseCheckBox14.Checked) Data.event_inverse_phase_mask += 8192;
                if (this.PhaseCheckBox15.Checked) Data.event_inverse_phase_mask += 16384;
                if (this.PhaseCheckBox16.Checked) Data.event_inverse_phase_mask += 32768;
                if (this.PhaseCheckBox17.Checked) Data.event_inverse_phase_mask += 65536;
                if (this.PhaseCheckBox18.Checked) Data.event_inverse_phase_mask += 131072;
                if (this.PhaseCheckBox19.Checked) Data.event_inverse_phase_mask += 262144;
                if (this.PhaseCheckBox20.Checked) Data.event_inverse_phase_mask += 524288;
                if (this.PhaseCheckBox21.Checked) Data.event_inverse_phase_mask += 1048576;
                if (this.PhaseCheckBox22.Checked) Data.event_inverse_phase_mask += 2097152;
                if (this.PhaseCheckBox23.Checked) Data.event_inverse_phase_mask += 4194304;
                if (this.PhaseCheckBox24.Checked) Data.event_inverse_phase_mask += 8388608;
                if (this.PhaseCheckBox25.Checked) Data.event_inverse_phase_mask += 16777216;
                if (this.PhaseCheckBox26.Checked) Data.event_inverse_phase_mask += 33554432;
                if (this.PhaseCheckBox27.Checked) Data.event_inverse_phase_mask += 67108864;
                if (this.PhaseCheckBox28.Checked) Data.event_inverse_phase_mask += 134217728;
                if (this.PhaseCheckBox29.Checked) Data.event_inverse_phase_mask += 268435456;
                if (this.PhaseCheckBox30.Checked) Data.event_inverse_phase_mask += 536870912;
                if (this.PhaseCheckBox31.Checked) Data.event_inverse_phase_mask += 1073741824;
                if (this.PhaseCheckBox32.Checked) Data.event_inverse_phase_mask += 2147483648;

                creatures.npcList[creature_id].line[eventid] = Data;
                creatures.npcList[creature_id].changed = true;
                return Data;
        }

        private void EventTypeCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip.SetToolTip((sender as ComboBox),Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 5]);
            if(Info.EventListInfo[this.EventTypeCBox.SelectedIndex,1] == "")
            {
                this.lblevParam1.Text = "Param 1";
                this.EventParam1.Text = "0";
                this.EventParam1.Enabled = false;
            }
            else 
            {
                this.lblevParam1.Text = Info.EventListInfo[this.EventTypeCBox.SelectedIndex,1];
                this.EventParam1.Text = "0";
                this.EventParam1.Enabled = true;
            }
            if (Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 2] == "")
            {
                this.lblevParam2.Text = "Param 2";
                this.EventParam2.Text = "0";
                this.EventParam2.Enabled = false;
            }
            else
            {
                this.lblevParam2.Text = Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 2];
                this.EventParam2.Text = "0";
                this.EventParam2.Enabled = true;
            }
            if (Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 3] == "")
            {
                this.lblevParam3.Text = "Param 3";
                this.EventParam3.Text = "0";
                this.EventParam3.Enabled = false;
            }
            else
            {
                this.lblevParam3.Text = Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 3];
                this.EventParam3.Text = "0";
                this.EventParam3.Enabled = true;
            }
            if (Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 4] == "")
            {
                this.lblevParam4.Text = "Param 4";
                this.EventParam4.Text = "0";
                this.EventParam4.Enabled = false;
            }
            else
            {
                this.lblevParam4.Text = Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 4];
                this.EventParam4.Text = "0";
                this.EventParam4.Enabled = true;
            }
           if (!locked)
            GetEventData();
        }


        private void ActionTypeCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox Cbox = (sender as ComboBox);
            Label[] Labl = new Label[3];
            TextBox[] Tbox = new TextBox[3];
            if (Cbox == this.Action1TypeCBox)
            {
                Labl[0] = this.Action1Param1Lb;
                Labl[1] = this.Action1Param2Lb;
                Labl[2] = this.Action1Param3Lb;
                Tbox[0] = this.Action1Param1Tbox;
                Tbox[1] = this.Action1Param2Tbox;
                Tbox[2] = this.Action1Param3Tbox;
            }
            if (Cbox == this.Action2TypeCBox)
            {
                Labl[0] = this.Action2Param1Lb;
                Labl[1] = this.Action2Param2Lb;
                Labl[2] = this.Action2Param3Lb;
                Tbox[0] = this.Action2Param1Tbox;
                Tbox[1] = this.Action2Param2Tbox;
                Tbox[2] = this.Action2Param3Tbox;
            }
            if (Cbox == this.Action3TypeCBox)
            {
                Labl[0] = this.Action3Param1Lb;
                Labl[1] = this.Action3Param2Lb;
                Labl[2] = this.Action3Param3Lb;
                Tbox[0] = this.Action3Param1Tbox;
                Tbox[1] = this.Action3Param2Tbox;
                Tbox[2] = this.Action3Param3Tbox;
            }

            toolTip.SetToolTip((sender as ComboBox), Info.ActionListInfo[Cbox.SelectedIndex, 4]);

            for (int n = 0; n < 3; n++)
            {
                if (Info.ActionListInfo[Cbox.SelectedIndex, n+1] != "")
                {
                    Labl[n].Text = Info.ActionListInfo[Cbox.SelectedIndex, n+1];
                    Tbox[n].Text = "0";
                    if (Cbox.SelectedIndex == 6 || 7 == Cbox.SelectedIndex || 8 == Cbox.SelectedIndex || 9 == Cbox.SelectedIndex || 10 == Cbox.SelectedIndex || 30 == Cbox.SelectedIndex)
                        Tbox[n].Text = "-1";
                    Tbox[n].Enabled = true;

                    switch (Info.ActionListInfo[Cbox.SelectedIndex, n + 1])
                    {
                        case "Target":
                            toolTip.SetToolTip(Tbox[n], "0    TARGET_T_SELF\n1    TARGET_T_HOSTILE \n2    TARGET_T_HOSTILE_SECOND_AGGRO\n3    TARGET_T_HOSTILE_LAST_AGGRO\n4    TARGET_T_HOSTILE_RANDOM\n5    TARGET_T_HOSTILE_RANDOM_NOT_TOP\n6    TARGET_T_ACTION_INVOKER");
                            break;
                        case "CastFlags":
                            toolTip.SetToolTip(Tbox[n], "1 :0       CAST_INTURRUPT_PREVIOUS\n2 :1       CAST_TRIGGERED\n4 :2       CAST_FORCE_CAST\n8 :3       CAST_NO_MELEE_IF_OOM\n16:4       CAST_FORCE_TARGET_SELF");
                            break;
                    }
                }
                else
                {

                    Labl[n].Text = "Param "+n.ToString();
                    Tbox[n].Text = "0";
                    Tbox[n].Enabled = false;
                    toolTip.SetToolTip(Tbox[n], "");
                }
            }
            if (!locked)
                GetEventData();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int test;
            string strin = "";
            if (e.KeyChar.ToString() == "\b" && (sender as TextBox).Text.Length != 0)
            {
                strin = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }
            else
            {
                strin = (sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.KeyChar.ToString());
            }
            bool tes = int.TryParse(strin, out test);
            if (strin != "-" && strin != "")
            {
                if ("-1234567890\b".IndexOf(e.KeyChar.ToString()) < 0 || !tes)
                {
                    e.Handled = true;
                }
            }
            else e.Handled = false;
        }

        private void txtBoxComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ("\"\'".IndexOf(e.KeyChar.ToString()) < 0)
            //{
            //    e.Handled = false;
            //}
            //else e.Handled = true;
        }

        private void expand_CheckedChanged(object sender, EventArgs e)
        {
            if (this.expand.Checked) this.Height = 287;
            else this.Height = 20;
        }

        private void deleteevent_Click(object sender, EventArgs e)
        {
           Form blaa = this.ParentForm;
            NPCEditor bla = blaa as NPCEditor;
            uint creature_id = bla.npc_id;
            creatures.npcList[creature_id].line.RemoveAt(eventid);
            bla.Redraw(creature_id);

           // this.Parent.Controls.Remove(this);

            //(this.Parent as NPCEditor).Redraw(creature_id);
            
   //(this.ParentForm as NPCEditor).Redraw(creature_id);
        }

        private void control_changed(object sender, EventArgs e)
        {
            if (!locked)
            GetEventData();
        }

        private void txtBox_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "" || (sender as TextBox).Text == "-")
            {
                (sender as TextBox).Text = "0";
            }
        }
    }
}
