Public Class trial

    Private Sub trial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        Chart1.Series.Add("test")
        Chart1.Series("test").IsValueShownAsLabel = True
        Chart1.Series.Add("test2")
        Chart1.Series.Add("test3")
        Chart1.Series("test2").IsValueShownAsLabel = True
        Chart1.Series("test2").IsVisibleInLegend = True
        Chart1.Series("test2").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart1.Series("test").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart1.Series("test3").ChartType = DataVisualization.Charting.SeriesChartType.Column


        Chart1.Series("test2").EmptyPointStyle.IsValueShownAsLabel = False
        Chart1.Series("test3").IsValueShownAsLabel = True
        Chart1.Series("test").Points.AddXY("test", 24)
        
        Chart1.Series("test2").Points.AddXY("test", System.DBNull.Value)
        'Chart1.Series("test3").Points("test").x()
        Chart1.Series("test3").Points.AddXY("test", System.DBNull.Value)
        Chart1.Series("test").Points.AddXY("test2", System.DBNull.Value)
        Chart1.Series("test2").Points.AddXY("test2", 23)
        Chart1.Series("test3").Points.AddXY("test2", System.DBNull.Value)
        Chart1.Series("test").Points(0).AxisLabel = ""
        Chart1.Series("test2").Points(0).AxisLabel = ""
        Chart1.Series("test3").Points(0).AxisLabel = ""
        Chart1.ChartAreas("ChartArea1").AxisX.IsInterlaced = False

    End Sub
End Class