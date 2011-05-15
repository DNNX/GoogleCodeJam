﻿using System.IO;
using System.Linq;

namespace DNNX.GoogleCodeJam.Common
{
    public abstract class Solution<TTestCase>
    {
        private readonly TextReader _input;
        private readonly TextWriter _output;
        
        protected Solution(TextReader input, TextWriter output)
        {
            _input = input;
            _output = output;
        }
        
        protected string ReadString()
        {
            return _input.ReadLine();
        }
        
        protected int ReadInt()
        {
            return int.Parse(_input.ReadLine());
        }

        protected int[] ReadInts()
        {
            return _input.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
        
        public abstract TTestCase ReadTestCase();
        
        public abstract string Solve(TTestCase testCase);
        
        public void ReadSolveWriteLoop()
        {
            int numberOfTests = ReadInt();
            var tests = new TTestCase[numberOfTests];
            for (int i=0; i<numberOfTests; ++i)
            {
                tests[i] = ReadTestCase();
            }
            
            var answers = tests
                        .AsParallel()
                        .Select(Solve)
                        .ToArray();
            
            for (int i=0; i<numberOfTests; ++i)
            {
                _output.WriteLine("Case #{0}: {1}", i+1, answers[i]);
            }
        }
    }
}