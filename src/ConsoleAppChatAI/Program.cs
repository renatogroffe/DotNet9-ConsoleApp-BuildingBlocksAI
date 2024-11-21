using ConsoleAppChatAI.AI;
using ConsoleAppChatAI.Inputs;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
    .CreateLogger();

var ollamaModel = InputHelper.GetOllamaModel();

using var chatClient = ChatClientFactory.CreateClient(configuration, ollamaModel);

while (true)
{
    Console.WriteLine();
    logger.Information("Pressione CTRL + C para encerrar a aplicacao...");
    var request = InputHelper.GetRequest();

    var responseStream = chatClient.CompleteStreamingAsync(request);
    var oldColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine();
    await foreach (var chunk in responseStream)
    {
        Console.Write(chunk);
    }
    Console.WriteLine();
    Console.ForegroundColor = oldColor;
}