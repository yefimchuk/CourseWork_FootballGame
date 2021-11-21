using System;

namespace PL
{
    public class ViewElement
    {
        public string Line { get; init; }
        public int Position { get; init; }

        public ViewElement(string line, int position)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentException("Line is null or empty...");

            if (position < 0)
                throw new ArgumentException("Position is less than zero...");

            Line = line;
            Position = position;
        }

        public override string ToString() => Line;
    }
}
