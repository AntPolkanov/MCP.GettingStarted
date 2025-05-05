using System.ComponentModel;
using ModelContextProtocol.Server;

namespace Demo1.Tools;

[McpServerToolType]
public class SaveToDBTool
{
    [McpServerTool, Description("Save a string to the database.")]
    public string SaveToDB(string input)
    {
        return $"Saved input to the database.";
    }
}