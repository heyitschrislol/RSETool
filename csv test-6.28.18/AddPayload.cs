using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Trace_RSE_Tool
{
    public partial class AddPayload : Form
    {
        public AddPayload()
        {
            InitializeComponent();
        }

        private void btnAddPayload_Click(object sender, EventArgs e)
        {
            try
            {
                if (radInsight.Checked && !String.IsNullOrWhiteSpace(txtPayloadName.Text) && !String.IsNullOrWhiteSpace(rtxtAddPayload.Text))
                {
                    string[] lines = rtxtAddPayload.Lines;
                    string newpayload = Path.Combine(@"insightpayloads\", txtPayloadName.Text.ToString() + ".txt");
                    using (StreamWriter newfile = new StreamWriter(newpayload))
                    {
                        foreach (string line in lines)
                        {
                            newfile.WriteLine(line.ToString());
                        }
                    }
                }
                else if (radKnowBe4.Checked && !String.IsNullOrWhiteSpace(txtPayloadName.Text) && !String.IsNullOrWhiteSpace(rtxtAddPayload.Text))
                {
                    string[] lines = rtxtAddPayload.Lines;
                    string newpayload = Path.Combine(@"knowbe4payloads\", txtPayloadName.Text.ToString() + ".txt");
                    using (StreamWriter newfile = new StreamWriter(newpayload))
                    {                        
                        foreach (string line in lines)
                        {
                            newfile.WriteLine(line.ToString());
                        }
                    }
                }
                lblResult.Visible = true;
                lblResult.ForeColor = System.Drawing.Color.Lime;
                lblResult.Text = "New payload added";
            }
            catch
            {
                lblResult.Visible = false;
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Failed to add new payload";
            }
            
        }

        private void radInsight_CheckedChanged(object sender, EventArgs e)
        {
            if (radInsight.Checked && !String.IsNullOrWhiteSpace(txtPayloadName.Text) && !String.IsNullOrWhiteSpace(rtxtAddPayload.Text))
            {
                btnAddPayload.Enabled = true;
                btnAddPayload.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                btnAddPayload.ForeColor = System.Drawing.Color.White;
            }
            else if (radKnowBe4.Checked && !String.IsNullOrWhiteSpace(txtPayloadName.Text) && !String.IsNullOrWhiteSpace(rtxtAddPayload.Text))
            {
                btnAddPayload.Enabled = true;
                btnAddPayload.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                btnAddPayload.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                btnAddPayload.Enabled = false;
                btnAddPayload.BackColor = System.Drawing.Color.Gray;
                btnAddPayload.ForeColor = System.Drawing.Color.LightGray;
            }
        }

        private void radKnowBe4_CheckedChanged(object sender, EventArgs e)
        {
            if (radInsight.Checked && !String.IsNullOrWhiteSpace(txtPayloadName.Text) && !String.IsNullOrWhiteSpace(rtxtAddPayload.Text))
            {
                btnAddPayload.Enabled = true;
                btnAddPayload.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                btnAddPayload.ForeColor = System.Drawing.Color.White;
            }
            else if (radKnowBe4.Checked && !String.IsNullOrWhiteSpace(txtPayloadName.Text) && !String.IsNullOrWhiteSpace(rtxtAddPayload.Text))
            {
                btnAddPayload.Enabled = true;
                btnAddPayload.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                btnAddPayload.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                btnAddPayload.Enabled = false;
                btnAddPayload.BackColor = System.Drawing.Color.Gray;
                btnAddPayload.ForeColor = System.Drawing.Color.LightGray;
            }
        }
    }
}
