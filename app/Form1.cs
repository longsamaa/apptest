using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.file;
using app.content; 

namespace app
{
    public partial class Form1 : Form
    {
        public string filename;
        string filter = "*.out";
        string zero = "zero-point"; 
        public List<string> content = new List<string>(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void btnloadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "File output|" + filter; 
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                lblfileName.Text = filename; 
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            click(); 
        }

        private void click()
        {
            if (!string.IsNullOrEmpty(filename))
            {
                content = file.file.readFile(filename);
            }

            List<string> result = new List<string>();
            result = app.content.content.find(zero, content);

            foreach (string line in result)
            {
                rtbResult.Text += line + "\n";
            }
        }
    }
}
