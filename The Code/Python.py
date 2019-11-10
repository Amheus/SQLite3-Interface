import sqlite3 # Imports SQLite, fairly sure that you need to install SQLite aswell for Python.

def sqlOutput(query, location): # For getting data out of a database.
    conn = sqlite3.connect(location) # Creates the connection
    cursor = conn.cursor() # Creates a cursor, this is like the adapter in .NET (I think!)
    cursor.execute(query) # Executes the query
    temp = cursor.fetchall() # Populates the returned data into a variable so that the connection can be closed without losing the data.
    conn.close() # Closes the connection so that the database is no longer locked.
    return(temp) # Returns the data in 'temp'.

def sqlInput(query, location): # For putting data into the database.
    conn = sqlite3.connect(location) # Creates the connection
    cursor = conn.cursor() # Creates a cursor, this is like the adapter in .NET (I think!)
    cursor.execute(query) # Executes the query
    conn.commit()
    conn.close() # Closes the connection so that the database is no longer locked.
    
