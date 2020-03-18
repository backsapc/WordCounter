using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application;
using WordCounter.Application.Processing;

namespace WordCounter.Infrastructure.Console
{
    public class ConsoleSaver: IProcessingResultSaver
    {
        public async Task SaveAsync(IProcessingResult result, CancellationToken token)
        {
            System.Console.WriteLine("Processing result is {0}.", result.GetStringRepresentation());
        }
    }
}