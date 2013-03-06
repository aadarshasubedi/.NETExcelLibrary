using System;
using System.Data.OleDb;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Spire.Xls;
using Spire.Xls.Charts;

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
		private System.Windows.Forms.CheckBox checkBox1;
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
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
			this.btnAbout.TabIndex = 3;
			this.btnAbout.Text = "Close";
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(456, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "The sample demonstrates how to create line chart in an excel workbook.";
			//
			// checkBox1
			//
			this.checkBox1.Location = new System.Drawing.Point(24, 48);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "3D Chart";
			//
			// Form1
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(616, 94);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.btnRun);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chart sample";
			this.ResumeLayout(false);

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

		private void btnRun_Click(object sender, System.EventArgs e)
		{
			Workbook workbook = new Workbook();

			//Initailize worksheet
			workbook.CreateEmptySheets(1);
			Worksheet sheet = workbook.Worksheets[0];
			sheet.Name = "Chart data";
			sheet.GridLinesVisible = false;

			//Writes chart data
			CreateChartData(sheet);
            //Add a new  chart worsheet to workbook
			Chart chart = sheet.Charts.Add();
			if (checkBox1.Checked)
			{
				chart.ChartType = ExcelChartType.Line3D;
			}
			else
			{
				chart.ChartType = ExcelChartType.Line;
			}

			//Set region of chart data
			chart.DataRange = sheet.Range["A1:E5"];

			//Set position of chart
			chart.LeftColumn = 1;
			chart.TopRow = 6;
			chart.RightColumn = 11;
			chart.BottomRow = 29;


            //Chart title
			chart.ChartTitle = "Sales market by country";
			chart.ChartTitleArea.IsBold = true;
			chart.ChartTitleArea.Size = 12;

			chart.PrimaryCategoryAxis.Title = "Month";
			chart.PrimaryCategoryAxis.Font.IsBold = true;
			chart.PrimaryCategoryAxis.TitleArea.IsBold = true;

			chart.PrimaryValueAxis.Title = "Sales(in Dollars)";
			chart.PrimaryValueAxis.HasMajorGridLines = false;
			chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;
            chart.PrimaryValueAxis.MinValue = 1000;
			chart.PrimaryValueAxis.TitleArea.IsBold = true;

            foreach (Charts.ChartSerie cs in chart.Series)
            {
                cs.Format.Options.IsVaryColor = true;
                cs.DataPoints.DefaultDataPoint.DataLabels.HasValue = true;

			    if (!checkBox1.Checked)
				    cs.DataFormat.MarkerStyle = ChartMarkerType.Circle;
            }

            chart.PlotArea.Fill.Visible = false;

			chart.Legend.Position = LegendPositionType.Top;
			workbook.SaveToFile("Sample.xls");
			ExcelDocViewer(workbook.FileName);
		}

		private void CreateChartData(Worksheet sheet)
		{
			//Country
			sheet.Range["A1"].Value = "Country";
			sheet.Range["A2"].Value = "Cuba";
			sheet.Range["A3"].Value = "Mexico";
			sheet.Range["A4"].Value = "France";
			sheet.Range["A5"].Value = "German";

			//Jun
			sheet.Range["B1"].Value = "Jun";
			sheet.Range["B2"].NumberValue = 3300;
			sheet.Range["B3"].NumberValue = 2300;
			sheet.Range["B4"].NumberValue = 4500;
			sheet.Range["B5"].NumberValue = 6700;

			//Jul
			sheet.Range["C1"].Value = "Jul";
			sheet.Range["C2"].NumberValue = 7500;
			sheet.Range["C3"].NumberValue = 2900;
			sheet.Range["C4"].NumberValue = 2300;
			sheet.Range["C5"].NumberValue = 4200;

			//Aug
			sheet.Range["D1"].Value = "Aug";
			sheet.Range["D2"].NumberValue = 7700;
			sheet.Range["D3"].NumberValue = 6900;
			sheet.Range["D4"].NumberValue = 8400;
			sheet.Range["D5"].NumberValue = 4200;

			//Sep
			sheet.Range["E1"].Value = "Sep";
			sheet.Range["E2"].NumberValue = 8000;
			sheet.Range["E3"].NumberValue = 7200;
			sheet.Range["E4"].NumberValue = 8100;
			sheet.Range["E5"].NumberValue = 5600;

			//Style
			sheet.Range["A1:E1"].Style.Font.IsBold = true;
			sheet.Range["A2:E2"].Style.KnownColor = ExcelColors.LightYellow;
			sheet.Range["A3:E3"].Style.KnownColor = ExcelColors.LightGreen1;
			sheet.Range["A4:E4"].Style.KnownColor = ExcelColors.LightOrange;
			sheet.Range["A5:E5"].Style.KnownColor = ExcelColors.LightTurquoise;

			//Border
			sheet.Range["A1:E5"].Style.Borders[BordersLineType.EdgeTop].Color = Color.FromArgb(0, 0, 128);
			sheet.Range["A1:E5"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
			sheet.Range["A1:E5"].Style.Borders[BordersLineType.EdgeBottom].Color = Color.FromArgb(0, 0, 128);
			sheet.Range["A1:E5"].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
			sheet.Range["A1:E5"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.FromArgb(0, 0, 128);
			sheet.Range["A1:E5"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
			sheet.Range["A1:E5"].Style.Borders[BordersLineType.EdgeRight].Color = Color.FromArgb(0, 0, 128);
			sheet.Range["A1:E5"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

			sheet.Range["B2:D5"].Style.NumberFormat = "\"$\"#,##0";
		}

		private void ExcelDocViewer( string fileName )
		{
			try
			{
				System.Diagnostics.Process.Start(fileName);
			}
			catch{}
		}

		private void btnAbout_Click(object sender, System.EventArgs e)
		{
			Close();
		}


	}
}
