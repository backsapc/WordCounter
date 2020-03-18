namespace WordCounter.Application.Processing.CountWords
{
    internal class CountWordsResult : IntProcessingResult
    {
        private CountWordsResult(int result): base(result)
        {
            
        }
        
        internal static CountWordsResult Create(int result) =>
            new CountWordsResult(result);
        
        public override string GetStringRepresentation()
        {
            return Result.ToString();
        }
    }
}