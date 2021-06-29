namespace ConveyerBelt.ConveyerBelt
{
    partial class ConveyerBeltSetting
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtRowCount = new System.Windows.Forms.TextBox();
            this.txtColumnCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.conveyerBeltItem1 = new ConveyerBeltCustomControl.ConveyerBeltItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSettingToolStripMenuItem,
            this.LoadSettingToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // LoadSettingToolStripMenuItem
            // 
            this.LoadSettingToolStripMenuItem.Name = "LoadSettingToolStripMenuItem";
            this.LoadSettingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LoadSettingToolStripMenuItem.Text = "L&oad Setting";
            this.LoadSettingToolStripMenuItem.Click += new System.EventHandler(this.LoadSettingToolStripMenuItem_Click);
            // 
            // newSettingToolStripMenuItem
            // 
            this.newSettingToolStripMenuItem.Name = "newSettingToolStripMenuItem";
            this.newSettingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newSettingToolStripMenuItem.Text = "&NewSetting";
            this.newSettingToolStripMenuItem.Click += new System.EventHandler(this.newSettingToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"txt files (*.txt)|*.txt\"";
            // 
            // txtRowCount
            // 
            this.txtRowCount.Location = new System.Drawing.Point(121, 24);
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.Size = new System.Drawing.Size(100, 21);
            this.txtRowCount.TabIndex = 0;
            this.txtRowCount.Text = "0";
            this.txtRowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRowCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRowCount_KeyDown);
            // 
            // txtColumnCount
            // 
            this.txtColumnCount.Location = new System.Drawing.Point(121, 51);
            this.txtColumnCount.Name = "txtColumnCount";
            this.txtColumnCount.Size = new System.Drawing.Size(100, 21);
            this.txtColumnCount.TabIndex = 1;
            this.txtColumnCount.Text = "0";
            this.txtColumnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtColumnCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColumnCount_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "행";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "열";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(146, 103);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // conveyerBeltItem1
            // 
            this.conveyerBeltItem1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.conveyerBeltItem1.Location = new System.Drawing.Point(12, 37);
            this.conveyerBeltItem1.Name = "conveyerBeltItem1";
            this.conveyerBeltItem1.Size = new System.Drawing.Size(140, 20);
            this.conveyerBeltItem1.TabIndex = 6;
            // 
            // ConveyerBeltSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.conveyerBeltItem1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtColumnCount);
            this.Controls.Add(this.txtRowCount);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ConveyerBeltSetting";
            this.Text = "ConveyerBeltSetting";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSettingToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtRowCount;
        private System.Windows.Forms.TextBox txtColumnCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApply;
        private ConveyerBeltCustomControl.ConveyerBeltItem conveyerBeltItem1;
    }
}