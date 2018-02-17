<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DismissedGraph
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim CustomLabel6 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series11 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Series12 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.cboSchool = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(545, 331)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "Back"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(545, 361)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "Print Report"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea6.AxisX.CustomLabels.Add(CustomLabel6)
        ChartArea6.AxisX.IsLabelAutoFit = False
        ChartArea6.AxisX.LabelStyle.Angle = 30
        ChartArea6.AxisX.MajorGrid.Enabled = False
        ChartArea6.AxisX.MajorTickMark.Enabled = False
        ChartArea6.AxisX.MinorTickMark.Enabled = True
        ChartArea6.AxisX2.IsLabelAutoFit = False
        ChartArea6.AxisX2.LabelStyle.Angle = 30
        ChartArea6.CursorX.Interval = 0
        ChartArea6.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea6)
        Legend6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend6.Name = "Legend2"
        Me.Chart1.Legends.Add(Legend6)
        Me.Chart1.Location = New System.Drawing.Point(12, 10)
        Me.Chart1.Name = "Chart1"
        Series11.ChartArea = "ChartArea1"
        Series11.IsValueShownAsLabel = True
        Series11.Legend = "Legend2"
        Series11.Name = "Series1"
        Series12.ChartArea = "ChartArea1"
        Series12.CustomProperties = "DrawSideBySide=True"
        Series12.Legend = "Legend2"
        Series12.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square
        Series12.Name = "Series2"
        Me.Chart1.Series.Add(Series11)
        Me.Chart1.Series.Add(Series12)
        Me.Chart1.Size = New System.Drawing.Size(590, 315)
        Me.Chart1.TabIndex = 9
        Me.Chart1.Text = "Chart1"
        '
        'cboSchool
        '
        Me.cboSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSchool.FormattingEnabled = True
        Me.cboSchool.Location = New System.Drawing.Point(67, 344)
        Me.cboSchool.Name = "cboSchool"
        Me.cboSchool.Size = New System.Drawing.Size(121, 21)
        Me.cboSchool.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(207, 344)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "View"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DismissedGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 396)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboSchool)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "DismissedGraph"
        Me.Text = "Dismissed/ On Leave Rate"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents cboSchool As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
