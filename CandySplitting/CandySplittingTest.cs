using System;
using System.IO;
using NUnit.Framework;

namespace DNNX.GoogleCodeJam.CandySplitting.Test
{
    [TestFixture]
    public class CandySplittingTest
    {
        private CandySplitting _solution;
        
        [TestFixtureSetUp]
        public void Init()
        {
            _solution = new CandySplitting();
            
        }

        [Test]
        public void SmokeTest()
        {
            var input = new StringReader(@"
2
 5
 1 2 3 4 5
 3
 3 5 6
".Trim());
            var output = new StringWriter();
            var solution = new CandySplitting(input, output);
            
            solution.REPL();
           
            var expected = @"
Case #1: NO
Case #2: 11".Trim();
            Assert.AreEqual(expected, output.ToString().Trim());
        }
        
        [Test]
        public void EdgeCase()
        {
            Assert.AreEqual("NO", _solution.Solve(new[] {1}));
        }
        
    }
}
