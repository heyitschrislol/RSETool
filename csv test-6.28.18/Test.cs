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

namespace Trace_RSE_Tool
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        StreamReader streamer;
        string contactpath = string.Empty;
        string path = string.Empty;      
        string itemText = string.Empty;
        private void Test_Load(object sender, EventArgs e)
        {            
            //cboPayloadPicker.Items.AddRange(Directory.GetFiles(path));
        }

        private void cboPayloadPicker_SelectedIndexChanged(object sender, EventArgs e)
        {            
            
        }
        private void btnPopulate_Click(object sender, EventArgs e)
        {
            string key = string.Empty;
            string value = string.Empty;
            int length = path.Length;

            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            path = @"payloads\";
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                key = file.Remove(0, length).ToString();
                value = file.ToString();
                data.Add(new KeyValuePair<string, string>(key, value));
            }
            cboPayloadPicker.DataSource = null;
            cboPayloadPicker.Items.Clear();
            cboPayloadPicker.DataSource = new BindingSource(data, null);
            cboPayloadPicker.DisplayMember = "Value";
            cboPayloadPicker.ValueMember = "Key";
        }
        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            if (cboPayloadPicker.SelectedIndex != -1)
            {
                FileStream payLoad = new FileStream(cboPayloadPicker.SelectedValue.ToString(), FileMode.Open, FileAccess.Read);
                streamer = new StreamReader(payLoad);
                itemText = streamer.ReadToEnd().ToString();
                Clipboard.SetText(itemText);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                DialogResult result = openFile.ShowDialog();
                if (result == DialogResult.OK)
                {                   
                    lblPullContacts.Visible = true;
                    lblPullContacts.ForeColor = System.Drawing.Color.Lime;
                    lblPullContacts.Text = "Success extracting data";                    
                    contactpath = openFile.FileName;
                }

            }
            catch
            {               
                lblPullContacts.Visible = true;
                lblPullContacts.ForeColor = System.Drawing.Color.Red;
                lblPullContacts.Text = "Failed extracting data";
                MessageBox.Show("The file could not be loaded");
            }
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            //string userGroup = txtUserGroup.Text.ToString();
            //Read reading = new Read();
            //reading.NameFile = contactpath;
            //string[] copyHeader = reading.TableHeader();
            //string[,] copyData = reading.WordDoc();
            //int rowcount = copyData.GetUpperBound(0) + 1;
            //int colcount = copyData.GetUpperBound(1) + 1;
            //string[,] reorderData = new string[rowcount + 1, 7];
            //for (int i = 0; i < rowcount; i++)
            //{
            //    for (int j = 0; j < colcount; j++)
            //    {
            //        reorderData[i, 1] = "";
            //        if (!String.IsNullOrWhiteSpace(userGroup))
            //        {
            //            reorderData[i, 6] = userGroup;
            //        }
            //        else
            //        {
            //            reorderData[i, 6] = "";
            //        }

            //        if (copyHeader[j].Contains("first"))
            //        {
            //            reorderData[i, 0] = copyData[i, j];
            //        }
            //        else if (copyHeader[j].Contains("last"))
            //        {
            //            reorderData[i, 2] = copyData[i, j];
            //        }
            //        else if (copyHeader[j].Contains("title"))
            //        {
            //            reorderData[i, 3] = copyData[i, j];
            //        }
            //        else if (copyHeader[j].Contains("phone"))
            //        {
            //            reorderData[i, 4] = copyData[i, j];
            //        }
            //        else if (copyHeader[j].Contains("email"))
            //        {
            //            reorderData[i, 5] = copyData[i, j];
            //        }
            //        else
            //        {

            //        }
            //    }
            //}

            //Read reading = new Read();
            //reading.NameFile = contactpath;
            //string[] copyHeader = reading.TableHeader();
            //string[,] copyData = reading.WordDoc();


            //*************************
            // TEST VALUES TO LIST VIEW
            //*************************
            //int width = 0;
            //var columns = listView.Columns;
            //var items = listView.Items;
            //foreach (var index in copyHeader)
            //{
            //    width = index.Length;
            //    columns.Add(index, width);                
            //}
            //foreach (var data in copyData)
            //{
            //    width = data.Length;
            //    items.Add(data, width);
            //}

            //*************************
            // TEST VALUES TO LIST BOX 
            //*************************
            //foreach (var data in reorderData)
            //{
            //    if (!String.IsNullOrWhiteSpace(data))
            //    {
            //        listBox.Items.Add(data);
            //    }
            //    else
            //    {
            //        listBox.Items.Add(" ");
            //    }                
            //}
        }

        
    }    
}
