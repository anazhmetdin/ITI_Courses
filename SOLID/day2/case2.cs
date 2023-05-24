public abstract class SqlFile
{
    public string FilePath { get; set; }
    public string FileText { get; set; }
    public string LoadText()
    {
        /* Code to read text from sql file */
    }
}

public interface ISaveText
{
    void SaveText();
}

public class WritableSqlFile : SqlFile, ISaveText
{    
    public void SaveText()
    {
        /* Code to save text into sql file */
    }
}

public class ReadOnlySqlFile : SqlFile
{
}

public class SqlFileManager
{
    private readonly StringBuilder objStrBuilder;

    public SqlFileManager() {
        objStrBuilder = new();
    }

    public string GetTextFromFiles(List<SqlFile> lstSqlFiles)
    {
        foreach (var objFile in lstSqlFiles)
        {
            objStrBuilder.Append(objFile.LoadText());
        }
        return objStrBuilder.ToString();
    }
    
    public void SaveTextIntoFiles(List<WritableSqlFile> lstSqlFiles)
    {
        foreach (var objFile in lstSqlFiles)
        {
            objFile.SaveText();
        }
    }
}