import sqlite3

def sqlOutput(query, location):
    conn = sqlite3.connect(location)
    cursor = conn.cursor()
    cursor.execute(query)
    temp = cursor.fetchall()
    conn.close()
    return(temp)

def sqlInput(query, location):
    conn = sqlite3.connect(location)
    cursor = conn.cursor()
    #cursor.execute(query, args)
    cursor.execute(query)
    conn.commit()
    conn.close()
    
