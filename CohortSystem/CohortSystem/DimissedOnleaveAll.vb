Public Class DimissedOnleaveAll
    Dim data As New DataOperations
    Private Sub DimissedOnleaveAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = data.getDismissed("")
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ShowEditingIcon = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DismissedGraph.ShowDialog()
    End Sub
End Class