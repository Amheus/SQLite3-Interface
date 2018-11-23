Imports System
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SQLite

Class VB
        Private Sub basicSelection()
            Dim dt As DataTable = New DataTable()
            Dim SQLquery As String = "SELECT * FROM [Data Table] WHERE ID = 4;"
            Dim connection As SQLiteConnection = New SQLiteConnection("Data Source = ***")
            Dim command As SQLiteCommand = New SQLiteCommand()
            Dim reader As SQLiteDataReader

            Try
                connection.Open()
                command.Connection = New SQLiteConnection("Data Source = ***")
                command.CommandText = SQLquery
                reader = command.ExecuteReader()
                dt.Load(reader)
                Dim dg As DataGridView = New DataGridView()
                dg.DataSource = dt
                reader.Close()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
    End Class