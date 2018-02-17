Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Dim sql As New SQL
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim user As tblUserDetails = sql.Login(UsernameTextBox.Text, PasswordTextBox.Text)
        If (user Is Nothing) Then
            MsgBox("Login failed", MsgBoxStyle.Exclamation, "Failed")
        Else
            If user.Position = "Dean" Then
                AcademicHead.Show()
                'Me.Hide()
            ElseIf user.Position = "Administrator" Then
                UserMaintenance.Show()
            End If
            Me.Hide()

        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
