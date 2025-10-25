
namespace ConsoleAppAlgorithmsExamples.CsharpBasics;

public class AsyncDisposal : IAsyncDisposable
{
    public async ValueTask DisposeAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Cleaned up!");
    }
}
