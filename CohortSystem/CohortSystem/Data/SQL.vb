Public Class SQL

    Public Function SelectUser(Optional ByVal filter As String = "") As List(Of tblUserDetails)
        Dim entity As New COHORTDBEntities
        If filter.Trim().Length = 0 Then
            Return entity.tblUserDetails.OrderBy(Function(usr) usr.UserID).ToList
        Else
            Return entity.tblUserDetails.Where(Function(usr) usr.FirstName.Contains(filter) Or usr.LastName.Contains(filter) Or usr.MiddleName.Contains(filter)).OrderBy(Function(usr) usr.UserID).ToList
        End If
    End Function
    Public Function DeleteUser(ByVal userID As Integer) As Boolean
        Dim entity As New COHORTDBEntities
        Dim usr As tblUserDetails = entity.tblUserDetails.Where(Function(u) u.UserID = userID).FirstOrDefault()

        If Not usr Is Nothing Then
            entity.DeleteObject(usr)
            entity.SaveChanges()
        End If

        Return True
    End Function
    Public Function SelectUser(ByVal ID As Integer) As tblUserDetails
        Dim entity As New COHORTDBEntities
        Return entity.tblUserDetails.Where(Function(usr) usr.UserID = ID).FirstOrDefault()
    End Function
    Public Function SaveUser(ByVal usr As tblUserDetails) As Integer
        Dim entity As New COHORTDBEntities

        If usr.UserID = 0 Then
            entity.AddTotblUserDetails(usr)
        Else
            Dim oldUser As tblUserDetails = entity.tblUserDetails.Where(Function(u) u.UserID = usr.UserID).FirstOrDefault()

            oldUser.UserName = usr.UserName
            oldUser.FirstName = usr.FirstName
            oldUser.MiddleName = usr.MiddleName
            oldUser.LastName = usr.LastName
            oldUser.EmailAddress = usr.EmailAddress
            oldUser.Password = usr.Password
            oldUser.Gender = usr.Gender
            oldUser.Position = usr.Position


        End If
        entity.SaveChanges()
        Return usr.UserID
    End Function
    Public Function Login(ByVal user As String, ByVal passWord As String) As tblUserDetails
        Dim entity As New COHORTDBEntities
        Return entity.tblUserDetails.Where(Function(usr) usr.UserName = user And usr.Password = passWord).FirstOrDefault
        ' entity.tblUserDetails.Where(
    End Function
    Public Function AddUser(ByVal user As tblUserDetails) As Integer
        Using entity As New COHORTDBEntities

            'Dim user As tblUserDetails = CustomerDto.ToCustomer
            entity.AddObject("tblUserDetails", user)


            ' 
            ' The save will bring back the new primary key 
            ' 
            entity.SaveChanges()
            ' 
            ' After saving the new primary key is contained in Customer 
            ' The caller in this case creates a new record in the DataGridView 
            ' DataSource, a BindingSource. 
            Return user.UserID

        End Using
    End Function
End Class
