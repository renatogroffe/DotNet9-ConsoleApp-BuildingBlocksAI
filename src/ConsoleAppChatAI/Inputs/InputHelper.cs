using Sharprompt;

namespace ConsoleAppChatAI.Inputs;

public class InputHelper
{
    public static string GetRequest()
    {
        string request;
        bool invalidRequest;
        do
        {
            request = Prompt.Input<string>("Digite a pergunta");
            invalidRequest = String.IsNullOrWhiteSpace(request);
            if (invalidRequest)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Informe um texto valido para a pergunta!");
                Console.ForegroundColor = oldColor;
                Console.WriteLine();
            }

        } while (invalidRequest);

        var oldColor2 = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine("Aguarde...");
        Console.WriteLine();
        Console.ForegroundColor = oldColor2;

        return request;
    }

    public static string GetOllamaModel()
    {
        Console.WriteLine();
        var answer = Prompt.Select("Selecione o modelo para testes com Ollama",
            new[] { "llama3.2", "codellama", "phi3:mini", "phi3:medium-128k", "gemma2" });
        Console.WriteLine();
        return answer;
    }
}