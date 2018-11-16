using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data;

namespace Trace_RSE_Tool
{
    class Create
    {
        private string reportFile;
        private string readFile;
        private string saveFile;
        private string[,] perfectArray;
        public string fileType;
        public Create(string pFileType)
        {
            fileType = pFileType;
            readFile = String.Empty;
            saveFile = String.Empty;            
        }
        public Create(string pFileType, string pFile)
        {
            fileType = pFileType;
            readFile = pFile;
            saveFile = String.Empty;
        }
        public Create(string pFileType, string pFile, string pSave)
        {
            fileType = pFileType;
            readFile = pFile;
            saveFile = pSave;
        }
        public Create(string pFileType, string pFile, string pSave, string [,] pArray)
        {
            fileType = pFileType;
            readFile = pFile;
            saveFile = pSave;
            perfectArray = pArray;
        }
        public string ReadFile
        {
            get { return readFile; }
            set { readFile = value; }
        }
        public string ReportFile
        {
            get { return reportFile; }
            set { reportFile = value; }
        }
        public string SaveFile
        {
            get { return saveFile; }
            set { saveFile = value; }
        }
        public string[,] PerfectArray
        {
            get { return perfectArray; }
            set { perfectArray = value; }
        }        

        
        //|||||||||||||||||||||||||||||||
        //||----CONTACT UPLOAD--------|||
        //|||||||||||||||||||||||||||||||

        public void InsightUpload()
        {            
            Read readtowrite = new Read();
            readtowrite.NameFile = readFile;
            if (fileType == "Word")
            {
                int rownum = perfectArray.GetUpperBound(0) + 1;
                StreamWriter outputFile;
                outputFile = File.AppendText(saveFile);
                outputFile.WriteLine("{0},{1},{2},{3},{4},{5},{6}", "firstName", "middleName", "lastName", "title", "phone", "email", "userGroups");
                for (int i = 0; i < rownum; i++)
                {
                    outputFile.WriteLine("{0},{1},{2},{3},{4},{5},{6}", perfectArray[i, 0], perfectArray[i, 1], perfectArray[i, 2], perfectArray[i, 3], perfectArray[i, 4], perfectArray[i, 5], perfectArray[i, 6]);
                }
                outputFile.Close();
            }

            else if (fileType == "Excel")
            {
                int rownum = perfectArray.GetUpperBound(0) + 1;
                StreamWriter outputFile;
                outputFile = File.AppendText(saveFile);
                outputFile.WriteLine("{0},{1},{2},{3},{4},{5},{6}", "firstName", "middleName", "lastName", "title", "phone", "email", "userGroups");
                for (int i = 0; i < rownum; i++)
                {
                    outputFile.WriteLine("{0},{1},{2},{3},{4},{5},{6}", perfectArray[i, 0], perfectArray[i, 1], perfectArray[i, 2], perfectArray[i, 3], perfectArray[i, 4], perfectArray[i, 5], perfectArray[i, 6]);
                }
                outputFile.Close();
            }
            
        }
        public void ResellerUpload()
        {
            if (fileType == "Word")
            {
                Read readtowrite = new Read();
                readtowrite.NameFile = readFile;
                int rownum = perfectArray.GetUpperBound(0) + 1;
                StreamWriter outputFile;
                outputFile = File.AppendText(saveFile);
                outputFile.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", "Email", "First Name", "Last Name", "Phone Number", "Extension", "Group", "Location", "Division", "Manager Name", "Manager Email", "Employee Number", "Job Title", "Password", "Mobile", "AD Managed");
                for (int i = 0; i < rownum; i++)
                {
                    outputFile.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", perfectArray[i, 0], perfectArray[i, 1], perfectArray[i, 2], perfectArray[i, 3], perfectArray[i, 4], perfectArray[i, 5], perfectArray[i, 6], perfectArray[i, 7], perfectArray[i, 8], perfectArray[i, 9], perfectArray[i, 10], perfectArray[i, 11], perfectArray[i, 12], perfectArray[i, 13], perfectArray[i, 14]);
                }
                outputFile.Close();
            }

            else if (fileType == "Excel")
            {
                Read readtowrite = new Read();
                readtowrite.NameFile = readFile;
                int rownum = perfectArray.GetUpperBound(0) + 1;
                StreamWriter outputFile;
                outputFile = File.AppendText(saveFile);
                outputFile.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", "Email", "First Name", "Last Name", "Phone Number", "Extension", "Group", "Location", "Division", "Manager Name", "Manager Email", "Employee Number", "Job Title", "Password", "Mobile", "AD Managed");
                for (int i = 0; i < rownum; i++)
                {
                    outputFile.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", perfectArray[i, 0], perfectArray[i, 1], perfectArray[i, 2], perfectArray[i, 3], perfectArray[i, 4], perfectArray[i, 5], perfectArray[i, 6], perfectArray[i, 7], perfectArray[i, 8], perfectArray[i, 9], perfectArray[i, 10], perfectArray[i, 11], perfectArray[i, 12], perfectArray[i, 13], perfectArray[i, 14]);
                }
                outputFile.Close();
            }
                   
        }
        




