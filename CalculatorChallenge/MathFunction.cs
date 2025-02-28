using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorChallenge
{
    public class MathFunction
    {
        private double A;
        private double B;

        public MathFunction(double a, double b)
        {
            this.A = a;
            this.B = b;
        }

        public MathFunction(string a, string b)
        {
            this.A = Convert.ToInt32(a);
            this.B = Convert.ToInt32(b);
        }

        public double Multiplication()
        {
            return this.A * this.B;
        }

        public double Division()
        {
            if (this.B == 0) throw new DivideByZeroException();
            return this.A / this.B;
        }

        public double Subtraction()
        {
            return this.A - this.B;
        }

        public double Addition()
        {
            return this.A + this.B;
        }

        public double Exponential()
        {
            return Math.Pow(this.A, this.B);
        }
    }
}
