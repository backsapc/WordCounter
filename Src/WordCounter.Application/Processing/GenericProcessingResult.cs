namespace WordCounter.Application.Processing
{
    public abstract class GenericProcessingResult<T>: IProcessingResult
    {
        protected GenericProcessingResult(T result)
        {
            Result = result;
        }
        
        public T Result { get; }
        
        object IProcessingResult.GetResult()
        {
            return Result;
        }

        public abstract string GetStringRepresentation();
    }
}