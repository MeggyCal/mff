using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cuni.Arithmetics.FixedPoint;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarky
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BenchmarkDotNet.Reports.Summary> reports = new List<BenchmarkDotNet.Reports.Summary>();
            reports.Add(BenchmarkRunner.Run<AddTests>());
            reports.Add(BenchmarkRunner.Run<SubtractTests>());
            reports.Add(BenchmarkRunner.Run<MultiplyTests>());
            reports.Add(BenchmarkRunner.Run<DivideTests>());

            //Console.Clear();

            foreach (var report in reports)
            {
                Console.WriteLine(report.Title);
                foreach (var row in report.Table.FullContent)
                    Console.WriteLine(String.Format("    {0, -20}:  {1}", row[0], row[41]));                
            }

            while (true)
            {
                Console.ReadKey();
            }
        }
    }


    public class AddTests
    {
        int a = 512;
        int b = 42;

        [Benchmark]
        public void Q24_8Test()
        {
            var f1 = new Fixed<Q24_8>(a);
            var f2 = new Fixed<Q24_8>(b);
            var f3 = f1.Add(f2);
        }
        [Benchmark]
        public void Q16_16Test()
        {
            var f1 = new Fixed<Q16_16>(a);
            var f2 = new Fixed<Q16_16>(b);
            var f3 = f1.Add(f2);
        }
        [Benchmark]
        public void Q8_24Test()
        {
            var f1 = new Fixed<Q8_24>(a);
            var f2 = new Fixed<Q8_24>(b);
            var f3 = f1.Add(f2);
        }
        [Benchmark]
        public void FloatTest()
        {
            var f1 = (float)a;
            var f2 = (float)b;
            var f3 = f1 + f2;
        }
        [Benchmark]
        public void DoubleTest()
        {
            var f1 = (double)a;
            var f2 = (double)b;
            var f3 = f1 + f2;
        }
    }
    public class SubtractTests
    {
        int a = 512;
        int b = 42;

        [Benchmark]
        public void Q24_8Test()
        {
            var f1 = new Fixed<Q24_8>(a);
            var f2 = new Fixed<Q24_8>(b);
            var f3 = f1.Subtract(f2);
        }
        [Benchmark]
        public void Q16_16Test()
        {
            var f1 = new Fixed<Q16_16>(a);
            var f2 = new Fixed<Q16_16>(b);
            var f3 = f1.Subtract(f2);
        }
        [Benchmark]
        public void Q8_24Test()
        {
            var f1 = new Fixed<Q8_24>(a);
            var f2 = new Fixed<Q8_24>(b);
            var f3 = f1.Subtract(f2);
        }
        [Benchmark]
        public void FloatTest()
        {
            var f1 = (float)a;
            var f2 = (float)b;
            var f3 = f1 - f2;
        }
        [Benchmark]
        public void DoubleTest()
        {
            var f1 = (double)a;
            var f2 = (double)b;
            var f3 = f1 - f2;
        }
    }
    public class MultiplyTests
    {
        int a = 512;
        int b = 42;

        [Benchmark]
        public void Q24_8Test()
        {
            var f1 = new Fixed<Q24_8>(a);
            var f2 = new Fixed<Q24_8>(b);
            var f3 = f1.Multiply(f2);
        }
        [Benchmark]
        public void Q16_16Test()
        {
            var f1 = new Fixed<Q16_16>(a);
            var f2 = new Fixed<Q16_16>(b);
            var f3 = f1.Multiply(f2);
        }
        [Benchmark]
        public void Q8_24Test()
        {
            var f1 = new Fixed<Q8_24>(a);
            var f2 = new Fixed<Q8_24>(b);
            var f3 = f1.Multiply(f2);
        }
        [Benchmark]
        public void FloatTest()
        {
            var f1 = (float)a;
            var f2 = (float)b;
            var f3 = f1 * f2;
        }
        [Benchmark]
        public void DoubleTest()
        {
            var f1 = (double)a;
            var f2 = (double)b;
            var f3 = f1 * f2;
        }
    }
    public class DivideTests
    {
        int a = 512;
        int b = 42;

        [Benchmark]
        public void Q24_8Test()
        {
            var f1 = new Fixed<Q24_8>(a);
            var f2 = new Fixed<Q24_8>(b);
            var f3 = f1.Divide(f2);
        }
        [Benchmark]
        public void Q16_16Test()
        {
            var f1 = new Fixed<Q16_16>(a);
            var f2 = new Fixed<Q16_16>(b);
            var f3 = f1.Divide(f2);
        }
        [Benchmark]
        public void Q8_24Test()
        {
            var f1 = new Fixed<Q8_24>(a);
            var f2 = new Fixed<Q8_24>(b);
            var f3 = f1.Divide(f2);
        }
        [Benchmark]
        public void FloatTest()
        {
            var f1 = (float)a;
            var f2 = (float)b;
            var f3 = f1 / f2;
        }
        [Benchmark]
        public void DoubleTest()
        {
            var f1 = (double)a;
            var f2 = (double)b;
            var f3 = f1 / f2;
        }
    }
}
