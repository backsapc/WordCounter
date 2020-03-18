namespace WordCounter.Application.Processing
{
    internal class IntProcessingResult: GenericProcessingResult<int>
    {
        protected IntProcessingResult(int result): base(result)
        {
            
        }
        
        public override string GetStringRepresentation()
        {
            return Result.ToString();
        }
    }
}