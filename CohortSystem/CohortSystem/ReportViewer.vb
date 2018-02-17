
Public Class ReportViewer
    Dim data As New DataOperations
    Private Sub CrystalReportViewer1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
        rpt = New StudentReport

        Dim ds As DataSet = data.GetTryUser()
        Dim dt As DataTable = ds.Tables.Item(0)
        rpt.SetDataSource(dt)

        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.DisplayToolbar = False
    End Sub
End Class