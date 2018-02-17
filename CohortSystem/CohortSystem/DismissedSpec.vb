Public Class DismissedSpec
    Public school As Integer
    Public SchoolCode As String
    Dim data As New DataOperations
    Private Sub DimissedOnleaveAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Dismissed / On Leave Rate(" + SchoolCode + ")"

        DataGridView1.DataSource = data.getDismissed(school)
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ShowEditingIcon = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DismissedGraphSpec.Text = "Dismissed / On leave Rate (" + SchoolCode + ")"
        DismissedGraphSpec.SchoolID = school
        DismissedGraphSpec.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class