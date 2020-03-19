using System;

namespace WordCounter.Infrastructure
{
    public class Option<T>
    {
        public int Index { get; }
        public String Title { get; }
        public T Value { get; }

        public Option(int index, string title, T value)
        {
            Index = index;
            Title = title;
            Value = value;
        }
    }
}