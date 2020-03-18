using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application.Processing;

namespace WordCounter.Application
{
    public interface IProcessingResultSaver
    {
        Task SaveAsync(IProcessingResult result, CancellationToken token);
    }
}