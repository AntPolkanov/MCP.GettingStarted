using System.ComponentModel;
using ModelContextProtocol.Server;

namespace Demo1.Prompts;

[McpServerPromptType]
public class SummaryPrompt
{
    [McpServerPrompt(Name="summary_prompt"), Description("Summarize text")]
    public static string Summary() => "List the main characters using bullet points. Do not give any recommendations or corrections";
}