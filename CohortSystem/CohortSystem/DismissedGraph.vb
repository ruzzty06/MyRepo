
Public Class DismissedGraph

    Dim data As New DataOperations
    Private Sub DismissedGraph_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable = data.GetSchools()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("", "View by School")
        For Each dr As DataRow In dt.Rows
            comboSource.Add(dr("SchoolID"), dr("SchoolCode"))
        Next
        cboSchool.DataSource = New BindingSource(comboSource, Nothing)
        cboSchool.ValueMember = "Key"
        cboSchool.DisplayMember = "Value"
        dt = data.GetDismissedGraph()
        Chart1.Series.Clear()
        Chart1.Palette = DataVisualization.Charting.ChartColorPalette.Pastel
        For Each d As DataRow In dt.Rows
            Chart1.Series.Add(d("School"))
            Chart1.Series(d("School")).Points.AddXY(d("School"), d("Count"))
            Chart1.Series(d("School")).IsValueShownAsLabel = True
            'Chart1.Series(d("School"))
            Dim dum As String = d("School") & "1"
            Chart1.Series.Add(dum)
            Chart1.Series(dum).Points.AddXY(dum, System.DBNull.Value)
            Chart1.Series(dum).IsValueShownAsLabel = False
            Chart1.Series(dum).IsVisibleInLegend = False

            'Chart1.Series(dum)()
        Next
        'cboSchool.Items.Insert(0, "View by school")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cboSchool.SelectedValue <> "" Then
            DismissedSpec.school = DirectCast(cboSchool.SelectedItem, KeyValuePair(Of String, String)).Key
            DismissedSpec.Text = "Dismissed / On Leave Rate(" + DirectCast(cboSchool.SelectedItem, KeyValuePair(Of String, String)).Value + ")"

            DismissedSpec.ShowDialog()
        End If
    End Sub
End Class