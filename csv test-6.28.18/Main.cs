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
using ExcelDataReader;

namespace Trace_RSE_Tool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public DataTable dataTable;
        StreamReader streamer;
        string contactpath = string.Empty;
        string reportpath = string.Empty;
        string path = string.Empty;
        string itemText = string.Empty;
        string fileType = string.Empty;

        private void Main_Load(object sender, EventArgs e)
        {

        }       

        // **METHOD THAT OPENS FILE EXPLORER AND FOCUSES THE NEWLY SAVED ITEM BY THE USER
        private void OpenFolder(string folderPath)
        {
            if (File.Exists(folderPath))
            {
                Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + folderPath));
            }
        }

        // ***************************************************************************************************************************************************************
        // ***************************************************************************************************************************************************************
        // ********-----------------------------------------------------------------------------------------------------------------------------------------------********
        // ********--------------------------------------------C S V    S T U F F---------------------------------------------------------------------------------********
        // ********-----------------------------------------------------------------------------------------------------------------------------------------------********
        // ***************************************************************************************************************************************************************
        // ***************************************************************************************************************************************************************

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ToolTip toolOpenFile = new ToolTip();
            toolOpenFile.ShowAlways = true;
            toolOpenFile.SetToolTip(btnOpenFile, "Open Scoping Form");
            try
            {
                OpenFileDialog openFile = new OpenFileDialog() { Filter = "Word Document|*.doc;*.docx", ValidateNames = true };
                DialogResult result = openFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //set fileType as Word and then create the Data Table that will be displayed in the preview window and store the Data Table into the class variable dataTable
                    fileType = "Word";
                    contactpath = openFile.FileName;
                    dataTable = wordDocToDataTable(contactpath);

                    btnPreview.Visible = true;
                    btnPreview2.Visible = false;
                    btnInsightCSV.Enabled = true;
                    btnKnowbe4CSV.Enabled = true;
                    txtUserGroup.Enabled = true;
                    btnCreateCallList.Enabled = true;
                    txtUserGroup.BackColor = System.Drawing.Color.White;
                    btnInsightCSV.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                    btnInsightCSV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 184, 218);
                    btnInsightCSV.ForeColor = System.Drawing.Color.White;
                    btnKnowbe4CSV.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                    btnKnowbe4CSV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 184, 218);
                    btnKnowbe4CSV.ForeColor = System.Drawing.Color.White;
                    btnCreateCallList.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                    btnCreateCallList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 184, 218);
                    btnCreateCallList.ForeColor = System.Drawing.Color.White;
                    lblPullContacts.Left = 3;
                    lblPullContacts.Top = 70;
                    lblPullContacts.Visible = true;
                    lblPullContacts.ForeColor = System.Drawing.Color.Lime;
                    lblPullContacts.Text = "Success extracting data";
                }

            }
            catch
            {
                btnPreview.Visible = false;
                btnPreview2.Visible = false;
                btnInsightCSV.Enabled = false;
                btnKnowbe4CSV.Enabled = false;
                txtUserGroup.Enabled = false;
                btnCreateCallList.Enabled = false;
                txtUserGroup.BackColor = System.Drawing.Color.Gray;
                btnInsightCSV.BackColor = System.Drawing.Color.Gray;
                btnInsightCSV.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
                btnInsightCSV.ForeColor = System.Drawing.Color.LightGray;
                btnKnowbe4CSV.BackColor = System.Drawing.Color.Gray;
                btnKnowbe4CSV.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
                btnKnowbe4CSV.ForeColor = System.Drawing.Color.LightGray;
                btnCreateCallList.BackColor = System.Drawing.Color.Gray;
                btnCreateCallList.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
                btnCreateCallList.ForeColor = System.Drawing.Color.LightGray;
                lblPullContacts.Left = 3;
                lblPullContacts.Top = 70;
                lblPullContacts.Visible = true;
                lblPullContacts.ForeColor = System.Drawing.Color.Red;
                lblPullContacts.Text = "Failed extracting data";
                MessageBox.Show("The file could not be loaded");
            }
        }

        //import excel workbooks to get employee contact info 
        private void btnOpenExcelFile_Click(object sender, EventArgs e)
        {
            ToolTip toolOpenFile = new ToolTip();
            toolOpenFile.ShowAlways = true;
            toolOpenFile.SetToolTip(btnOpenExcelFile, "Open Excel Sheet");
            try
            {
                OpenFileDialog openFile = new OpenFileDialog() { Filter = "Excel Workbook|*.xls;*.xlsx;*.csv", ValidateNames = true };                
                DialogResult result = openFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //set fileType as Excel and then create the Data Table that will be displayed in the preview window and store the Data Table into the class variable dataTable
                    fileType = "Excel";
                    contactpath = openFile.FileName;
                    dataTable = excelSheetToDataTable(contactpath);

                    btnPreview2.Visible = true;
                    btnPreview.Visible = false;
                    btnInsightCSV.Enabled = true;
                    btnKnowbe4CSV.Enabled = true;
                    txtUserGroup.Enabled = true;
                    btnCreateCallList.Enabled = true;
                    txtUserGroup.BackColor = System.Drawing.Color.White;
                    btnInsightCSV.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                    btnInsightCSV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 184, 218);
                    btnInsightCSV.ForeColor = System.Drawing.Color.White;
                    btnKnowbe4CSV.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                    btnKnowbe4CSV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 184, 218);
                    btnKnowbe4CSV.ForeColor = System.Drawing.Color.White;
                    btnCreateCallList.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
                    btnCreateCallList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 184, 218);
                    btnCreateCallList.ForeColor = System.Drawing.Color.White;
                    lblPullContacts.Left = 213;
                    lblPullContacts.Top = 68;
                    lblPullContacts.Visible = true;
                    lblPullContacts.ForeColor = System.Drawing.Color.Lime;
                    lblPullContacts.Text = "Success extracting data";                   
                }

            }
            catch
            {
                btnPreview2.Visible = false;
                btnPreview.Visible = false;
                btnInsightCSV.Enabled = false;
                btnKnowbe4CSV.Enabled = false;
                txtUserGroup.Enabled = false;
                btnCreateCallList.Enabled = false;
                txtUserGroup.BackColor = System.Drawing.Color.Gray;
                btnInsightCSV.BackColor = System.Drawing.Color.Gray;
                btnInsightCSV.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
                btnInsightCSV.ForeColor = System.Drawing.Color.LightGray;
                btnKnowbe4CSV.BackColor = System.Drawing.Color.Gray;
                btnKnowbe4CSV.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
                btnKnowbe4CSV.ForeColor = System.Drawing.Color.LightGray;
                btnCreateCallList.BackColor = System.Drawing.Color.Gray;
                btnCreateCallList.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
                btnCreateCallList.ForeColor = System.Drawing.Color.LightGray;
                lblPullContacts.Left = 213;
                lblPullContacts.Top = 68;
                lblPullContacts.Visible = true;
                lblPullContacts.ForeColor = System.Drawing.Color.Red;
                lblPullContacts.Text = "Failed extracting data";
                MessageBox.Show("The file could not be loaded");
            }
        }

        //converts a Word Document Scoping form into a Data Table
        private DataTable wordDocToDataTable(string filePath)
        {
            Read displayData = new Read();
            displayData.NameFile = filePath;
            string[] copyHeader = displayData.WordTableHeader();
            string[,] displayArray = displayData.WordDoc();
            DataTable result = new DataTable();
            for (int i = 0; i < copyHeader.Length; i++)
            {
                result.Columns.Add(copyHeader[i], typeof(String));
            }

            for (int i = 0; i < (displayArray.Length / copyHeader.Length); i++)
            {
                DataRow row = result.NewRow();
                for (int j = 0; j < copyHeader.Length; j++)
                {
                    row[copyHeader[j]] = displayArray[i, j];
                }
                result.Rows.Add(row);
            }
            return result;
        }

        //converts a Excel Workbook Scoping form into a Data Table
        private DataTable excelSheetToDataTable(string filePath)
        {
            var file = new FileInfo(filePath);
            IExcelDataReader reader;
            FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read);
            if (file.Extension.Equals(".xls"))
                reader = ExcelReaderFactory.CreateBinaryReader(fs);
            else if (file.Extension.Equals(".xlsx"))
                reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            else if (file.Extension.Equals(".csv"))
                reader = ExcelReaderFactory.CreateCsvReader(fs);
            else
                throw new Exception("Invalid FileName");

            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };

            var dataSet = reader.AsDataSet(conf);
            var dt = dataSet.Tables[0];
            reader.Close();

            List<string> initialHeaders = new List<string>();
            foreach (DataColumn column in dt.Columns)
            {
                initialHeaders.Add(column.ColumnName);
            }
            int firstNameColumn = -1;
            int lastNameColumn = -1;
            string firstNameColumnName = null;
            string lastNameColumnName = null;
            for (int i = 0; i < initialHeaders.Count; i++)
            {
                if (initialHeaders[i].ToLower().Contains("first"))
                {
                    firstNameColumn = i;
                    firstNameColumnName = initialHeaders[i];
                }
                else if (initialHeaders[i].ToLower().Contains("last"))
                {
                    lastNameColumn = i;
                    lastNameColumnName = initialHeaders[i];
                }
            }

            DataTable result = new DataTable();
            List<String> headers = new List<String>();
            if (firstNameColumn != -1 & lastNameColumn != -1)
            {
                result.Columns.Add("Name", typeof(String));
                foreach (DataColumn column in dt.Columns)
                {
                    if (!column.ColumnName.Equals(firstNameColumnName) & !column.ColumnName.Equals(lastNameColumnName))
                    {
                        result.Columns.Add(column.ColumnName, typeof(String));
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow row = result.NewRow();
                    row["Name"] = dr[firstNameColumnName].ToString() + " " + dr[lastNameColumnName];
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (!column.ColumnName.Equals(firstNameColumnName) & !column.ColumnName.Equals(lastNameColumnName))
                        {
                            row[column.ColumnName] = dr[column.ColumnName];
                        }
                    }
                    result.Rows.Add(row);
                }
                foreach (DataColumn column in result.Columns)
                {
                    headers.Add(column.ColumnName);
                }
            }
            else
            {
                result = dt;
                headers = initialHeaders;
            }
            return result;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ToolTip toolPreview = new ToolTip();
            toolPreview.ShowAlways = false;
            toolPreview.SetToolTip(btnPreview, "Preview Extracted Data");
            Preview newpreview = new Preview();
            newpreview.dataTable = dataTable;
            newpreview.ShowDialog();
        }

        private void btnPreview2_Click(object sender, EventArgs e)
        {
            ToolTip toolPreview = new ToolTip();
            toolPreview.ShowAlways = false;
            toolPreview.SetToolTip(btnPreview, "Preview Extracted Data");
            Preview newpreview = new Preview();
            newpreview.dataTable = dataTable;
            newpreview.ShowDialog();
        }
