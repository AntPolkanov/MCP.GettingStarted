using System.ComponentModel;
using ModelContextProtocol.Server;

namespace Demo2.Tools;

[McpServerToolType]
public class StringLengthTool
{
    [McpServerTool, Description("Get the length of a string.")]
    public int StringLength(string input)
    {
        return input.Length;
    }
}