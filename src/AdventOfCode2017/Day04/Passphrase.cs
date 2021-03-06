﻿using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day04
{
    public class Passphrase
    {
        public string Phrase { get; }
        public List<string> Words { get; }

        public bool IsValidByWordCount => new HashSet<string>(Words).Count == Words.Count;

        public bool IsValidByAnagramDetection => new HashSet<string>(Words.Select(x => x.OrderedString())).Count == Words.Count;

        public Passphrase(string phrase)
        {
            Phrase = phrase;
            Words = Phrase.SplitOn(' ').ToList();
        }
    }
}
