
Public Class DismissedGraphSpec
    Public SchoolID As Integer
    Dim data As New DataOperations

    Private Sub DismissedGraph_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      
        Dim dt As DataTable = data.GetDismissedGraphBySchool(SchoolID)
        Chart1.Series.Clear()
        Chart1.Palette = DataVisualization.Charting.ChartColorPalette.Pastel
        For Each d As DataRow In dt.Rows
            Chart1.Series.Add(d("Reason"))
            Chart1.Series(d("Reason")).Points.AddXY(d("Reason"), d("Count"))
            Chart1.Series(d("Reason")).IsValueShownAsLabel = True
            'Chart1.Series(d("School"))
            Dim dum As String = d("Reason") & "1"
            Chart1.Series.Add(dum)
            Chart1.Series(dum).Points.AddXY(dum, System.DBNull.Value)
            Chart1.Series(dum).IsValueShownAsLabel = False
            Chart1.Series(dum).IsVisibleInLegend = False

            'Chart1.Series(dum)()
        Next
        'cboSchool.Items.Insert(0, "View by school")
    End Sub

    
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Dispose()
    End Sub
End Class