        //|||||||||||||||||||||||||||||||
        //||||---GENERATE REPORT---||||||
        //|||||||||||||||||||||||||||||||
        public TableGrid Columns()
        {
            TableGrid tGrid = new TableGrid();
            GridColumn resColumn = new GridColumn() { Width = "1780" };
            GridColumn nameColumn = new GridColumn() { Width = "6230" };
            GridColumn phoneColumn = new GridColumn() { Width = "1590" };
            GridColumn extColumn = new GridColumn() { Width = "1320" };
            tGrid.Append(resColumn);
            tGrid.Append(nameColumn);
            tGrid.Append(phoneColumn);
            tGrid.Append(extColumn);
            return tGrid;
        }
        public TableRow HeaderRow()
        {
            TableCellProperties headerProps1 = new TableCellProperties();
            TableCellWidth headWidth1 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
            Shading headShade1 = new Shading() { Val = ShadingPatternValues.Clear, Color = "000000", Fill = "D9D9D9" };
            headerProps1.Append(headWidth1);
            headerProps1.Append(headShade1);
            TableCellProperties headerProps2 = new TableCellProperties();
            TableCellWidth headWidth2 = new TableCellWidth() { Width = "6230", Type = TableWidthUnitValues.Dxa };
            Shading headShade2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "000000", Fill = "D9D9D9" };
            headerProps2.Append(headWidth2);
            headerProps2.Append(headShade2);
            TableCellProperties headerProps3 = new TableCellProperties();
            TableCellWidth headWidth3 = new TableCellWidth() { Width = "1590", Type = TableWidthUnitValues.Dxa };
            Shading headShade3 = new Shading() { Val = ShadingPatternValues.Clear, Color = "000000", Fill = "D9D9D9" };
            headerProps3.Append(headWidth3);
            headerProps3.Append(headShade3);
            TableCellProperties headerProps4 = new TableCellProperties();
            TableCellWidth headWidth4 = new TableCellWidth() { Width = "1320", Type = TableWidthUnitValues.Dxa };
            Shading headShade4 = new Shading() { Val = ShadingPatternValues.Clear, Color = "000000", Fill = "D9D9D9" };
            headerProps4.Append(headWidth4);
            headerProps4.Append(headShade4);

            var hr = new TableRow();
            var hc1 = new TableCell();
            hc1.Append(headerProps1);
            hc1.Append(new Paragraph(new Run(new Text("Final Result"))));
            var hc2 = new TableCell();
            hc2.Append(headerProps2);
            hc2.Append(new Paragraph(new Run(new Text("Name"))));
            var hc3 = new TableCell();
            hc3.Append(headerProps3);
            hc3.Append(new Paragraph(new Run(new Text("Phone"))));
            var hc4 = new TableCell();
            hc4.Append(headerProps4);
            hc4.Append(new Paragraph(new Run(new Text("Ext."))));
            hr.Append(hc1);
            hr.Append(hc2);
            hr.Append(hc3);
            hr.Append(hc4);
            return hr;
        }
        public TableRow DatesRow()
        {
            // DATES ROW FORMATTING PROPERTIES
            TableCellProperties infoProps1 = new TableCellProperties();
            GridSpan infoSpan1 = new GridSpan() { Val = 4 };
            infoProps1.Append(infoSpan1);

            // DATES ROW
            var dater = new TableRow();
            var hc1 = new TableCell();
            hc1.Append(infoProps1);
            hc1.Append(new Paragraph(new Run(new Text("Dates:"))));
            dater.Append(hc1);

            return dater;
        }
        public TableRow DescriptionRow()
        {
            // DESCRIPTION ROW FORMATTING PROPERTIES
            TableCellProperties infoProps2 = new TableCellProperties();
            GridSpan infoSpan2 = new GridSpan() { Val = 4 };
            infoProps2.Append(infoSpan2);

            // DESCRIPTION ROW
            var descr = new TableRow();
            var dc1 = new TableCell();
            dc1.Append(infoProps2);
            dc1.Append(new Paragraph(new Run(new Text("Description:"))));
            descr.Append(dc1);

            return descr;
        }

