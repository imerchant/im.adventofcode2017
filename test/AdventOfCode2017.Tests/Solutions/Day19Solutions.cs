﻿using System;
using AdventOfCode2017.Day19;
using AdventOfCode2017.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2017.Tests.Solutions
{
    public class Day19Solutions : TestBase
    {
        public Day19Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1And2_DiagramCompletesTheWalk_AndCountsSteps()
        {
            var diagram = new RoutingDiagram(Input.Day19Parse(Input.Day19));
            var steps = 0;

            Action walk = () =>
            {
                while(true)
                {
                    steps++;
                    diagram.Step();
                }
            };

            walk.Should().Throw<Exception>().WithMessage("End of path? Visited: EPYDUXANIT");
            steps.Should().Be(17544);
        }

        [Fact]
        public void Diagram_IdentifiesStartingPointCorrectly_WithRealInput()
        {
            var diagram = new RoutingDiagram(Input.Day19Parse(Input.Day19));

            diagram.StartingPoint.Should().Be((0, 163));
        }

        private const string Puzzle1Example =
@"     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ ";

        [Fact]
        public void GridParsesCorrectly()
        {
            var diagram = new RoutingDiagram(Input.Day19Parse(Puzzle1Example));

            diagram.ToString().Should().Be(Puzzle1Example);

            Output.WriteLine(diagram.ToString());

            diagram.StartingPoint.Should().Be((0, 5));
        }
    }
}
