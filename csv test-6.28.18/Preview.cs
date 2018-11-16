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
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }

        public DataTable dataTable { get; set; }

        private void Preview_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = dataTable;
        } //end of Preview Class
    }
}
