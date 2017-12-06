﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Extensions
    {
        public static string[] SplitOn(this string source, params char[] separators)
        {
            return source.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        public static IEnumerable<string> SplitLines(this string source)
        {
            return source.SplitOn('\n').TrimEach();
        }

        public static IEnumerable<string> TrimEach(this IEnumerable<string> source)
        {
            return source.Select(x => x.Trim());
        }
    }
}