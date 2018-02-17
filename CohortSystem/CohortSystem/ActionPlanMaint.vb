Public Class ActionPlanMaint
    WithEvents bsAP As New BindingSource
    Dim data As New DataOperations

    Private Sub ActionPlanMaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'DataGridView1.AutoGenerateColumns = False
        bsAP.DataSource = data.GetAP()
        DataGridView1.DataSource = bsAP
        DataGridView1.Columns(0).Visible = False
        DataGridView1.ExpandColumns()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim dt As DataTable = CType(bsAP.DataSource, DataTable)
        'For Each row As DataRow In dt.Rows
        'If row.RowState = DataRowState.Added Then
        'Dim DataOps As New DataOperations
        data.SaveAP(dt)
        'DataGridView1.Refresh()
        'End If
        'Next
        '   End If
        

    End Sub

    Private Sub DataGridView1_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        If DataGridView1("Reason", e.RowIndex).Value Is DBNull.Value Or DataGridView1("ActionPlan", e.RowIndex).Value Is DBNull.Value Then
            'OrElse dgUsers("Password", e.RowIndex).Value Is DBNull.Value OrElse dgUsers("Position", e.RowIndex).Value Is DBNull.Value Then
            MessageBox.Show("Must fill in all cells to have a valid entry. Please complete all entries or after this dialog closes press ESC.")
            'bsUsers.MoveLast()
            e.Cancel = True
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If DataGridView1.CurrentRow.Index < 0 Then
            MessageBox.Show("Select record first then click Delete")
        Else
            If MessageBox.Show("Delete Action Plan?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim apID As Integer = DataGridView1("APID", DataGridView1.CurrentRow.Index).Value()
                data.DeleteAPRow(apID)
                refreshGrid()
                MessageBox.Show("Record deleted")

            End If
        End If
    End Sub
    Private Sub refreshGrid()
        bsAP.DataSource = data.GetAP()
        'DataGridView1.DataSource = bsAP
        'DataGridView1.Columns(0).Visible = False
        'DataGridView1.ExpandColumns()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub
End Class