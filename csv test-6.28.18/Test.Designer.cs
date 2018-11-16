namespace Trace_RSE_Tool
{
    partial class Test
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
            this.panelHead = new System.Windows.Forms.Panel();
            this.lblPullContacts = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tabBar = new System.Windows.Forms.TabControl();
            this.tabEmail = new System.Windows.Forms.TabPage();
            this.labeltest = new System.Windows.Forms.Label();
            this.radKnowBe4 = new System.Windows.Forms.RadioButton();
            this.radInsight = new System.Windows.Forms.RadioButton();
            this.btnCopyClipboard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPayloadPicker = new System.Windows.Forms.ComboBox();
            this.tabPhone = new System.Windows.Forms.TabPage();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.listBox = new System.Windows.Forms.ListBox();
            this.listView = new System.Windows.Forms.ListView();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.panelHead.SuspendLayout();
            this.tabBar.SuspendLayout();
            this.tabEmail.SuspendLayout();
            this.tabTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(218)))));
            this.panelHead.Controls.Add(this.lblPullContacts);
            this.panelHead.Controls.Add(this.btnOpenFile);
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Margin = new System.Windows.Forms.Padding(0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(548, 115);
            this.panelHead.TabIndex = 9;
            // 
            // lblPullContacts
            // 
            this.lblPullContacts.Location = new System.Drawing.Point(142, 39);
            this.lblPullContacts.Name = "lblPullContacts";
            this.lblPullContacts.Size = new System.Drawing.Size(80, 43);
            this.lblPullContacts.TabIndex = 1;
            this.lblPullContacts.Text = "Contact Data Extracted!";
            this.lblPullContacts.Visible = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOpenFile.Location = new System.Drawing.Point(12, 27);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(115, 55);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open Scope Form";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tabBar
            // 
            this.tabBar.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabBar.Controls.Add(this.tabEmail);
            this.tabBar.Controls.Add(this.tabPhone);
            this.tabBar.Controls.Add(this.tabTest);
            this.tabBar.HotTrack = true;
            this.tabBar.ItemSize = new System.Drawing.Size(70, 40);
            this.tabBar.Location = new System.Drawing.Point(0, 115);
            this.tabBar.Margin = new System.Windows.Forms.Padding(0);
            this.tabBar.Multiline = true;
            this.tabBar.Name = "tabBar";
            this.tabBar.RightToLeftLayout = true;
            this.tabBar.SelectedIndex = 0;
            this.tabBar.ShowToolTips = true;
            this.tabBar.Size = new System.Drawing.Size(548, 386);
            this.tabBar.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabBar.TabIndex = 10;
            // 
            // tabEmail
            // 
            this.tabEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.tabEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEmail.Controls.Add(this.btnPopulate);
            this.tabEmail.Controls.Add(this.labeltest);
            this.tabEmail.Controls.Add(this.radKnowBe4);
            this.tabEmail.Controls.Add(this.radInsight);
            this.tabEmail.Controls.Add(this.btnCopyClipboard);
            this.tabEmail.Controls.Add(this.label3);
            this.tabEmail.Controls.Add(this.cboPayloadPicker);
            this.tabEmail.ImageIndex = 1;
            this.tabEmail.Location = new System.Drawing.Point(4, 44);
            this.tabEmail.Name = "tabEmail";
            this.tabEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmail.Size = new System.Drawing.Size(540, 338);
            this.tabEmail.TabIndex = 0;
            this.tabEmail.ToolTipText = "Email Tools";
            // 
            // labeltest
            // 
            this.labeltest.BackColor = System.Drawing.Color.White;
            this.labeltest.Location = new System.Drawing.Point(9, 109);
            this.labeltest.Name = "labeltest";
            this.labeltest.Size = new System.Drawing.Size(522, 224);
            this.labeltest.TabIndex = 13;
            // 
            // radKnowBe4
            // 
            this.radKnowBe4.AutoSize = true;
            this.radKnowBe4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radKnowBe4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radKnowBe4.Location = new System.Drawing.Point(81, 29);
            this.radKnowBe4.Name = "radKnowBe4";
            this.radKnowBe4.Size = new System.Drawing.Size(78, 17);
            this.radKnowBe4.TabIndex = 12;
            this.radKnowBe4.TabStop = true;
            this.radKnowBe4.Text = "KnowBe4";
            this.radKnowBe4.UseVisualStyleBackColor = true;
            // 
            // radInsight
            // 
            this.radInsight.AutoSize = true;
            this.radInsight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInsight.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radInsight.Location = new System.Drawing.Point(12, 29);
            this.radInsight.Name = "radInsight";
            this.radInsight.Size = new System.Drawing.Size(63, 17);
            this.radInsight.TabIndex = 11;
            this.radInsight.TabStop = true;
            this.radInsight.Text = "Insight";
            this.radInsight.UseVisualStyleBackColor = true;
            // 
            // btnCopyClipboard
            // 
            this.btnCopyClipboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(218)))));
            this.btnCopyClipboard.FlatAppearance.BorderSize = 2;
            this.btnCopyClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyClipboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopyClipboard.Location = new System.Drawing.Point(368, 70);
            this.btnCopyClipboard.Name = "btnCopyClipboard";
            this.btnCopyClipboard.Size = new System.Drawing.Size(93, 36);
            this.btnCopyClipboard.TabIndex = 9;
            this.btnCopyClipboard.Text = "-> Clipboard";
            this.btnCopyClipboard.UseVisualStyleBackColor = true;
            this.btnCopyClipboard.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(182, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Payload Picker";
            // 
            // cboPayloadPicker
            // 
            this.cboPayloadPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPayloadPicker.FormattingEnabled = true;
            this.cboPayloadPicker.Location = new System.Drawing.Point(161, 59);
            this.cboPayloadPicker.Name = "cboPayloadPicker";
            this.cboPayloadPicker.Size = new System.Drawing.Size(177, 21);
            this.cboPayloadPicker.TabIndex = 6;
            this.cboPayloadPicker.SelectedIndexChanged += new System.EventHandler(this.cboPayloadPicker_SelectedIndexChanged);
            // 
            // tabPhone
            // 
            this.tabPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.tabPhone.ImageIndex = 0;
            this.tabPhone.Location = new System.Drawing.Point(4, 44);
            this.tabPhone.Name = "tabPhone";
            this.tabPhone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPhone.Size = new System.Drawing.Size(540, 338);
            this.tabPhone.TabIndex = 1;
            this.tabPhone.ToolTipText = "Phone Tools";
            // 
            // tabTest
            // 
            this.tabTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.tabTest.Controls.Add(this.listBox);
            this.tabTest.Controls.Add(this.listView);
            this.tabTest.Controls.Add(this.btnTest);
            this.tabTest.Location = new System.Drawing.Point(4, 44);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(540, 338);
            this.tabTest.TabIndex = 2;
            this.tabTest.Text = "Test";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(54, 173);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(432, 134);
            this.listBox.TabIndex = 19;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.Location = new System.Drawing.Point(54, 53);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(432, 114);
            this.listView.TabIndex = 18;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // btnTest
            // 
            this.btnTest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(218)))));
            this.btnTest.FlatAppearance.BorderSize = 2;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTest.Location = new System.Drawing.Point(91, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(93, 35);
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnPopulate
            // 
            this.btnPopulate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(218)))));
            this.btnPopulate.FlatAppearance.BorderSize = 2;
            this.btnPopulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopulate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPopulate.Location = new System.Drawing.Point(368, 19);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(93, 36);
            this.btnPopulate.TabIndex = 14;
            this.btnPopulate.Text = "populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 510);
            this.Controls.Add(this.tabBar);
            this.Controls.Add(this.panelHead);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.panelHead.ResumeLayout(false);
            this.tabBar.ResumeLayout(false);
            this.tabEmail.ResumeLayout(false);
            this.tabEmail.PerformLayout();
            this.tabTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Label lblPullContacts;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TabControl tabBar;
        private System.Windows.Forms.TabPage tabEmail;
        private System.Windows.Forms.RadioButton radKnowBe4;
        private System.Windows.Forms.RadioButton radInsight;
        private System.Windows.Forms.Button btnCopyClipboard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPayloadPicker;
        private System.Windows.Forms.TabPage tabPhone;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label labeltest;
        private System.Windows.Forms.Button btnPopulate;
    }
}