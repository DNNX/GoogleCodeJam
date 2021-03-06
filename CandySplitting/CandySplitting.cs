﻿using System;
using System.IO;
using System.Linq;
using DNNX.GoogleCodeJam.Common;

namespace DNNX.GoogleCodeJam.CandySplitting
{
    public class CandySplitting : Solution<int[]>
    {
        public CandySplitting(TextReader input, TextWriter output)
            : base(input, output)
        {
        }
        
        public CandySplitting() {}
        
        public override object Solve(int[] a)
        {
            int xor = a.Aggregate(0, (s, x) => s ^ x);
            if (xor != 0)
                return "NO";
            return a.Sum() - a.Min();
        }
        
        public override int[] ReadTestCase()
        {
            ReadString();
            return ReadInts();
        }
    
        public static void Main(string[] args)
        {
            new CandySplitting().REPL();
            Console.ReadLine();
        }    
    }
}