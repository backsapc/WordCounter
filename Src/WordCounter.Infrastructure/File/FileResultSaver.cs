using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application;
using WordCounter.Application.Processing;

namespace WordCounter.Infrastructure.File
{
    public class FileResultSaver : IProcessingResultSaver
    {
        private readonly string _filePath;

        public FileResultSaver(string filePath)
        {
            _filePath = filePath;
        }

        public async Task SaveAsync(IProcessingResult result, CancellationToken token)
        {
            await System.IO.File.WriteAllTextAsync(_filePath, result.GetStringRepresentation(), token);
        }
    }
}