// ****************************************************************************************************************************************************************************************************
// ****************************************************************************************************************************************************************************************************
// ********------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------********
// ********-----------------------------------------------------------------C R E A T E   C S V   F I L E   S T U F F--------------------------------------------------------------------------********
// ********------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------********
// ****************************************************************************************************************************************************************************************************
// ****************************************************************************************************************************************************************************************************

        private void btnInsightCSV_Click(object sender, EventArgs e)
        {
            string userGroup = txtUserGroup.Text.ToString();
            Read reading = new Read();

            //   __________________________
            // ||__________________________||
            // ||                          ||
            // ||   W O R D   V A L U E S  ||
            // ||__________________________||
            // ||__________________________||
            if (fileType == "Word")
            {
                reading.NameFile = contactpath;
                // CREATE AN ARRAY TO HOLD HEADER VALUES FROM FILE
                string[] copyHeader = reading.WordTableHeader();
                // CREATE AN ARRAY TO HOLD DATA VALUES FROM FILE
                string[,] copyData = reading.WordDoc();
                // CREATE INDEXES FOR # OF ROWS AND # OF COLUMNS
                int rowcount = reading.RowNum;
                int colcount = reading.ColNum;
                // CREATE AN ARRAY TO PLACE DATA VALUES IN DESIRED ORDER
                string[,] reorderData = new string[rowcount, 7];
                try
                {
                    for (int i = 0; i < rowcount; i++)
                    {
                        for (int j = 0; j < colcount; j++)
                        {
                            //   __________________________
                            // ||                          ||
                            // ||  B L A N K   V A L U E S ||
                            // ||__________________________||
                            // SET MIDDLE NAME VALUE
                            reorderData[i, 1] = " ";
                            // SET USERGROUP VALUE
                            if (!String.IsNullOrWhiteSpace(userGroup))
                            {
                                reorderData[i, 6] = userGroup;
                            }
                            else
                            {
                                reorderData[i, 6] = " ";
                            }
                            // SET FIRST NAME VALUE
                            if (copyHeader[j].Contains("first"))
                            {
                                reorderData[i, 0] = copyData[i, j];
                            }
                            // SET LAST NAME VALUE
                            else if (copyHeader[j].Contains("last"))
                            {
                                reorderData[i, 2] = copyData[i, j];
                            }
                            // SET TITLE VALUE
                            else if (copyHeader[j].Contains("title"))
                            {
                                reorderData[i, 3] = copyData[i, j];
                            }
                            // SET PHONE NUMBER VALUE
                            else if (copyHeader[j].Contains("phone"))
                            {
                                reorderData[i, 4] = copyData[i, j];
                            }
                            // SET EMAIL ADDRESS VALUE
                            else if (copyHeader[j].Contains("email"))
                            {
                                reorderData[i, 5] = copyData[i, j];
                            }
                            else
                            {

                            }
                        }
                    }
                    string thisfile = String.Empty;
                    // CREATE A FILE SAVE DIALOG WITH DESIRED FILE FORMAT AND EXTENSION
                    SaveFileDialog fileStream = new SaveFileDialog();
                    fileStream.FileName = "insightupload.csv";
                    fileStream.DefaultExt = ".csv";
                    fileStream.Filter = "Comma Separated files (*.csv)|*.csv";
                    // DISPLAY THE CREATE FILE SAVE DIALOG BOX TO THE USER
                    DialogResult result = fileStream.ShowDialog();
                    // OBTAIN THE SAVE FILE NAME/LOCATION FROM USER INPUT  
                    if (result == DialogResult.OK)
                    {
                        thisfile = fileStream.FileName;
                    }
                    // CALL CREATE CLASS AND ASSIGN VALUES FOR READ FILE, SAVE FILE, AND PROPERLY-ORDERED DATA
                    Create makeFile = new Create(fileType, contactpath, thisfile, reorderData);
                    // CALL CREATE CLASS'S CSV-MAKING METHOD
                    makeFile.InsightUpload();
                    OpenFolder(thisfile);
                }
                catch
                {
                    MessageBox.Show("Unable to export data to file properly.");
                }
            }

            //   __________________________
            // ||__________________________||
            // ||                          ||
            // ||  E X C E L   V A L U E S ||
            // ||__________________________||
            // ||__________________________||
            else if (fileType == "Excel")
            {
                reading.NameFile = contactpath;
                // CREATE AN ARRAY TO HOLD HEADER VALUES FROM FILE
                string[] copyHeader = reading.ExcelTableHeader();
                // CREATE AN ARRAY TO HOLD DATA VALUES FROM FILE
                string[,] copyData = reading.ExcelDoc();
                // CREATE INDEXES FOR # OF ROWS AND # OF COLUMNS
                int rowcount = reading.RowNum;
                int colcount = reading.ColNum;
                // CREATE AN ARRAY TO PLACE DATA VALUES IN DESIRED ORDER
                string[,] reorderData = new string[rowcount, 7];

                               
                try
                {
                    for (int i = 0; i < rowcount; i++)
                    {
                        for (int j = 0; j < colcount; j++)
                        {
                            //   __________________________
                            // ||                          ||
                            // ||  B L A N K   V A L U E S ||
                            // ||__________________________||
                            // SET MIDDLE NAME VALUE
                            reorderData[i, 1] = " ";
                            // SET USERGROUP VALUE
                            if (!String.IsNullOrWhiteSpace(userGroup))
                            {
                                reorderData[i, 6] = userGroup;
                            }
                            else
                            {
                                reorderData[i, 6] = " ";
                            }
                            // SET FIRST NAME VALUE
                            if (copyHeader[j].Contains("first"))
                            {
                                reorderData[i, 0] = copyData[i, j];
                            }
                            // SET LAST NAME VALUE
                            else if (copyHeader[j].Contains("last"))
                            {
                                reorderData[i, 2] = copyData[i, j];
                            }
                            // SET TITLE VALUE
                            else if (copyHeader[j].Contains("title"))
                            {
                                reorderData[i, 3] = copyData[i, j];
                            }
                            // SET PHONE NUMBER VALUE
                            else if (copyHeader[j].Contains("phone"))
                            {
                                reorderData[i, 4] = copyData[i, j];
                            }
                            // SET EMAIL ADDRESS VALUE
                            else if (copyHeader[j].Contains("email"))
                            {
                                reorderData[i, 5] = copyData[i, j];
                            }
                            else
                            {

                            }
                        }
                    }
                    string thisfile = String.Empty;
                    // CREATE A FILE SAVE DIALOG WITH DESIRED FILE FORMAT AND EXTENSION
                    SaveFileDialog fileStream = new SaveFileDialog();
                    fileStream.FileName = "insightupload.csv";
                    fileStream.DefaultExt = ".csv";
                    fileStream.Filter = "Comma Separated files (*.csv)|*.csv";
                    // DISPLAY THE CREATE FILE SAVE DIALOG BOX TO THE USER
                    DialogResult result = fileStream.ShowDialog();
                    // OBTAIN THE SAVE FILE NAME/LOCATION FROM USER INPUT  
                    if (result == DialogResult.OK)
                    {
                        thisfile = fileStream.FileName;
                    }
                    // CALL CREATE CLASS AND ASSIGN VALUES FOR READ FILE, SAVE FILE, AND PROPERLY-ORDERED DATA
                    Create makeFile = new Create(fileType, contactpath, thisfile, reorderData);
                    // CALL CREATE CLASS'S CSV-MAKING METHOD
                    makeFile.InsightUpload();
                    OpenFolder(thisfile);

                }
                catch
                {
                    MessageBox.Show("Unable to export data to file properly.");
                }
            }
            

        }
        private void btnKnowbe4CSV_Click(object sender, EventArgs e)
        {
            string userGroup = txtUserGroup.Text.ToString();
            Read reading = new Read();

            //   __________________________
            // ||__________________________||
            // ||                          ||
            // ||   W O R D   V A L U E S  ||
            // ||__________________________||
            // ||__________________________||
            if (fileType == "Word")
            {
                reading.NameFile = contactpath;
                // CREATE AN ARRAY TO HOLD HEADER VALUES FROM FILE
                string[] copyHeader = reading.WordTableHeader();
                // CREATE AN ARRAY TO HOLD DATA VALUES FROM FILE
                string[,] copyData = reading.WordDoc();
                // CREATE INDEXES FOR # OF ROWS AND # OF COLUMNS
                int rowcount = reading.RowNum;
                int colcount = reading.ColNum;
                // CREATE AN ARRAY TO PLACE DATA VALUES IN DESIRED ORDER
                string[,] reorderData = new string[rowcount, 15];
                try
                {
                    for (int i = 0; i < rowcount; i++)
                    {
                        for (int j = 0; j < colcount; j++)
                        {
                            //   __________________________
                            // ||                          ||
                            // ||  B L A N K   V A L U E S ||
                            // ||__________________________||
                            // SET LOCATION VALUE
                            reorderData[i, 6] = " ";
                            // SET DIVISION VALUE
                            reorderData[i, 7] = " ";
                            // SET MANAGER NAME VALUE
                            reorderData[i, 8] = " ";
                            // SET MANAGER EMAIL VALUE
                            reorderData[i, 9] = " ";
                            // SET EMPLOYEE NUMBER VALUE
                            reorderData[i, 10] = " ";
                            // SET PASSWORD VALUE
                            reorderData[i, 12] = " ";
                            // SET MOBILE NUMBER VALUE
                            reorderData[i, 13] = " ";
                            // SET AD MANAGED VALUE
                            reorderData[i, 14] = " ";
                            // SET USERGROUP VALUE
                            if (!String.IsNullOrWhiteSpace(userGroup))
                            {
                                reorderData[i, 5] = userGroup;
                            }
                            else
                            {
                                reorderData[i, 5] = " ";
                            }
                            // SET EMAIL VALUE
                            if (copyHeader[j].Contains("email"))
                            {
                                reorderData[i, 0] = copyData[i, j];
                            }
                            // SET FIRST NAME VALUE
                            else if (copyHeader[j].Contains("first"))
                            {
                                reorderData[i, 1] = copyData[i, j];
                            }
                            // SET LAST NAME VALUE
                            else if (copyHeader[j].Contains("last"))
                            {
                                reorderData[i, 2] = copyData[i, j];
                            }
                            // SET PHONE NUMBER VALUE
                            else if (copyHeader[j].Contains("phone"))
                            {
                                reorderData[i, 3] = copyData[i, j];
                            }
                            // SET EXTENSION VALUE
                            else if (copyHeader[j].Contains("ext") || copyHeader[j].Contains("extension"))
                            {
                                reorderData[i, 4] = copyData[i, j];
                            }
                            // SET TITLE VALUE
                            else if (copyHeader[j].Contains("title"))
                            {
                                reorderData[i, 11] = copyData[i, j];
                            }
                            else
                            {

                            }
                        }
                    }
                    string thisfile = String.Empty;
                    // CREATE A FILE SAVE DIALOG WITH DESIRED FILE FORMAT AND EXTENSION
                    SaveFileDialog fileStream = new SaveFileDialog();
                    fileStream.FileName = "resellerupload.csv";
                    fileStream.DefaultExt = ".csv";
                    fileStream.Filter = "Comma Separated files (*.csv)|*.csv";
                    // DISPLAY THE CREATE FILE SAVE DIALOG BOX TO THE USER
                    DialogResult result = fileStream.ShowDialog();
                    // OBTAIN THE SAVE FILE NAME/LOCATION FROM USER INPUT  
                    if (result == DialogResult.OK)
                    {
                        thisfile = fileStream.FileName;
                    }
                    // CALL CREATE CLASS AND ASSIGN VALUES FOR READ FILE, SAVE FILE, AND PROPERLY-ORDERED DATA
                    Create makeFile = new Create(fileType, contactpath, thisfile, reorderData);
                    // CALL CREATE CLASS'S CSV-MAKING METHOD
                    makeFile.ResellerUpload();
                    OpenFolder(thisfile);
                }
                catch
                {
                    MessageBox.Show("Unable to export data to file properly.");
                }
            }
            //   __________________________
            // ||__________________________||
            // ||                          ||
            // ||  E X C E L   V A L U E S ||
            // ||__________________________||
            // ||__________________________||
            else if (fileType == "Excel")
            {
                reading.NameFile = contactpath;
                // CREATE AN ARRAY TO HOLD HEADER VALUES FROM FILE
                string[] copyHeader = reading.ExcelTableHeader();
                // CREATE AN ARRAY TO HOLD DATA VALUES FROM FILE
                string[,] copyData = reading.ExcelDoc();
                // CREATE INDEXES FOR # OF ROWS AND # OF COLUMNS
                int rowcount = reading.RowNum;
                int colcount = reading.ColNum;
                // CREATE AN ARRAY TO PLACE DATA VALUES IN DESIRED ORDER
                string[,] reorderData = new string[rowcount, 15];

                try
                {
                    for (int i = 0; i < rowcount; i++)
                    {
                        for (int j = 0; j < colcount; j++)
                        {
                            //   __________________________
                            // ||                          ||
                            // ||  B L A N K   V A L U E S ||
                            // ||__________________________||
                            // SET LOCATION VALUE
                            reorderData[i, 6] = " ";
                            // SET DIVISION VALUE
                            reorderData[i, 7] = " ";
                            // SET MANAGER NAME VALUE
                            reorderData[i, 8] = " ";
                            // SET MANAGER EMAIL VALUE
                            reorderData[i, 9] = " ";
                            // SET EMPLOYEE NUMBER VALUE
                            reorderData[i, 10] = " ";
                            // SET PASSWORD VALUE
                            reorderData[i, 12] = " ";
                            // SET MOBILE NUMBER VALUE
                            reorderData[i, 13] = " ";
                            // SET AD MANAGED VALUE
                            reorderData[i, 14] = " ";
                            // SET USERGROUP VALUE
                            if (!String.IsNullOrWhiteSpace(userGroup))
                            {
                                reorderData[i, 5] = userGroup;
                            }
                            else
                            {
                                reorderData[i, 5] = " ";
                            }
                            // SET EMAIL VALUE
                            if (copyHeader[j].Contains("email"))
                            {
                                reorderData[i, 0] = copyData[i, j];
                            }
                            // SET FIRST NAME VALUE
                            else if (copyHeader[j].Contains("first"))
                            {
                                reorderData[i, 1] = copyData[i, j];
                            }
                            // SET LAST NAME VALUE
                            else if (copyHeader[j].Contains("last"))
                            {
                                reorderData[i, 2] = copyData[i, j];
                            }
                            // SET PHONE NUMBER VALUE
                            else if (copyHeader[j].Contains("phone"))
                            {
                                reorderData[i, 3] = copyData[i, j];
                            }
                            // SET EXTENSION VALUE
                            else if (copyHeader[j].Contains("ext") || copyHeader[j].Contains("extension"))
                            {
                                reorderData[i, 4] = copyData[i, j];
                            }
                            // SET TITLE VALUE
                            else if (copyHeader[j].Contains("title"))
                            {
                                reorderData[i, 11] = copyData[i, j];
                            }
                            else
                            {

                            }
                        }
                    }

                    string thisfile = String.Empty;
                    // CREATE A FILE SAVE DIALOG WITH DESIRED FILE FORMAT AND EXTENSION
                    SaveFileDialog fileStream = new SaveFileDialog();
                    fileStream.FileName = "resellerupload.csv";
                    fileStream.DefaultExt = ".csv";
                    fileStream.Filter = "Comma Separated files (*.csv)|*.csv";
                    // DISPLAY THE CREATE FILE SAVE DIALOG BOX TO THE USER
                    DialogResult result = fileStream.ShowDialog();
                    // OBTAIN THE SAVE FILE NAME/LOCATION FROM USER INPUT  
                    if (result == DialogResult.OK)
                    {
                        thisfile = fileStream.FileName;
                    }
                    // CALL CREATE CLASS AND ASSIGN VALUES FOR READ FILE, SAVE FILE, AND PROPERLY-ORDERED DATA
                    Create makeFile = new Create(fileType, contactpath, thisfile, reorderData);
                    // CALL CREATE CLASS'S CSV-MAKING METHOD
                    makeFile.ResellerUpload();
                    OpenFolder(thisfile);
                }
                catch
                {
                    MessageBox.Show("Unable to export data to file properly.");
                }
            }
        }

