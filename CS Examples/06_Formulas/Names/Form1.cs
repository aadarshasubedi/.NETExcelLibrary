using System;
using System.Data.OleDb;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Spire.Xls;

namespace Spire.Xls.Sample
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// Required designer variable.
        /// </summary
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.btnRun = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(448, 56);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(72, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(528, 56);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "Close";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(571, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "The sample demonstrates how to define named cell references or ranges in excel wo" +
                "rkbook.";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(616, 94);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnRun);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spire.XLS sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void ExcelDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

        private void btnRun_Click(object sender, System.EventArgs e)
        {
            Workbook workbook = new Workbook();

            workbook.LoadFromFile(@"..\..\..\..\..\..\Data\MiscDataTable.xls");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.InsertRow(1, 2);
            sheet.Rows[0].RowHeight = 16;

            //Style
            sheet.Range["A1:B1"].Style.Font.IsBold = true;
            sheet.Range["A3:E3"].Style.KnownColor = ExcelColors.LightOrange;

            int index = 4;
            while (sheet.Range[String.Format("A{0}", index)].HasString)
            {
                sheet.Range[String.Format("A{0}:E{0}", index)].Style.KnownColor
                    = index % 2 == 0 ? ExcelColors.PaleBlue : ExcelColors.LightTurquoise;
                index++;
            }

            //define named cell ranges
            sheet.Names.Add("Countries", sheet[String.Format("A4:A{0}", index - 1)]);
            sheet.Names.Add("Cities", sheet[String.Format("B4:B{0}", index - 1)]);
            sheet.Names.Add("Continents", sheet[String.Format("C4:C{0}", index - 1)]);
            sheet.Names.Add("Area", sheet[String.Format("D4:D{0}", index - 1)]);
            sheet.Names.Add("Population", sheet[String.Format("E4:E{0}", index - 1)]);
            sheet.Names.Add("NumberOfCountries", sheet[String.Format("A{0}", index)]);

            //references of names
            sheet.Range["A1"].Value = "Number of Countries:";
            sheet.Range["B1"].Formula = "=NumberOfCountries";
            sheet[String.Format("A{0}", index)].Formula = "=COUNTA(Countries)";
            sheet[String.Format("D{0}", index)].Formula = "=SUM(Area)";
            sheet[String.Format("E{0}", index)].Formula = "=SUM(Population)";

            //style
            sheet.Rows[index - 1].RowHeight = 16;
            String range = String.Format("A{0}:E{0}", index);
            sheet.Range[range].Style.Font.IsBold = true;
            sheet.Range[range].Style.KnownColor = ExcelColors.LightOrange;
            sheet.Range[range].Style.Borders[BordersLineType.EdgeTop].Color = Color.FromArgb(0, 0, 0);
            sheet.Range[range].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thick;
            sheet.Range[range].Style.Borders[BordersLineType.EdgeBottom].Color = Color.FromArgb(0, 0, 0);
            sheet.Range[range].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            sheet.Range[range].Style.Borders[BordersLineType.EdgeLeft].Color = Color.FromArgb(0, 0, 0);
            sheet.Range[range].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            sheet.Range[range].Style.Borders[BordersLineType.EdgeRight].Color = Color.FromArgb(0, 0, 0);
            sheet.Range[range].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

            workbook.SaveToFile("Sample.xls");

            ExcelDocViewer(workbook.FileName);
        }

        private void btnAbout_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
