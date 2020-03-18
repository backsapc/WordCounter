using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using WordCounter.Application;

namespace WordCounter.Infrastructure.Console
{
    public class ConsoleProvider: ITextProvider
    {
        private const string stopKeyword = "stop";
        public async IAsyncEnumerable<string> GetTextAsync([EnumeratorCancellation] CancellationToken token)
        {
            System.Console.WriteLine($"Enter string to calculate words (enter {stopKeyword} when done):");
            while (!token.IsCancellationRequested)
            {
                var @string = System.Console.ReadLine();
                if (@string == stopKeyword)
                {
                    yield break;
                }

                yield return @string;
            }
        }
    }
}