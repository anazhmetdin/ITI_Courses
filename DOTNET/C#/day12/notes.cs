/*
- ADO.NET
- based on SqlConnection, commands are handled by SqlCommand
    - two types of commands: [Diconnected, Connected]
    - Connected
        - DataReader: read only
        - locks data until connection release
    - Disconnected
        - DataAdapter: read and write (4 SqlCommands)
        - data is represented as DatTable, or DataSet in case of Fk (navigational ...)

- installed via Microsoft.data.sqlclient
- connectionstrings and other appsettings could be stored in configuration file

- sqlcommand object should have reference to the connection object
    - default command type is text
    - commandText = sql raw query
- executereader -> rows and cols
- executenonquery -> affected rows count
- executescalar -> single cell
- executeXmlReader -> rows and cols as Xml
    - begin and end execute is async

- DataAdapter takes sqlCommand
    - then a dataTable to store the returned data
        - adapter.Fill(dtable) => open connection,  execute, close connection
    - datatable could be complex bound to a grid view

- sqlAdapter constructor takes one string of select command
    - updateCommand, deletecommand, insertCommand:
        - could be created by sqlCommandBuilder

- dataTable keep state of each row: unchanged, modified, added, deleted

- ADO commands are not transactional: some might succeed and some might fail

- simple binding for controls that display single value:
    - control.DataBindings.Add(propertyname, bindingSource, colName);
    - bindingnavigator -> control to navigate through 
*/