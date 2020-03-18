using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application.Processing.CountWords;
using Xunit;

namespace WordCounter.Application.Test
{
    public class ShouldCalculateWordsInTextData: IEnumerable<object[]>
    {
        public IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new[] { "awawfa" }.ToAsyncEnumerable(), 1 };
            yield return new object[] { new[] { "" }.ToAsyncEnumerable(), 0 };
            yield return new object[] { new[] { "awawfa", "awfawf" }.ToAsyncEnumerable(), 2 };
            yield return new object[] { new[] { "awa wfa" }.ToAsyncEnumerable(), 2 };
            yield return new object[] { new[] { "aw  awfa" }.ToAsyncEnumerable(), 2 };
            yield return new object[] { new[] { "aw  aw-fa" }.ToAsyncEnumerable(), 2 };
            yield return new object[] { new[] { "aw  aw - fa" }.ToAsyncEnumerable(), 4 };
        }
        
        public IEnumerator<object[]> GetEnumerator()
        {
            return GetTestData().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public class CalculateWordsProcessorTest
    {
        [Theory]
        [ClassData(typeof(ShouldCalculateWordsInTextData))]
        public async Task ShouldCalculateWordsInText(IAsyncEnumerable<string> text, int wordsCount)
        {
            var wordsProcessor = new CalculateWordsProcessor();

            var wordsCountActualResult = await wordsProcessor.GetResultAsync(text, CancellationToken.None);
            
            Assert.Equal(wordsCountActualResult.Result, wordsCount);
        }
    }
}