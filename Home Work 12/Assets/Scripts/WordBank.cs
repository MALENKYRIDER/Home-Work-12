using System;
using System.Linq;

namespace DefaultNamespace
{
    public class WordBank
    {
        private Word[] _words;
        private static Random _random;

        public WordBank()
        {
            _words = new[]
            {
                new Word("car"),
                new Word("dog"),
                new Word("ide"),
                new Word("ice"),
                new Word("sun"),
                new Word("game"),
                new Word("book"),
                new Word("unity"),
                new Word("mouse"),
                new Word("screen"),
                new Word("laptop"),
                new Word("mustang"),
                new Word("keyboard"),
                new Word("motorbike"),
                new Word("helicopter"),
            };
        }

        public Word Generate(Difficulty difficulty)
        {
            var words = _words.Where(word => word.Length >= difficulty.MinWordLength && 
                                             word.Length <= difficulty.MaxWordLength).ToArray();
            var random = new Random();
            int index =  random.Next(words.Length);
            return words[index];
        }
    }
}