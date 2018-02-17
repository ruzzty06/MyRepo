
Public Class UserMaintenance
    'WithEvents bsUsers As New BindingSource
    'Dim data As New DataOperations
    Dim sql As New SQL

    Private Sub UserMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LoginForm1.PasswordTextBox.Clear()
        LoginForm1.UsernameTextBox.Clear()
        LoginForm1.Show()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgUsers.AutoGenerateColumns = False
        RefreshUsers("")
        'bsUsers.DataSource = data.GetUsers()
        'dgUsers.DataSource = bsUsers
        'dgUsers.ExpandColumns()
    End Sub
    Private Sub RefreshUsers(ByVal filter As String)
        dgUsers.DataSource = sql.SelectUser(filter)
        dgUsers.ExpandColumns()
    End Sub

    Private Sub tsRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'bsUsers.DataSource = sql.SelectUser()
        'dgUsers.DataSource = bsUsers
        'dgUsers.Refresh()
    End Sub

    Private Sub tsAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAddNew.Click


        'Dim dt As DataTable = CType(bsUsers.DataSource, DataTable)
        'Dim DataOps As New DataOperations
        'DataOps.AddUsers(dt)
        Dim eduser As New UserEdit
        If eduser.ShowDialog = Windows.Forms.DialogResult.OK Then

            RefreshUsers(txtFilter.Text)
        End If
    End Sub

    Private Sub dgUsers_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgUsers.RowValidating
        If dgUsers("UserName", e.RowIndex).Value Is DBNull.Value Then
            'OrElse dgUsers("Password", e.RowIndex).Value Is DBNull.Value OrElse dgUsers("Position", e.RowIndex).Value Is DBNull.Value Then
            MessageBox.Show("Must fill in all cells to have a valid entry. Please complete all entries or after this dialog closes press ESC.")
            'bsUsers.MoveLast()
            e.Cancel = True
        End If
    End Sub

    Private Sub tsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEdit.Click
        'If My.Dialogs.Question("Save current row") Then
        'Dim DataOps As New DataOperations
        'If Not DataOps.UpdateRow(CType(bsUsers.Current, DataRowView).Row) Then
        'My.Dialogs.ExceptionDialog("Update failed")
        'End If
        'End If

        If dgUsers.CurrentRow.Index < 0 Then
            MessageBox.Show("Select record first then click Edit")
        Else
            Dim userID As Integer = dgUsers("UserID", dgUsers.CurrentRow.Index).Value()
            Dim eduser As New UserEdit
            eduser.User = userID
            If eduser.ShowDialog = Windows.Forms.DialogResult.OK Then
                RefreshUsers(txtFilter.Text)
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RefreshUsers(txtFilter.Text)
    End Sub



    Private Sub txtFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            RefreshUsers(txtFilter.Text)
        End If
    End Sub

    Private Sub tsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDelete.Click
        If dgUsers.CurrentRow.Index < 0 Then
            MessageBox.Show("Select record first then click Delete")
        Else
            If MessageBox.Show("Delete User?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim userID As Integer = dgUsers("UserID", dgUsers.CurrentRow.Index).Value()
                sql.DeleteUser(userID)
                RefreshUsers(txtFilter.Text)
                MessageBox.Show("Record deleted")
            End If
        End If
    End Sub
End Class
