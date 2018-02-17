Public Class UserEdit
    Private pUser As Integer
    Dim sql As New SQL
    Public Property User() As Integer
        Get
            Return pUser
        End Get
        Set(ByVal value As Integer)
            pUser = value
        End Set
    End Property
    Private Sub UserEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim usr As tblUserDetails = sql.SelectUser(pUser)
        If Not usr Is Nothing Then
            txtUser.Text = usr.UserName
            txtEmail.Text = usr.EmailAddress
            txtFirstname.Text = usr.FirstName
            txtLastname.Text = usr.LastName
            txtPassword.Text = usr.Password
            txtMiddlename.Text = usr.MiddleName
            If Not usr.Position Is Nothing Then
                cboPosition.SelectedIndex = cboPosition.Items.IndexOf(usr.Position)
            End If
            If Not usr.Gender Is Nothing Then
                cboGender.SelectedIndex = cboGender.Items.IndexOf(usr.Gender)
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim newUser As New tblUserDetails
        If Not ValidateUser() Then
            MsgBox("Please complete all fields.")
            Return
        End If
        CreateUser(newUser)
        If sql.SaveUser(newUser) > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        Else
            MsgBox("Unable to save user info.")
        End If

    End Sub
    Private Sub CreateUser(ByRef user As tblUserDetails)
        user.UserID = pUser
        user.UserName = txtUser.Text
        user.FirstName = txtFirstname.Text
        user.MiddleName = txtMiddlename.Text
        user.LastName = txtLastname.Text
        user.EmailAddress = txtEmail.Text
        user.Password = txtPassword.Text
        user.Gender = cboGender.Text
        user.Position = cboPosition.Text

    End Sub
    Private Function ValidateUser() As Boolean
        Dim err As String = ""
        If txtUser.Text.Trim().Length = 0 Or txtFirstname.Text.Trim().Length = 0 _
        Or txtLastname.Text.Trim().Length = 0 Or txtMiddlename.Text.Trim().Length = 0 _
        Or txtEmail.Text.Trim().Length = 0 Or txtFirstname.Text.Trim().Length = 0 _
        Or txtPassword.Text.Trim().Length = 0 Or cboGender.Text.Trim().Length = 0 _
        Or cboPosition.Text.Trim().Length = 0 Then



            Return False
        End If
        Return True
    End Function
End Class