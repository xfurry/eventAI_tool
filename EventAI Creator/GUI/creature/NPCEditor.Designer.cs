namespace EventAI_Creator
{
    partial class NPCEditor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllNPCsToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setInCreaturetemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEventToolStripMenuItem,
            this.saveToToolStripMenuItem,
            this.saveAllNPCsToToolStripMenuItem,
            this.setInCreaturetemplateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(733, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newEventToolStripMenuItem
            // 
            this.newEventToolStripMenuItem.Name = "newEventToolStripMenuItem";
            this.newEventToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.newEventToolStripMenuItem.Text = "New Event";
            this.newEventToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveToToolStripMenuItem
            // 
            this.saveToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.sQLFileToolStripMenuItem});
            this.saveToToolStripMenuItem.Name = "saveToToolStripMenuItem";
            this.saveToToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.saveToToolStripMenuItem.Text = "Save NPC  to";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // sQLFileToolStripMenuItem
            // 
            this.sQLFileToolStripMenuItem.Name = "sQLFileToolStripMenuItem";
            this.sQLFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.sQLFileToolStripMenuItem.Text = "SQL File";
            this.sQLFileToolStripMenuItem.Click += new System.EventHandler(this.sQLFileToolStripMenuItem_Click);
            // 
            // saveAllNPCsToToolStripMenuItem
            // 
            this.saveAllNPCsToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem1,
            this.sQLToolStripMenuItem1});
            this.saveAllNPCsToToolStripMenuItem.Name = "saveAllNPCsToToolStripMenuItem";
            this.saveAllNPCsToToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.saveAllNPCsToToolStripMenuItem.Text = "Save All NPCs to";
            // 
            // databaseToolStripMenuItem1
            // 
            this.databaseToolStripMenuItem1.Name = "databaseToolStripMenuItem1";
            this.databaseToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.databaseToolStripMenuItem1.Text = "Database";
            this.databaseToolStripMenuItem1.Click += new System.EventHandler(this.databaseToolStripMenuItem1_Click);
            // 
            // sQLToolStripMenuItem1
            // 
            this.sQLToolStripMenuItem1.Name = "sQLToolStripMenuItem1";
            this.sQLToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.sQLToolStripMenuItem1.Text = "SQL";
            this.sQLToolStripMenuItem1.Click += new System.EventHandler(this.sQLToolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 600);
            this.panel1.TabIndex = 1;
            // 
            // setInCreaturetemplateToolStripMenuItem
            // 
            this.setInCreaturetemplateToolStripMenuItem.Name = "setInCreaturetemplateToolStripMenuItem";
            this.setInCreaturetemplateToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.setInCreaturetemplateToolStripMenuItem.Text = "Remove Scriptname";
            this.setInCreaturetemplateToolStripMenuItem.Click += new System.EventHandler(this.setInCreaturetemplateToolStripMenuItem_Click);
            // 
            // NPCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(733, 624);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NPCEditor";
            this.Text = "eAI Creator";
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.NPCEditor_ControlRemoved);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem newEventToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem saveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllNPCsToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setInCreaturetemplateToolStripMenuItem;
    }
}

