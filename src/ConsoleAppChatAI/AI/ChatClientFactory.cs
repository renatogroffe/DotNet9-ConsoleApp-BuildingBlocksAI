
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppChatAI.AI;

public static class ChatClientFactory
{
    public static IChatClient CreateClient(IConfiguration configuration, string model) =>
        new OllamaChatClient(configuration["Ollama:Endpoint"]!, model);
}