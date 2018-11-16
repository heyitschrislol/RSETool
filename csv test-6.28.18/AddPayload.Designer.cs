namespace Trace_RSE_Tool
{
    partial class AddPayload
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
            this.rtxtAddPayload = new System.Windows.Forms.RichTextBox();
            this.btnAddPayload = new System.Windows.Forms.Button();
            this.txtPayloadName = new System.Windows.Forms.TextBox();
            this.radKnowBe4 = new System.Windows.Forms.RadioButton();
            this.radInsight = new System.Windows.Forms.RadioButton();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtxtAddPayload
            // 
            this.rtxtAddPayload.BackColor = System.Drawing.Color.Gainsboro;
            this.rtxtAddPayload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtAddPayload.DetectUrls = false;
            this.rtxtAddPayload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.rtxtAddPayload.Location = new System.Drawing.Point(12, 12);
            this.rtxtAddPayload.Name = "rtxtAddPayload";
            this.rtxtAddPayload.Size = new System.Drawing.Size(837, 541);
            this.rtxtAddPayload.TabIndex = 0;
            this.rtxtAddPayload.Text = "";
            // 
            // btnAddPayload
            // 
            this.btnAddPayload.BackColor = System.Drawing.Color.Gray;
            this.btnAddPayload.Enabled = false;
            this.btnAddPayload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(184)))), ((int)(((byte)(218)))));
            this.btnAddPayload.FlatAppearance.BorderSize = 2;
            this.btnAddPayload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPayload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayload.ForeColor = System.Drawing.Color.LightGray;
            this.btnAddPayload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPayload.ImageIndex = 7;
            this.btnAddPayload.Location = new System.Drawing.Point(497, 559);
            this.btnAddPayload.Name = "btnAddPayload";
            this.btnAddPayload.Size = new System.Drawing.Size(129, 65);
            this.btnAddPayload.TabIndex = 4;
            this.btnAddPayload.Text = "Add New Payload";
            this.btnAddPayload.UseVisualStyleBackColor = false;
            this.btnAddPayload.Click += new System.EventHandler(this.btnAddPayload_Click);
            // 
            // txtPayloadName
            // 
            this.txtPayloadName.Location = new System.Drawing.Point(233, 568);
            this.txtPayloadName.Name = "txtPayloadName";
            this.txtPayloadName.Size = new System.Drawing.Size(233, 20);
            this.txtPayloadName.TabIndex = 7;
            // 
            // radKnowBe4
            // 
            this.radKnowBe4.AutoSize = true;
            this.radKnowBe4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radKnowBe4.ForeColor = System.Drawing.Color.White;
            this.radKnowBe4.Location = new System.Drawing.Point(377, 594);
            this.radKnowBe4.Name = "radKnowBe4";
            this.radKnowBe4.Size = new System.Drawing.Size(78, 17);
            this.radKnowBe4.TabIndex = 14;
            this.radKnowBe4.TabStop = true;
            this.radKnowBe4.Text = "KnowBe4";
            this.radKnowBe4.UseVisualStyleBackColor = true;
            this.radKnowBe4.CheckedChanged += new System.EventHandler(this.radKnowBe4_CheckedChanged);
            // 
            // radInsight
            // 
            this.radInsight.AutoSize = true;
            this.radInsight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInsight.ForeColor = System.Drawing.Color.White;
            this.radInsight.Location = new System.Drawing.Point(266, 594);
            this.radInsight.Name = "radInsight";
            this.radInsight.Size = new System.Drawing.Size(63, 17);
            this.radInsight.TabIndex = 13;
            this.radInsight.TabStop = true;
            this.radInsight.Text = "Insight";
            this.radInsight.UseVisualStyleBackColor = true;
            this.radInsight.CheckedChanged += new System.EventHandler(this.radInsight_CheckedChanged);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(646, 559);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(203, 65);
            this.lblResult.TabIndex = 15;
            this.lblResult.Visible = false;
            // 
            // AddPayload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(861, 636);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.radKnowBe4);
            this.Controls.Add(this.radInsight);
            this.Controls.Add(this.txtPayloadName);
            this.Controls.Add(this.btnAddPayload);
            this.Controls.Add(this.rtxtAddPayload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddPayload";
            this.Text = "Add a Payload";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtAddPayload;
        private System.Windows.Forms.Button btnAddPayload;
        private System.Windows.Forms.TextBox txtPayloadName;
        private System.Windows.Forms.RadioButton radKnowBe4;
        private System.Windows.Forms.RadioButton radInsight;
        private System.Windows.Forms.Label lblResult;
    }
}