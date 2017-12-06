﻿using System.Linq;
using AdventOfCode2017.Day03;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2017.Tests.Solutions
{
    public class Day03Solutions : TestBase
    {
        public Day03Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(9, 1, -1)]
        [InlineData(10, 2, -1)]
        [InlineData(11, 2, 0)]
        [InlineData(12, 2, 1)]
        [InlineData(13, 2, 2)]
        [InlineData(14, 1, 2)]
        [InlineData(15, 0, 2)]
        public void Grid_CanRunTo_9_AndGetCoordCorrectly(int target, int expectedX, int expectedY)
        {
            var grid = new Grid();

            var (x, y, coords) = grid.RunTo(target);

            PrintObj(coords.Select((coord, index) => $"{index + 1}: {coord}"));

            x.Should().Be(expectedX);
            y.Should().Be(expectedY);
        }
    }
}
