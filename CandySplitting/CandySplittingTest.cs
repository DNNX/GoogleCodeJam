using System;
using System.IO;
using NUnit.Framework;
using DNNX.GoogleCodeJam.Common;

namespace DNNX.GoogleCodeJam.CandySplitting.Test
{
    [TestFixture]
    public class CandySplittingTest : BaseTest<int[]>
    {
        [Test]
        public void SmokeTest()
        {
            var input = @"
2
 5
 1 2 3 4 5
 3
 3 5 6";
            
            var expectedOutput = @"
Case #1: NO
Case #2: 11";

            SmokeTest(input, expectedOutput);
        }
        
        [Test]
        public void EdgeCase()
        {
            Assert.AreEqual("NO", CreateSolution().Solve(new[] {1}));
        }
        
        
        protected override Solution<int[]> CreateSolution(TextReader input, TextWriter output)
        {
            return new CandySplitting(input, output);
        }
    }
}
