using Dashujv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Window2 w1 = new Window2();
            //w1.ShowDialog();
            printDialog1.Document = printDocument1;
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", 140, 100);
            printDocument1.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            printDocument1.PrinterSettings.PrinterName = "ZDesigner GK888t";
            printDocument1.Print();
            //if (printDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            //    //将写好的格式给打印预览控件以便预览
            //    printPreviewDialog1.Document = printDocument1;
            //    //显示打印预览
            //    DialogResult result = printPreviewDialog1.ShowDialog();

            //    //printDocument1.DefaultPageSettings.PaperSize = pageSize;
            //   //printDocument1.Print();
            //}
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
          
            e.Graphics.DrawString("仓位:C01", new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 0, 60);
            e.Graphics.DrawString("批次:1404B03161", new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 0, 70);

        }
    }
}
