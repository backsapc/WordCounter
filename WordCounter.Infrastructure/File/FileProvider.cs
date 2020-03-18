using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using WordCounter.Application;

namespace WordCounter.Infrastructure
{
    public class FileTextProvider : ITextProvider
    {
        static string GetPath()
        {
            var fileName = "text.txt";
            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            return path;
        }
        
        static IEnumerable<string> GetText(string path) =>
            File.ReadLines(path);
        
        public async IAsyncEnumerable<string> GetTextAsync([EnumeratorCancellation] CancellationToken token)
        {
            var path = GetPath();
            var text = GetText(path);
            foreach (var @string in text)
            {
                yield return @string;
            }
        }
    }
}