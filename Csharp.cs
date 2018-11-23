using System;// For the Exception
using System.Windows.Forms; // For the MessageBox
using System.Data; // For the DataTable
using System.Data.SQLite; // For the SQLite interface

namespace Interfacing_With_SQLite3
{
    class Csharp
    {
        void basicSelection()
        {
            DataTable dt = new DataTable();
            // Creates a DataTable so that the results from the SQLite query can be stored in a table

            string SQLquery = "SELECT * FROM [Data Table] WHERE ID = 4;";
            // This is to make it easier to edit the SQL query as it's out of the way
            // Ensure to enter a semicolon at the end so SQLite knows where the end of the line is
            // In the event that your datatable's name has spaces in it, enclose the name in square brackets so SQLite can process it

            SQLiteConnection connection = new SQLiteConnection(@"Data Source = ***");
            // Replace the *** with the file location of the database
            // The '@' at the start is to account for all the back-slashes in the file URL so C# doesn't through errors
            // This is declared seperately so it can be opened and closed easily
            
            SQLiteCommand command = new SQLiteCommand();

            SQLiteDataReader reader;

            try
            {
                connection.Open();
                // Opens the SQLite connection

                command.Connection = new SQLiteConnection(@"Data Source = ***");
                // Sets the location of the database

                command.CommandText = SQLquery;
                // Sets the SQL query

                reader = command.ExecuteReader();
                // There are three types of execution, Scalar, NonQuery and Reader, for this, a Reader will do

                dt.Load(reader);
                // Fills the DataTable with the results from the query


                // Do Stuff Here ----->

                DataGridView dg = new DataGridView();
                dg.DataSource = dt;
                // dg emulates a DataGridView that you may have on your form
                // This line of code will completely populate the DataGridView with the enire contents of the DataTable
                // The beauty of this is the fact that ou do not need to create columns on the DataGridView as they will be created automatically

                // <-----


                reader.Close();
                // Remember to close the reader - I can't remember why though!

                connection.Close();
                // Also remember to close the connection so that your program doesn't lock the database as SQLite can only be edited by one user at a time
                // You could also use connection.Dispose(); if you wanted to, depending on what you were doing
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Simple messagebox giving the error message
            }
            // Throw it all into a Try and Catch, just incase something goes wrong and you don't crash your program
        }
    }
}