using System;
namespace Overload
{
    public class Complex
    {
        private int Re;
        private int Im;

        public int A
        {
            get
            {
                return Re;
            }
            set
            {
                Re = value;
            }
        }
        
        public int B
        {
            get
            {
                return Im;
            }
            set
            {
                Im = value;
            }
        }

        public Complex()
        {
            Re = 0;
            Im = 0;
        }

        public Complex(int num)
        {
            Re = num;
            Im = num;
        }
        
        public Complex(int real, int imaginary)
        {
            Re = real;
            Im = imaginary;
        }
        
        // 1) Вычетание (Complex - Complex)
        // 2) Вычетание (Number  - Complex)
        // 3) Умножение (Complex * Complex)
        // 4) Умножение (Number  * Complex)
        // 5) Деление   (Complex / Complex)

        // 1 
        public static Complex operator -(Complex x, Complex y)
        {
            int zx, zy;
            zx = x.A - y.A;
            zy = x.B - y.B;
            Complex z = new Complex(zx,zy);
            return z;
        }
        // 2
        public static Complex operator -(int w, Complex x)
        {
            Complex y = new Complex(w);
            int zx, zy;
            zx = x.A - y.A;
            zy = x.B - y.B;
            Complex z = new Complex(zx,zy);
            return z;
        }
        // 2.5
        public static Complex operator -(Complex x, int w)
        {
            Complex y = new Complex(w);
            int zx, zy;
            zx = x.A - y.A;
            zy = x.B - y.B;
            Complex z = new Complex(zx,zy);
            return z;
        }
        // 3
        public static Complex operator *(Complex x, Complex y)
        {
            int zx, zy;
            zx = x.A * y.A - x.B * y.B;
            zy = x.A * y.B + x.B * y.A;
            Complex z = new Complex(zx,zy);
            return z;
        }
        // 4
        public static Complex operator *(int w, Complex y)
        {
            Complex x = new Complex(w);
            int zx, zy;
            zx = x.A * y.A - x.B * y.B;
            zy = x.A * y.B + x.B * y.A;
            Complex z = new Complex(zx,zy);
            return z;
        }
        // 5
        public static Complex operator /(Complex x, Complex y)
        {
            int zx, zy;
            zx = (x.A * y.A + x.B * y.B) / ((y.A * y.A) + (y.B * y.B));
            zy = (y.A * x.B - x.A * y.B) / ((y.A * y.A) + (y.B * y.B));
            Complex z = new Complex(zx,zy);
            return z;
        }
        
        public static bool operator ==(Complex x, Complex y)
        {
            if (x.A == y.A && x.B == y.B)
            {
                return true;
            }
            else return false;
        }
        public static bool operator !=(Complex x, Complex y)
        {
            if (x.A != y.A || x.B != y.B)
            {
                return true;
            }
            else return false;
        }
        
        public override string ToString()
        {
            return string.Format(A + "+" + B + "i");
        }
        
        public void ShowComplex()
        {
            Console.WriteLine(A + "+" + B + "i");
        }
        

    }
}