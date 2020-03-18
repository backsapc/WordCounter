using System;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application;
using WordCounter.Application.Processing;
using WordCounter.Application.Processing.CountWords;
using WordCounter.Infrastructure.Console;

namespace WordCounter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            var cts = new CancellationTokenSource();
            
            ITextProvider provider = new ConsoleProvider();
            ITextProcessor<int> processor = new CalculateWordsProcessor();
            IProcessingResultSaver saver = new ConsoleSaver();

            // How would you enter values?
            // What actions apply?
            // How to save the results?
            
            var text = provider.GetTextAsync(cts.Token);
            IProcessingResult result = await processor.GetResultAsync(text, cts.Token);
            await saver.SaveAsync(result, cts.Token);
        }
    }
}