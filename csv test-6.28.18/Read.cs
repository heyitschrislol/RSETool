using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ExcelDataReader;

namespace Trace_RSE_Tool
{
    class Read
    {
        private string filePath;
        public int RowNum;
        public int ColNum;
        private string[] headerarray;
        private string[,] valuesArray;
        public Read()
        {
            filePath = String.Empty;
        }
        public Read(string pFilePath)
        {
            filePath = pFilePath;
        }
        public string NameFile
        {
            get { return filePath; }
            set { filePath = value; }
        }        


        //////////////////////////////////////////////////////////////////////
        //                                                                  //
        //                   WORD HEADER TEXT ARRAY[]                       //
        //                                                                  //
        //////////////////////////////////////////////////////////////////////
        public string[] WordTableHeader()
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, false))
            {
                int j = 0;
                int rowcount = 0;
                int colcount = 0;


                var parts = wordDocument.MainDocumentPart.Document.Descendants<Table>().LastOrDefault();
                var row = parts.Descendants<TableRow>().FirstOrDefault();
                foreach (var cell in row.Descendants<TableCell>())
                {
                    if (!String.IsNullOrWhiteSpace(cell.InnerText))
                    {
                        colcount++;
                    }
                }
                foreach (var rownum in parts.Descendants<TableRow>())
                {
                    if (!String.IsNullOrWhiteSpace(rownum.Descendants<TableCell>().First().InnerText))
                    {
                        rowcount++;
                    }
                }
                string[] headertext = new string[colcount];
                var headerrow = parts.Descendants<TableRow>().First();
                foreach (var cell in headerrow.Descendants<TableCell>())
                {
                    headertext.SetValue(cell.InnerText.ToLower(), j);
                    j++;
                }
                return headertext;
            }
        }

        //////////////////////////////////////////////////////////////////////
        //                                                                  //
        //                   EXCEL HEADER TEXT ARRAY[]                      //
        //                                                                  //
        //////////////////////////////////////////////////////////////////////
        public string[] ExcelTableHeader()
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
            int i = 0;
            string headertext = String.Empty;
            headerarray = new string[dt.Columns.Count];
            foreach (DataColumn column in dt.Columns)
            {
                headertext = column.ColumnName.ToLower();
                headerarray[i] = headertext;
                i++;
            }
            return headerarray;
        }

        //////////////////////////////////////////////////////////////////////
        //                                                                  //
        //                   WORD CONTACT VALUES ARRAY[,]                   //
        //                                                                  //
        //////////////////////////////////////////////////////////////////////
        public string[,] WordDoc()
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, false))
            {
                int i = 0;
                int j = 0;
                int k = 5;
                int rowcount = 0;
                int colcount = 0;

                var parts = wordDocument.MainDocumentPart.Document.Descendants<Table>().LastOrDefault();
                // COUNT THE NUMBER OF COLUMNS FROM SOURCE FILE AND ASSIGN THE # TO A VARIABLE
                var row = parts.Descendants<TableRow>().FirstOrDefault();
                foreach (var cell in row.Descendants<TableCell>())
                {
                    if (!String.IsNullOrWhiteSpace(cell.InnerText))
                    {
                        colcount++;
                    }
                }
                // COUNT THE NUMBER OF ROWS FROM SOURCE FILE AND ASSIGN THE # TO A VARIABLE
                foreach (var rownum in parts.Descendants<TableRow>())
                {
                    if (!String.IsNullOrWhiteSpace(rownum.Descendants<TableCell>().First().InnerText))
                    {
                        rowcount++;
                    }
                }
                RowNum = rowcount - 1;
                ColNum = colcount;
                string celltext = string.Empty;
                // CREATE A MULTIDIMENSIONAL ARRAY, USING THE ROW/COLUMN COUNT VARIABLES AS THE SIZE
                string[,] cellValues = new string[rowcount, colcount];
                if (parts != null)
                {
                    foreach (var node in parts.ChildElements)
                    {
                        if (node is TableRow)
                        {
                            if (parts.Descendants<TableRow>().ElementAt(0) != node)
                            {
                                if (!String.IsNullOrWhiteSpace(node.Descendants<TableCell>().FirstOrDefault().InnerText))
                                {
                                    j = 0;
                                    foreach (var cell in node.Descendants<TableCell>())
                                    {
                                        if (!String.IsNullOrWhiteSpace(cell.InnerText))
                                        {
                                            celltext = cell.InnerText.Trim();
                                            celltext.ToLower();
                                            cellValues[i, j] = celltext;
                                        }
                                        else
                                        {
                                            cellValues[i, j] = " ";
                                        }
                                        j++;
                                    }
                                    i++;
                                }
                            }
                        }
                    }
                }
                return cellValues;
            }
        }

        //////////////////////////////////////////////////////////////////////
        //                                                                  //
        //                   EXCEL CONTACT VALUES ARRAY[,]                  //
        //                                                                  //
        //////////////////////////////////////////////////////////////////////
        public string[,] ExcelDoc()
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
            int rowcount = 1;
            int colcount = dt.Columns.Count;
            int i = 0;
            int j = 0;
            string celltext = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                if (!row.IsNull(0))
                {
                    rowcount++;                    
                }
            }
            RowNum = rowcount - 1;
            ColNum = colcount;
            valuesArray = new string[rowcount, colcount];
            foreach (DataRow dr in dt.Rows)
            {
                j = 0;
                if (!dr.IsNull(0))
                {
                    foreach (object field in dr.ItemArray)
                    {
                        if (!String.IsNullOrWhiteSpace(field.ToString()))
                        {
                            celltext = field.ToString().Trim();
                            valuesArray[i, j] = celltext;
                        }
                        else
                        {
                            valuesArray[i, j] = " ";
                        }                        
                        j++;
                    }
                    i++;
                }                
            }
            return valuesArray;
        }
    }    
}
