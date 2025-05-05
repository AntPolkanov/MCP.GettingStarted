using System.ComponentModel;
using ModelContextProtocol.Server;

namespace Demo1.Tools;

[McpServerToolType]
public class StringLengthTool
{
    [McpServerTool, Description("Get the length of a string.")]
    public int GetStringLength(string input)
    {
        return input.Length;
    }
}