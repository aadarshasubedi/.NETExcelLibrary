Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Spire.Xls

Namespace Spire.Xls.Sample
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private WithEvents btnRun As System.Windows.Forms.Button
		Private WithEvents btnAbout As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private textBox1 As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private textBox2 As System.Windows.Forms.TextBox
		''' <summary>
		''' Required designer variable.
		''' </summary
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()
			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnRun = New System.Windows.Forms.Button()
			Me.btnAbout = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.textBox2 = New System.Windows.Forms.TextBox()
			Me.SuspendLayout()
			' 
			' btnRun
			' 
			Me.btnRun.Location = New System.Drawing.Point(272, 117)
			Me.btnRun.Name = "btnRun"
			Me.btnRun.Size = New System.Drawing.Size(72, 23)
			Me.btnRun.TabIndex = 2
			Me.btnRun.Text = "Read"
'			Me.btnRun.Click += New System.EventHandler(Me.btnRun_Click);
			' 
			' btnAbout
			' 
			Me.btnAbout.Location = New System.Drawing.Point(352, 117)
			Me.btnAbout.Name = "btnAbout"
			Me.btnAbout.TabIndex = 3
			Me.btnAbout.Text = "Close"
'			Me.btnAbout.Click += New System.EventHandler(Me.btnAbout_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(134)))
			Me.label1.Location = New System.Drawing.Point(16, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(428, 18)
			Me.label1.TabIndex = 4
			Me.label1.Text = "The sample demonstrates how to read hyperlinks from spreadsheet."
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(24, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 16)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Home page:"
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(128, 44)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(216, 21)
			Me.textBox1.TabIndex = 6
			Me.textBox1.Text = ""
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(24, 72)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(48, 16)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Support:"
			' 
			' textBox2
			' 
			Me.textBox2.Location = New System.Drawing.Point(128, 72)
			Me.textBox2.Name = "textBox2"
			Me.textBox2.Size = New System.Drawing.Size(216, 21)
			Me.textBox2.TabIndex = 8
			Me.textBox2.Text = ""
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
			Me.ClientSize = New System.Drawing.Size(456, 149)
			Me.Controls.Add(Me.textBox2)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.btnAbout)
			Me.Controls.Add(Me.btnRun)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Formulas sample"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
			Dim workbook As Workbook = New Workbook()
			workbook.LoadFromFile("..\..\..\..\..\..\Data\HyperlinkSample.xls")
			Dim sheet As Worksheet = workbook.Worksheets(0)

			textBox1.Text = sheet.HyperLinks(0).Address
			textBox2.Text = sheet.HyperLinks(1).Address
		End Sub

		Private Sub btnAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbout.Click
			Close()
		End Sub

		Private Sub ExcelDocViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub


	End Class
End Namespace
