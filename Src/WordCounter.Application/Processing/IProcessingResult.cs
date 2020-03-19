namespace WordCounter.Application.Processing
{
    public interface IProcessingResult
    {
        public object GetResult();
        string GetStringRepresentation();   
    }
}