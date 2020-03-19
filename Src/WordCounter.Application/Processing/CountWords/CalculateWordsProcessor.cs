using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter.Application.Processing.CountWords
{
    public class CalculateWordsProcessor : ITextProcessor<int>
    {
        private static int ProcessText(string @string)
        {
            var (wordsCount, _) = @string.Aggregate((0, false), (countCharTuple, currChar) =>
            {
                var (count, inWord) = countCharTuple;
                var isNotWhitespace = !char.IsWhiteSpace(currChar);
                
                if (isNotWhitespace && !inWord)
                {
                    return (count + 1, true);
                }
                
                return (count,isNotWhitespace);
            });

            return wordsCount;
        }

        public async Task<GenericProcessingResult<int>> GetResultAsync(IAsyncEnumerable<string> text, CancellationToken token)
        {
            var wordsCount = await text.SumAsync(ProcessText, token);
            return CountWordsResult.Create(wordsCount);
        }

        async Task<IProcessingResult> ITextProcessor.GetResultAsync(IAsyncEnumerable<string> text, CancellationToken token)
        {
            var result = await GetResultAsync(text, token);
            return result;
        }
    }
}