        public void MakeReport(/*string client, string analyst, int type*/)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(reportFile, true))
            {
                var mainPart = wordDocument.MainDocumentPart.Document;
                Table testtable = new Table();
                TableProperties vishProps = new TableProperties();
                //****------ TABLE BORDERS
                TableBorders vishBorders = new TableBorders();
                TopBorder top = new TopBorder() { Val = BorderValues.Single, Color = "auto" };
                LeftBorder left = new LeftBorder() { Val = BorderValues.Single, Color = "auto" };
                RightBorder right = new RightBorder() { Val = BorderValues.Single, Color = "auto" };
                BottomBorder bottom = new BottomBorder() { Val = BorderValues.Single, Color = "auto" };
                InsideHorizontalBorder horizontal = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", };
                InsideVerticalBorder vertical = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto" };
                vishBorders.Append(top);
                vishBorders.Append(left);
                vishBorders.Append(right);
                vishBorders.Append(bottom);
                vishBorders.Append(horizontal);
                vishBorders.Append(vertical);

                //****------ TABLE STYLE
                StyleRunProperties stylerunprops = new StyleRunProperties();
                TablePositionProperties tableposprops = new TablePositionProperties() { VerticalAnchor = VerticalAnchorValues.Margin, HorizontalAnchor = HorizontalAnchorValues.Margin };

                RunFonts headResRunFonts = new RunFonts() { Ascii = "Arial" };
                FontSize fontSize = new FontSize() { Val = "9" };
                stylerunprops.Append(headResRunFonts, fontSize);
                TableStyle tableStyle = new TableStyle() { Val = "TableGrid" };
                TableWidth tableWidth = new TableWidth() { Width = "10920", Type = TableWidthUnitValues.Dxa };
                TableLook tableLook = new TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true };
                TableIndentation tableIndentation = new TableIndentation() { Width = -10, Type = TableWidthUnitValues.Dxa };
                vishProps.Append(vishBorders, stylerunprops, tableWidth, tableposprops, tableStyle, tableLook, tableIndentation);
                testtable.Append(Columns(), vishProps);
                int[] widthIndex = new int[4] { 1780, 6230, 1590, 1320 };
                int rows = perfectArray.GetUpperBound(0) + 1;
                int h = 0;
                for (int i = 0; i < rows; i++)
                {
                    testtable.Append(HeaderRow());
                    var datarow = new TableRow();
                    var result = new TableCell();
                    var name = new TableCell();
                    var phone = new TableCell();
                    var ext = new TableCell();
                    var par1 = new Paragraph(new Run(new Text(String.Empty)));
                    var par2 = new Paragraph(new Run(new Text(perfectArray[i, 0])));
                    var par3 = new Paragraph(new Run(new Text(perfectArray[i, 1])));
                    var par4 = new Paragraph(new Run(new Text(perfectArray[i, 2])));

                    result.Append(par1);
                    name.Append(par2);
                    phone.Append(par3);
                    ext.Append(par4);
                    datarow.Append(result, name, phone, ext);

                    testtable.Append(datarow);
                    testtable.Append(DatesRow());
                    testtable.Append(DescriptionRow());
                }                

                foreach (SdtBlock item in wordDocument.MainDocumentPart.Document.Body.Descendants<SdtBlock>().Where(e => e.Descendants<SdtAlias>().FirstOrDefault().Val == "PhoneTable"))
                {
                    item.InsertAfterSelf(testtable);
                }
                using (WordprocessingDocument newDocument = WordprocessingDocument.Create(saveFile, WordprocessingDocumentType.Document, true))
                {
                    var maindoc = newDocument.MainDocumentPart;
                    foreach (var parts in wordDocument.MainDocumentPart.Document.Descendants())
                    {
                        maindoc.Document.Append(parts);                        
                    }
                    newDocument.MainDocumentPart.Document.Save();
                }                
            }            
        }
    }
}