// ****************************************************************************************************************************************************************************************************
// ****************************************************************************************************************************************************************************************************
// ********------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------********
// ********------------------------------------------------------------------------P A Y L O A D   S T U F F-----------------------------------------------------------------------------------********
// ********------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------********
// ****************************************************************************************************************************************************************************************************
// ****************************************************************************************************************************************************************************************************


        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            if (cboPayloadPicker.SelectedIndex != -1 && (radInsight.Checked || radKnowBe4.Checked))
            {
                FileStream payLoad = new FileStream(cboPayloadPicker.SelectedValue.ToString(), FileMode.Open, FileAccess.Read);
                streamer = new StreamReader(payLoad);
                itemText = streamer.ReadToEnd().ToString();
                Clipboard.SetText(itemText);
            }
        }

        private void radInsight_CheckedChanged(object sender, EventArgs e)
        {
            btnCopyClipboard.Enabled = true;
            cboPayloadPicker.Enabled = true;
            btnCopyClipboard.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
            btnCopyClipboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 184, 218);
            btnCopyClipboard.ForeColor = System.Drawing.Color.White;
            cboPayloadPicker.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
            cboPayloadPicker.ForeColor = System.Drawing.Color.White;
            if (radInsight.Checked)
            {
                string key = string.Empty;
                string value = string.Empty;
                int length = path.Length;

                List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
                path = @"insightpayloads\";
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    key = file.ToString();
                    string[] temp = file.ToString().Split('\\');
                    temp = temp[1].Split('.');
                    value = temp[0];
                    data.Add(new KeyValuePair<string, string>(key, value));
                }
                cboPayloadPicker.DataSource = null;
                cboPayloadPicker.Items.Clear();
                cboPayloadPicker.DataSource = new BindingSource(data, null);
                cboPayloadPicker.DisplayMember = "Value";
                cboPayloadPicker.ValueMember = "Key";
            }
        }

        private void radKnowBe4_CheckedChanged(object sender, EventArgs e)
        {
            btnCopyClipboard.Enabled = true;
            cboPayloadPicker.Enabled = true;
            btnCopyClipboard.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
            btnCopyClipboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 184, 218);
            btnCopyClipboard.ForeColor = System.Drawing.Color.White;
            cboPayloadPicker.BackColor = System.Drawing.Color.FromArgb(50, 60, 70);
            cboPayloadPicker.ForeColor = System.Drawing.Color.White;
            if (radKnowBe4.Checked)
            {
                string key = string.Empty;
                string value = string.Empty;
                int length = path.Length;

                List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
                path = @"knowbe4payloads\";
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    key = file.ToString();
                    string[] temp = file.ToString().Split('\\');
                    temp = temp[1].Split('.');
                    value = temp[0];
                    data.Add(new KeyValuePair<string, string>(key, value));
                }
                cboPayloadPicker.DataSource = null;
                cboPayloadPicker.Items.Clear();
                cboPayloadPicker.DataSource = new BindingSource(data, null);
                cboPayloadPicker.DisplayMember = "Value";
                cboPayloadPicker.ValueMember = "Key";
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPayload addPayload = new AddPayload();
            addPayload.ShowDialog();
        }

        private void btnReportShell_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Read reading = new Read();
            //    reading.NameFile = contactpath;
            //    // CREATE AN ARRAY TO HOLD HEADER VALUES FROM FILE
            //    string[] copyHeader = reading.WordTableHeader();
            //    // CREATE AN ARRAY TO HOLD DATA VALUES FROM FILE
            //    string[,] copyData = reading.WordDoc();
            //    // CREATE INDEXES FOR # OF ROWS AND # OF COLUMNS
            //    int rowcount = copyData.GetUpperBound(0) + 1;
            //    int colcount = copyData.GetUpperBound(1) + 1;
            //    // CREATE AN ARRAY TO PLACE DATA VALUES IN DESIRED ORDER
            //    string[,] filterData = new string[rowcount, 5];
            //    string[,] reorderedData = new string[rowcount, 4];
            //    for (int i = 0; i < rowcount; i++)
            //    {
            //        for (int j = 0; j < colcount; j++)
            //        {
            //            // SET FIRST NAME VALUE
            //            if (copyHeader[j].Contains("first"))
            //            {
            //                filterData[i, 0] = copyData[i, j];
            //            }
            //            // SET LAST NAME VALUE
            //            else if (copyHeader[j].Contains("last"))
            //            {
            //                filterData[i, 1] = copyData[i, j];
            //            }
            //            // SET PHONE NUMBER VALUE
            //            else if (copyHeader[j].Contains("phone"))
            //            {
            //                filterData[i, 2] = copyData[i, j];
            //            }
            //            // SET EXTENSION VALUE
            //            else if (copyHeader[j].Contains("ext"))
            //            {
            //                filterData[i, 3] = copyData[i, j];
            //            }
            //            // SET EMAIL ADDRESS VALUE
            //            else if (copyHeader[j].Contains("email"))
            //            {
            //                filterData[i, 4] = copyData[i, j];
            //            }
            //        }
            //    }
            //    for (int a = 0; a < filterData.GetUpperBound(0) + 1; a++)
            //    {
            //        reorderedData[a, 0] = filterData[a, 0] + " " + filterData[a, 1];
            //        for (int b = 1; b <= 4; b++)
            //        {
            //            reorderedData[a, b] = filterData[a, b];
            //        }
            //    }
            //    string saveFile = string.Empty;
            //    string tempFile = @"reports\RSE Vishing Report.docx";
            //    // CREATE A FILE SAVE DIALOG WITH DESIRED FILE FORMAT AND EXTENSION
            //    SaveFileDialog fileStream = new SaveFileDialog();
            //    fileStream.FileName = "RSE Vishing Report.docx";
            //    fileStream.DefaultExt = ".docx";
            //    fileStream.Filter = "Word Document File (*.docx)|*.docx";
            //    // DISPLAY THE CREATE FILE SAVE DIALOG BOX TO THE USER
            //    DialogResult result = fileStream.ShowDialog();
            //    // OBTAIN THE SAVE FILE NAME/LOCATION FROM USER INPUT  
            //    if (result == DialogResult.OK)
            //    {
            //        saveFile = fileStream.FileName;
            //    }
            //    // CALL CREATE CLASS AND ASSIGN VALUES FOR READ FILE, SAVE FILE, AND PROPERLY-ORDERED DATA
            //    Create makeFile = new Create();
            //    makeFile.ReportFile = tempFile;
            //    makeFile.PerfectArray = reorderedData;
            //    makeFile.SaveFile = saveFile;
            //    makeFile.MakeReport();
            //}

            //catch
            //{
            //    MessageBox.Show("Something went wrong");
            //}
        }


        // ####################################################################################################################################################################################################
        // ####################################################################################################################################################################################################
        // ###########################                                                                                                                                              ###########################
        // ###########################                                                            PHONE CALL TAB                                                                    ###########################
        // ###########################                                                                                                                                              ###########################
        // ####################################################################################################################################################################################################
        // ####################################################################################################################################################################################################

        //method that will create a new Excel Sheet that will be used when making calls to clients 
        private void btnCreateCallList_Click(object sender, EventArgs e)
        {
            NewCallList callList = new NewCallList();
            callList.dataTable = dataTable;
            callList.ShowDialog();
        }
    }
}
