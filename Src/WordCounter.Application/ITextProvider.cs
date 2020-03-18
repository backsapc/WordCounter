using System.Collections.Generic;
using System.Threading;

namespace WordCounter.Application
{
    public interface ITextProvider
    {
        IAsyncEnumerable<string> GetTextAsync(CancellationToken token);
    }
}