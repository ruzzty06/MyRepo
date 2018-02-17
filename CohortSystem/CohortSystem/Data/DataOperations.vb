Imports System.Data.SqlClient
Public Class DataOperations

    Private APTable As DataTable

    Private UserTable As DataTable
    Public Function getDismissed(ByVal school As String) As DataTable

        Dim dt As New DataTable
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "Select s.StudentNumber,s.FirstName+' '+s.Middlename+' '+s.Lastname as StudentName,p.ProgramCode as Program,d.DateOfDismissal,r.Reason,sc.SchoolCode as School from tblDismissed d " & _
                "left join dbo.tblStudent s on d.StudentID=s.studentid left join program p " & _
"on d.programid=p.programid left join apmaintenance r on d.Reasonid=r.apid " & _
"left join tblSchool sc on d.schoolid=sc.schoolid "
                If Not String.IsNullOrEmpty(school) Then
                    cmd.CommandText += " where sc.schoolid=@schoolid"
                    cmd.Parameters.AddWithValue("@schoolid", school)
                End If
                cn.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)
                If (ds.Tables.Count > 0) Then
                    dt = ds.Tables(0)
                End If
            End Using
        End Using

        Return dt
    End Function
    Public Function GetUsers() As DataTable
        Me.UserTable = New DataTable
        Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "UserID", .DataType = GetType(Integer)})
        Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "UserName", .DataType = GetType(String)})
        Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "PrimaryGroup", .DataType = GetType(String)})
        Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "FirstName", .DataType = GetType(String)})
        Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "MiddleName", .DataType = GetType(String)})
        Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "LastName", .DataType = GetType(String)})
        Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "EmailAddress", .DataType = GetType(String)})
        Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "Password", .DataType = GetType(String)})
        'Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "Position", .DataType = GetType(String)})

        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT UserID, UserName,Position,FirstName,MiddleName,LastName,EmailAddress, Password  FROM [tblUserDetails] ORDER BY UserID"
                cn.Open()
                Dim Reader = cmd.ExecuteReader
                If Reader.HasRows Then
                    While Reader.Read
                        Me.UserTable.Rows.Add(New Object() {Reader.GetInt32(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetString(5), Reader.GetString(6), Reader.GetString(7)})
                    End While
                End If
            End Using
        End Using

        Me.UserTable.AcceptChanges()

        Return UserTable
    End Function
    Public Function GetAP() As DataTable
        Me.APTable = New DataTable
        Me.APTable.Columns.Add(New DataColumn With {.ColumnName = "APID", .DataType = GetType(Integer)})
        Me.APTable.Columns.Add(New DataColumn With {.ColumnName = "Reason", .DataType = GetType(String)})
        Me.APTable.Columns.Add(New DataColumn With {.ColumnName = "ActionPlan", .DataType = GetType(String)})
        'Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "FirstName", .DataType = GetType(String)})
        'Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "MiddleName", .DataType = GetType(String)})
        'Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "LastName", .DataType = GetType(String)})
        'Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "EmailAddress", .DataType = GetType(String)})
        'Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "Password", .DataType = GetType(String)})
        'Me.UserTable.Columns.Add(New DataColumn With {.ColumnName = "Position", .DataType = GetType(String)})

        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT APID, Reason,ActionPlan  FROM [APMaintenance] ORDER BY Reason"
                cn.Open()
                Dim Reader = cmd.ExecuteReader
                If Reader.HasRows Then
                    While Reader.Read
                        Me.APTable.Rows.Add(New Object() {Reader.GetInt32(0), Reader.GetString(1), Reader.GetString(2)})
                    End While
                End If
            End Using
        End Using

        Me.APTable.AcceptChanges()

        Return APTable
    End Function
    Public Function GetSchools() As DataTable
       
        Dim dt As New DataTable
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT SchoolID, SchoolCode,School  FROM [tblSchool] ORDER BY SchoolCode"
                cn.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)
                If (ds.Tables.Count > 0) Then
                    dt = ds.Tables(0)
                End If
            End Using
        End Using
        Return dt
    End Function
    Public Function GetDismissedGraph() As DataTable

        Dim dt As New DataTable
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "getDismissedReportGraph"
                cmd.CommandType = CommandType.StoredProcedure
                cn.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)
                If (ds.Tables.Count > 0) Then
                    dt = ds.Tables(0)
                End If
            End Using
        End Using
        Return dt
    End Function
    Public Sub New()

        
    End Sub
    Public Sub AddUsers(ByVal table As DataTable)
        For Each row As DataRow In table.Rows
            If row.RowState = DataRowState.Added Then
                If Not String.IsNullOrEmpty(row.Field(Of String)("UserName")) Then
                    Dim NewIdentifier As Integer = 0
                    If AddNewCustomer(row.Field(Of String)("UserName"), row.Field(Of String)("Password"), row.Field(Of String)("Position"), NewIdentifier) Then
                        row.SetField(Of Integer)("UserID", NewIdentifier)
                    End If
                End If

            End If
        Next
        table.AcceptChanges()
    End Sub
    Public Sub SaveAP(ByVal table As DataTable)
        For Each row As DataRow In table.Rows
            If row.RowState = DataRowState.Added Then
                If Not String.IsNullOrEmpty(row.Field(Of String)("Reason")) Then
                    Dim NewIdentifier As Integer = 0
                    If AddNewAP(row.Field(Of String)("Reason"), row.Field(Of String)("ActionPlan"), NewIdentifier) Then
                        row.SetField(Of Integer)("APID", NewIdentifier)
                    End If
                End If
            ElseIf row.RowState = DataRowState.Modified Then
                UpdateAPRow(row)
            End If
        Next
        table.AcceptChanges()
    End Sub
    Public Function GetTryUser() As DataSet
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "getUsers"
                cmd.CommandType = CommandType.StoredProcedure
                cn.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)
                Return ds
            End Using
        End Using
    End Function
    Private InsertStatement As String = "INSERT INTO [tblUserDetails] (UserName,Password,Position) VALUES (@UserName,@Password,@Position); SELECT CAST(scope_identity() AS int);"

    Public Function AddNewCustomer(ByVal UserName As String, ByVal Password As String, ByVal Position As String, ByRef NewIdentifier As Integer) As Boolean
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = InsertStatement
                cmd.Parameters.AddWithValue("@UserName", UserName)
                cmd.Parameters.AddWithValue("@Password", Password)
                cmd.Parameters.AddWithValue("@Position", Position)
                cn.Open()
                Try
                    NewIdentifier = CInt(cmd.ExecuteScalar)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function
    Private InsertAPStatement As String = "INSERT INTO [APMaintenance] (Reason,ActionPlan) VALUES (@Reason,@ActionPlan); SELECT CAST(scope_identity() AS int);"

    Public Function AddNewAP(ByVal Reason As String, ByVal ActionPlan As String, ByRef NewIdentifier As Integer) As Boolean
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = InsertAPStatement
                cmd.Parameters.AddWithValue("@Reason", Reason)
                cmd.Parameters.AddWithValue("@ActionPlan", ActionPlan)
                cn.Open()
                Try
                    NewIdentifier = CInt(cmd.ExecuteScalar)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function
    Private UpdateStatement As String = "UPDATE tblUserDetails SET UserName = @UserName, Password = @Password,Position = @Position WHERE UserID = @UserID"

    Public Function UpdateRow(ByVal row As DataRow) As Boolean
        Dim Result As Boolean = False
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = UpdateStatement
                cmd.Parameters.AddWithValue("@UserName", row.Field(Of String)("UserName"))
                cmd.Parameters.AddWithValue("@UserName", row.Field(Of String)("UserName"))
                cmd.Parameters.AddWithValue("@PrimaryGroup", row.Field(Of String)("Password"))
                cmd.Parameters.AddWithValue("@Position", row.Field(Of String)("Position"))
                cmd.Parameters.AddWithValue("@UserID", row.Field(Of Integer)("UserID"))
                cn.Open()
                Try
                    If CInt(cmd.ExecuteNonQuery) = 1 Then
                        Result = True
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
        Return Result
    End Function
    Private UpdateAPStatement As String = "UPDATE APMaintenance SET Reason = @Reason, ActionPlan = @ActionPlan WHERE APID = @APID"

    Public Function UpdateAPRow(ByVal row As DataRow) As Boolean
        Dim Result As Boolean = False
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                'Private UpdateAPStatement As String = "UPDATE tblUserDetails SET UserName = @UserName, Password = @Password,Position = @Position WHERE UserID = @UserID"
                cmd.CommandText = UpdateAPStatement
                cmd.Parameters.AddWithValue("@Reason", row.Field(Of String)("Reason"))
                cmd.Parameters.AddWithValue("@ActionPlan", row.Field(Of String)("ActionPlan"))
                cmd.Parameters.AddWithValue("@APID", row.Field(Of Integer)("APID"))
                cn.Open()
                Try
                    If CInt(cmd.ExecuteNonQuery) = 1 Then
                        Result = True
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
        Return Result
    End Function
    Private DeleteAPStatement As String = "Delete from APMaintenance where APID = @APID"

    Public Function DeleteAPRow(ByVal apID As Integer) As Boolean
        Dim Result As Boolean = False
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                'Private UpdateAPStatement As String = "UPDATE tblUserDetails SET UserName = @UserName, Password = @Password,Position = @Position WHERE UserID = @UserID"
                cmd.CommandText = DeleteAPStatement
                cmd.Parameters.AddWithValue("@APID", apID)
                cn.Open()
                Try
                    If CInt(cmd.ExecuteNonQuery) = 1 Then
                        Result = True
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
        Return Result
    End Function
End Class

