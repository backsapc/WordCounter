using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter.Application.Processing
{
    public interface ITextProcessor<T>
    {
        Task<GenericProcessingResult<T>> GetResultAsync(IAsyncEnumerable<string> text, CancellationToken token);
    }
}