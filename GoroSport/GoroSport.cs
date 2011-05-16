using System;
using System.IO;
using System.Linq;
using DNNX.GoogleCodeJam.Common;

namespace DNNX.GoogleCodeJam.GoroSport
{
    public class GoroSport : Solution<int[]>
    {
        public GoroSport(TextReader input, TextWriter output)
            : base(input, output)
        {
        }
        
        public GoroSport() {}
        
        public override object Solve(int[] a)
        {
            int count = 0;
            for (int i=0; i<a.Length; ++i)
                if (i+1 != a[i])
                    ++count;
            return count;
        }
        
        public override int[] ReadTestCase()
        {
            ReadString();
            return ReadInts();
        }
    
        public static void Main(string[] args)
        {
            new GoroSport().REPL();
            Console.ReadLine();
        }    
    }
}