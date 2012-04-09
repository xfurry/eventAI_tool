namespace EventAI_Creator.GUI.Creature_scripts
{
    partial class DbScriptControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventCheckbox = new System.Windows.Forms.CheckBox();
            this.commentTextbox = new System.Windows.Forms.TextBox();
            this.groupBoxEvent = new System.Windows.Forms.GroupBox();
            this.labelAction = new System.Windows.Forms.Label();
            this.labelDelay = new System.Windows.Forms.Label();
            this.comboBoxAction = new System.Windows.Forms.ComboBox();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.label_flags = new System.Windows.Forms.Label();
            this.label_radius = new System.Windows.Forms.Label();
            this.label_buddy = new System.Windows.Forms.Label();
            this.label_datalong2 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label_datalong = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.groupBoxDataInt = new System.Windows.Forms.GroupBox();
            this.label_dataint4 = new System.Windows.Forms.Label();
            this.label_dataint3 = new System.Windows.Forms.Label();
            this.label_dataint2 = new System.Windows.Forms.Label();
            this.label_dataint1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.label_orientation = new System.Windows.Forms.Label();
            this.label_posZ = new System.Windows.Forms.Label();
            this.label_posY = new System.Windows.Forms.Label();
            this.label_posX = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBoxEvent.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.groupBoxDataInt.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventCheckbox
            // 
            this.eventCheckbox.AutoSize = true;
            this.eventCheckbox.Location = new System.Drawing.Point(4, 4);
            this.eventCheckbox.Name = "eventCheckbox";
            this.eventCheckbox.Size = new System.Drawing.Size(63, 17);
            this.eventCheckbox.TabIndex = 0;
            this.eventCheckbox.Text = "Event 1";
            this.eventCheckbox.UseVisualStyleBackColor = true;
            // 
            // commentTextbox
            // 
            this.commentTextbox.Location = new System.Drawing.Point(166, 27);
            this.commentTextbox.Name = "commentTextbox";
            this.commentTextbox.Size = new System.Drawing.Size(415, 20);
            this.commentTextbox.TabIndex = 1;
            this.commentTextbox.Text = "Comment";
            // 
            // groupBoxEvent
            // 
            this.groupBoxEvent.Controls.Add(this.labelAction);
            this.groupBoxEvent.Controls.Add(this.labelDelay);
            this.groupBoxEvent.Controls.Add(this.comboBoxAction);
            this.groupBoxEvent.Controls.Add(this.textBoxDelay);
            this.groupBoxEvent.Location = new System.Drawing.Point(16, 27);
            this.groupBoxEvent.Name = "groupBoxEvent";
            this.groupBoxEvent.Size = new System.Drawing.Size(129, 129);
            this.groupBoxEvent.TabIndex = 2;
            this.groupBoxEvent.TabStop = false;
            this.groupBoxEvent.Text = "Event Settings";
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Location = new System.Drawing.Point(10, 82);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(37, 13);
            this.labelAction.TabIndex = 3;
            this.labelAction.Text = "Action";
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(10, 25);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(94, 13);
            this.labelDelay.TabIndex = 2;
            this.labelDelay.Text = "Delay (in seconds)";
            // 
            // comboBoxAction
            // 
            this.comboBoxAction.FormattingEnabled = true;
            this.comboBoxAction.Location = new System.Drawing.Point(10, 100);
            this.comboBoxAction.Name = "comboBoxAction";
            this.comboBoxAction.Size = new System.Drawing.Size(100, 21);
            this.comboBoxAction.TabIndex = 1;
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(10, 49);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(100, 20);
            this.textBoxDelay.TabIndex = 0;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label_flags);
            this.groupBoxMain.Controls.Add(this.label_radius);
            this.groupBoxMain.Controls.Add(this.label_buddy);
            this.groupBoxMain.Controls.Add(this.label_datalong2);
            this.groupBoxMain.Controls.Add(this.textBox13);
            this.groupBoxMain.Controls.Add(this.textBox12);
            this.groupBoxMain.Controls.Add(this.textBox11);
            this.groupBoxMain.Controls.Add(this.textBox10);
            this.groupBoxMain.Controls.Add(this.label_datalong);
            this.groupBoxMain.Controls.Add(this.textBox9);
            this.groupBoxMain.Location = new System.Drawing.Point(166, 52);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(415, 104);
            this.groupBoxMain.TabIndex = 3;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Main Flags";
            // 
            // label_flags
            // 
            this.label_flags.AutoSize = true;
            this.label_flags.Location = new System.Drawing.Point(112, 73);
            this.label_flags.Name = "label_flags";
            this.label_flags.Size = new System.Drawing.Size(58, 13);
            this.label_flags.TabIndex = 9;
            this.label_flags.Text = "Data Flags";
            // 
            // label_radius
            // 
            this.label_radius.AutoSize = true;
            this.label_radius.Location = new System.Drawing.Point(112, 46);
            this.label_radius.Name = "label_radius";
            this.label_radius.Size = new System.Drawing.Size(103, 13);
            this.label_radius.TabIndex = 8;
            this.label_radius.Text = "Buddy search radius";
            // 
            // label_buddy
            // 
            this.label_buddy.AutoSize = true;
            this.label_buddy.Location = new System.Drawing.Point(112, 19);
            this.label_buddy.Name = "label_buddy";
            this.label_buddy.Size = new System.Drawing.Size(185, 13);
            this.label_buddy.TabIndex = 7;
            this.label_buddy.Text = "Buddy Entry (Creature or Gameobject)";
            // 
            // label_datalong2
            // 
            this.label_datalong2.AutoSize = true;
            this.label_datalong2.Location = new System.Drawing.Point(6, 57);
            this.label_datalong2.Name = "label_datalong2";
            this.label_datalong2.Size = new System.Drawing.Size(56, 13);
            this.label_datalong2.TabIndex = 6;
            this.label_datalong2.Text = "Datalong2";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(6, 73);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 20);
            this.textBox13.TabIndex = 5;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(303, 66);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 20);
            this.textBox12.TabIndex = 4;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(303, 43);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 20);
            this.textBox11.TabIndex = 3;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(303, 14);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 2;
            // 
            // label_datalong
            // 
            this.label_datalong.AutoSize = true;
            this.label_datalong.Location = new System.Drawing.Point(6, 17);
            this.label_datalong.Name = "label_datalong";
            this.label_datalong.Size = new System.Drawing.Size(50, 13);
            this.label_datalong.TabIndex = 1;
            this.label_datalong.Text = "Datalong";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(6, 33);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 20);
            this.textBox9.TabIndex = 0;
            // 
            // groupBoxDataInt
            // 
            this.groupBoxDataInt.Controls.Add(this.label_dataint4);
            this.groupBoxDataInt.Controls.Add(this.label_dataint3);
            this.groupBoxDataInt.Controls.Add(this.label_dataint2);
            this.groupBoxDataInt.Controls.Add(this.label_dataint1);
            this.groupBoxDataInt.Controls.Add(this.textBox4);
            this.groupBoxDataInt.Controls.Add(this.textBox3);
            this.groupBoxDataInt.Controls.Add(this.textBox2);
            this.groupBoxDataInt.Controls.Add(this.textBox1);
            this.groupBoxDataInt.Location = new System.Drawing.Point(16, 162);
            this.groupBoxDataInt.Name = "groupBoxDataInt";
            this.groupBoxDataInt.Size = new System.Drawing.Size(445, 72);
            this.groupBoxDataInt.TabIndex = 4;
            this.groupBoxDataInt.TabStop = false;
            this.groupBoxDataInt.Text = "Data Int Flags";
            // 
            // label_dataint4
            // 
            this.label_dataint4.AutoSize = true;
            this.label_dataint4.Location = new System.Drawing.Point(327, 30);
            this.label_dataint4.Name = "label_dataint4";
            this.label_dataint4.Size = new System.Drawing.Size(48, 13);
            this.label_dataint4.TabIndex = 8;
            this.label_dataint4.Text = "DataInt4";
            // 
            // label_dataint3
            // 
            this.label_dataint3.AutoSize = true;
            this.label_dataint3.Location = new System.Drawing.Point(221, 30);
            this.label_dataint3.Name = "label_dataint3";
            this.label_dataint3.Size = new System.Drawing.Size(48, 13);
            this.label_dataint3.TabIndex = 7;
            this.label_dataint3.Text = "DataInt3";
            // 
            // label_dataint2
            // 
            this.label_dataint2.AutoSize = true;
            this.label_dataint2.Location = new System.Drawing.Point(115, 30);
            this.label_dataint2.Name = "label_dataint2";
            this.label_dataint2.Size = new System.Drawing.Size(48, 13);
            this.label_dataint2.TabIndex = 5;
            this.label_dataint2.Text = "DataInt2";
            // 
            // label_dataint1
            // 
            this.label_dataint1.AutoSize = true;
            this.label_dataint1.Location = new System.Drawing.Point(7, 30);
            this.label_dataint1.Name = "label_dataint1";
            this.label_dataint1.Size = new System.Drawing.Size(48, 13);
            this.label_dataint1.TabIndex = 4;
            this.label_dataint1.Text = "DataInt1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(330, 46);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(224, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.label_orientation);
            this.groupBoxPosition.Controls.Add(this.label_posZ);
            this.groupBoxPosition.Controls.Add(this.label_posY);
            this.groupBoxPosition.Controls.Add(this.label_posX);
            this.groupBoxPosition.Controls.Add(this.textBox8);
            this.groupBoxPosition.Controls.Add(this.textBox7);
            this.groupBoxPosition.Controls.Add(this.textBox6);
            this.groupBoxPosition.Controls.Add(this.textBox5);
            this.groupBoxPosition.Location = new System.Drawing.Point(16, 241);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(445, 73);
            this.groupBoxPosition.TabIndex = 5;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Position";
            // 
            // label_orientation
            // 
            this.label_orientation.AutoSize = true;
            this.label_orientation.Location = new System.Drawing.Point(327, 31);
            this.label_orientation.Name = "label_orientation";
            this.label_orientation.Size = new System.Drawing.Size(58, 13);
            this.label_orientation.TabIndex = 7;
            this.label_orientation.Text = "Orientation";
            // 
            // label_posZ
            // 
            this.label_posZ.AutoSize = true;
            this.label_posZ.Location = new System.Drawing.Point(221, 31);
            this.label_posZ.Name = "label_posZ";
            this.label_posZ.Size = new System.Drawing.Size(54, 13);
            this.label_posZ.TabIndex = 6;
            this.label_posZ.Text = "Position Z";
            // 
            // label_posY
            // 
            this.label_posY.AutoSize = true;
            this.label_posY.Location = new System.Drawing.Point(115, 31);
            this.label_posY.Name = "label_posY";
            this.label_posY.Size = new System.Drawing.Size(54, 13);
            this.label_posY.TabIndex = 5;
            this.label_posY.Text = "Position Y";
            // 
            // label_posX
            // 
            this.label_posX.AutoSize = true;
            this.label_posX.Location = new System.Drawing.Point(10, 31);
            this.label_posX.Name = "label_posX";
            this.label_posX.Size = new System.Drawing.Size(54, 13);
            this.label_posX.TabIndex = 4;
            this.label_posX.Text = "Position X";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(328, 47);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 3;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(222, 47);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 2;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(116, 47);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(10, 47);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 0;
            // 
            // DbScriptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxPosition);
            this.Controls.Add(this.groupBoxDataInt);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.groupBoxEvent);
            this.Controls.Add(this.commentTextbox);
            this.Controls.Add(this.eventCheckbox);
            this.Name = "DbScriptControl";
            this.Size = new System.Drawing.Size(766, 332);
            this.groupBoxEvent.ResumeLayout(false);
            this.groupBoxEvent.PerformLayout();
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.groupBoxDataInt.ResumeLayout(false);
            this.groupBoxDataInt.PerformLayout();
            this.groupBoxPosition.ResumeLayout(false);
            this.groupBoxPosition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox eventCheckbox;
        private System.Windows.Forms.TextBox commentTextbox;
        private System.Windows.Forms.GroupBox groupBoxEvent;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.GroupBox groupBoxDataInt;
        private System.Windows.Forms.GroupBox groupBoxPosition;
        private System.Windows.Forms.ComboBox comboBoxAction;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label_dataint2;
        private System.Windows.Forms.Label label_dataint1;
        private System.Windows.Forms.Label label_orientation;
        private System.Windows.Forms.Label label_posZ;
        private System.Windows.Forms.Label label_posY;
        private System.Windows.Forms.Label label_posX;
        private System.Windows.Forms.Label label_flags;
        private System.Windows.Forms.Label label_radius;
        private System.Windows.Forms.Label label_buddy;
        private System.Windows.Forms.Label label_datalong2;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label_datalong;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label_dataint4;
        private System.Windows.Forms.Label label_dataint3;
    }
}
