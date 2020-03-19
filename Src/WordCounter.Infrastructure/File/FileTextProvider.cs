using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using WordCounter.Application;

namespace WordCounter.Infrastructure.File
{
    public class FileTextProvider : ITextProvider
    {
        private readonly string _filePath;

        public FileTextProvider(string filePath)
        {
            _filePath = filePath;
        }

        static IEnumerable<string> GetText(string path) =>
            System.IO.File.ReadLines(path);
        
        public async IAsyncEnumerable<string> GetTextAsync([EnumeratorCancellation] CancellationToken token)
        {
            var text = GetText(_filePath);
            foreach (var @string in text)
            {
                yield return @string;
            }
        }
    }
}