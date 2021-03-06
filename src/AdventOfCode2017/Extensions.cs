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

        public static string[] SplitOn(this string source, params string[] separators)
        {
            return source.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        public static IEnumerable<string> SplitLines(this string source, bool trimEnds = true)
        {
            return trimEnds
                ? source.SplitOn('\n').TrimEach()
                : source.SplitOn('\n');
        }

        public static IEnumerable<string> TrimEach(this IEnumerable<string> source)
        {
            return source.Select(x => x.Trim());
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key,
            TValue defaultValue = default(TValue))
        {
            return dict != null && dict.TryGetValue(key, out var value) ? value : defaultValue;
        }

        public static bool HasAny<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }

        public static string AsString(this IEnumerable<char> chars)
        {
            return chars.HasAny() ? new string(chars.ToArray()) : string.Empty;
        }

        public static string OrderedString(this string source)
        {
            return source?.OrderBy(c => c).AsString() ?? string.Empty;
        }

        public static (int index, int? value) MaxOf(this IList<int> source)
        {
            if (!source.HasAny())
                return (-1, null);

            var index = 0;
            var value = source[0];
            for (var k = 1; k < source.Count; ++k)
            {
                if (source[k] > value)
                {
                    value = source[k];
                    index = k;
                }
            }
            return (index, value);
        }

        public static string JoinStrings<T>(this IEnumerable<T> source, string separator = "")
        {
            return source.HasAny()
                ? string.Join(separator, source)
                : string.Empty;
        }

        public static TEnum ParseEnum<TEnum>(this string value, bool ignoreCase = true, TEnum defaultValue = default(TEnum))
            where TEnum : struct, System.Enum
        {
            if (!typeof(TEnum).IsEnum)
                throw new InvalidOperationException("Given type is not an enum");

            return Enum.TryParse(value, ignoreCase, out TEnum result)
                ? result
                : defaultValue;
        }

        public static IList<TEnum> ParseEnums<TEnum>(this IEnumerable<string> source, bool ignoreCase = true, TEnum defaultValue = default(TEnum))
            where TEnum : struct, System.Enum
        {
            return source.HasAny()
                ? source.Select(x => x.ParseEnum<TEnum>(ignoreCase, defaultValue)).ToList()
                : Enumerable.Empty<TEnum>().ToList();
        }
    }
}
