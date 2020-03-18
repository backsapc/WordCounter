using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application;
using WordCounter.Application.Processing;

namespace WordCounter.Infrastructure.File
{
    public class ProcessingResultSaver : IProcessingResultSaver
    {
        public async Task SaveAsync(IProcessingResult result, CancellationToken token)
        {
            const string fileName = "result.txt";
            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            
            await System.IO.File.WriteAllTextAsync(path, result.GetStringRepresentation(), token);
        }
    }
}