import pyodbc

# Database connection settings
server = 'DESKTOP-HQ0BPSE'
database = 'CompanyBrandManager'
username = 'sa'
password = 'sql123'

# Create connection string
conn_str = f'DRIVER=ODBC Driver 17 for SQL Server;SERVER={server};DATABASE={database};UID={username};PWD={password}'

# Connect to the database
conn = pyodbc.connect(conn_str)
cursor = conn.cursor()

# Drop all tables
cursor.execute('''
    DECLARE @sql NVARCHAR(MAX) = N'';
    SELECT @sql += 'DROP TABLE [' + t.name + '];' 
    FROM sys.tables AS t
    WHERE t.schema_id = SCHEMA_ID();
    EXEC sp_executesql @sql;
''')

# Drop the database
cursor.execute(f'DROP DATABASE [{database}]')

# Commit the transaction
conn.commit()

# Close the connection
conn.close()

print(f'Database "{database}" and all its tables have been dropped successfully.')
