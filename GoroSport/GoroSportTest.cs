using System;
using System.IO;
using NUnit.Framework;
using DNNX.GoogleCodeJam.Common;

namespace DNNX.GoogleCodeJam.GoroSport.Test
{
    [TestFixture]
    public class GoroSportTest : BaseTest<int[]>
    {
        [Test]
        public void SmokeTest()
        {
            var input = @"
3
 2
 2 1
 3
 1 3 2
 4
 2 1 4 3";
            
            var expectedOutput = @"
Case #1: 2
Case #2: 2
Case #3: 4";

            SmokeTest(input, expectedOutput);
        }
        
        [Test]
        public void EdgeCase()
        {
            Assert.AreEqual(4, CreateSolution().Solve(new[] {1, 2, 5, 4, 3, 7, 6}));
        }
        
        
        protected override Solution<int[]> CreateSolution(TextReader input, TextWriter output)
        {
            return new GoroSport(input, output);
        }
    }
}
