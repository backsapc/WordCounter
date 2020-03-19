using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter.Application.Processing
{
    public interface ITextProcessor
    {
        Task<IProcessingResult> GetResultAsync(IAsyncEnumerable<string> text, CancellationToken token);
    }
    
    public interface ITextProcessor<T>: ITextProcessor
    {
        new Task<GenericProcessingResult<T>> GetResultAsync(IAsyncEnumerable<string> text, CancellationToken token);
    }
}