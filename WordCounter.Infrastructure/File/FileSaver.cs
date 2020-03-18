using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application;
using WordCounter.Application.Processing;

namespace WordCounter.Infrastructure
{
    public class ProcessingResultSaver : IProcessingResultSaver
    {
        public async Task SaveAsync(IProcessingResult result, CancellationToken token)
        {
            const string fileName = "result.txt";
            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            
            await File.WriteAllTextAsync(path, result.GetStringRepresentation(), token);
        }
    }
}