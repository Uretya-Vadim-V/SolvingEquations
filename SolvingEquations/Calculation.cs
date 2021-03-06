using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace SolvingEquations
{
    public static class Calculation
    {
        //Решение уравнения второй степени
        public static IEnumerable<Complex> EquationOfTheSecondDegree(double a0, double a1, double a2)
        {
            double disc = a1 * a1 - 4 * a0 * a2;
            if (disc < 1E-14 && disc > -1E-14)
                disc = 0;
            if (disc < 0)
            {
                double bufer = Math.Sqrt(-disc) / 2 / a0;
                if (bufer < 1E-9 && bufer > -1E-9)
                    bufer = 0;
                return new List<Complex> { new Complex(-a1 / 2 / a0, bufer), new Complex(-a1 / 2 / a0, -bufer) };
            }
            else
            {
                return new List<Complex> { new Complex((-a1 - Math.Sqrt(disc)) / 2 / a0, 0), new Complex((-a1 + Math.Sqrt(disc)) / 2 / a0, 0) };
            }
        }

        //Решение уравнения третьей степени
        public static IEnumerable<Complex> EquationOfTheThirdDegree(double a0, double a1, double a2, double a3)
        {
            double a = a1 / a0, b = a2 / a0, c = a3 / a0;
            double q = Math.Pow(a, 2) - 3 * b;
            double r = 2 * Math.Pow(a, 3) - 9 * a * b + 27 * c;
            if (Math.Pow(r, 2) / 2916 < Math.Pow(q, 3) / 729)
            {
                double t = Math.Acos(r / Math.Sqrt(Math.Pow(q, 3)) / 2) / 3;
                if (t < 1E-14 && t > -1E-14)
                    t = 0;
                double x1 = -2 * Math.Sqrt(q) / 3 * Math.Cos(t) - a / 3;
                double x2 = -2 * Math.Sqrt(q) / 3 * Math.Cos(t + (2 * Math.PI / 3)) - a / 3;
                double x3 = -2 * Math.Sqrt(q) / 3 * Math.Cos(t - (2 * Math.PI / 3)) - a / 3;
                return new List<Complex> { x1, x2, x3 };
            }
            else
            {
                double A = -Math.Sign(r == 0 ? 1 : r) * Math.Pow(3 * Math.Abs(r) + Math.Sqrt(9 * Math.Pow(r, 2) - 36 * Math.Pow(q, 3)), (double)1 / 3) / 3 / Math.Pow(6, (double)1 / 3);
                if (A < 1E-14 && A > -1E-14)
                    A = 0;
                double B = (A == 0) ? 0 : q / A / 9;
                double x1 = (A + B) - a / 3;
                if (A - B < 1E-14 && A - B > -1E-14)
                {
                    double x2 = -A - a / 3;
                    return new List<Complex> { x1, x2 };
                }
                else
                {
                    double bufer = Math.Sqrt(3) * (A - B) / 2;
                    if (bufer < 1E-9 && bufer > -1E-9)
                        bufer = 0;
                    Complex x2 = new Complex(-(A + B) / 2 - (a / 3), bufer);
                    Complex x3 = new Complex(-(A + B) / 2 - (a / 3), -bufer);
                    return new List<Complex> { x1, x2, x3 };
                }
            }
        }

        //Решение уравнения четвёртой степени
        public static IEnumerable<Complex> EquationOfTheFourthDegree(double a0, double a1, double a2, double a3, double a4)
        {
            if (a1 == 0 && a2 == 0 && a3 == 0 && a4 == 0)
            {
                return new List<Complex> { 0 };
            }
            else
            {
                if (a1 == 0 && a3 == 0 && a4 == 0)
                {
                    if (-a2 / a0 >= 0)
                    {
                        double x1 = Math.Sqrt(-a2 / a0);
                        double x2 = Math.Sqrt(-a2 / a0);
                        return new List<Complex> { 0, x1, x2 };
                    }
                    else
                    {
                        Complex x1 = new Complex(0, Math.Sqrt(a2 / a0));
                        Complex x2 = new Complex(0, Math.Sqrt(a2 / a0));
                        return new List<Complex> { 0, x1, x2 };
                    }
                }
                else
                {
                    if (a3 == 0 && a4 == 0)
                    {
                        IEnumerable<Complex> list = EquationOfTheSecondDegree(a0, a1, a2);
                        List<Complex> listRes = new List<Complex>();
                        listRes.Add(0);
                        foreach (Complex item in list)
                        {
                            listRes.Add(item);
                        }
                        return listRes;
                    }
                    else
                    {
                        double F(Complex x)
                        {
                            return (Math.Pow(x.Real, 4) - 2 * Math.Pow(x.Real, 2) * Math.Pow(x.Imaginary, 2) + Math.Pow(x.Imaginary, 4)) * a0 +
                                          (Math.Pow(x.Real, 2) - Math.Pow(x.Imaginary, 2)) * a2 + a4;
                        }
                        if (a1 == 0 && a3 == 0)
                        {
                            IEnumerable<Complex> list = EquationOfTheSecondDegree(a0, a2, a4);
                            List<Complex> listRes = new List<Complex>();
                            foreach (Complex item in list)
                            {
                                listRes.Add(item);
                            }
                            double r0 = Math.Sqrt(Math.Sqrt(Math.Pow(listRes[0].Real, 2) + Math.Pow(listRes[0].Imaginary, 2)));
                            double r1 = Math.Sqrt(Math.Sqrt(Math.Pow(listRes[1].Real, 2) + Math.Pow(listRes[1].Imaginary, 2)));
                            double arg0_1 = Math.Atan(listRes[0].Imaginary / listRes[0].Real) / 2;
                            double arg1_1 = Math.Atan(listRes[1].Imaginary / listRes[1].Real) / 2;
                            double arg0_2 = Math.Atan(listRes[0].Imaginary / listRes[0].Real) / 2 + Math.PI / 2;
                            double arg1_2 = Math.Atan(listRes[1].Imaginary / listRes[1].Real) / 2 + Math.PI / 2;
                            Complex x1 = new Complex(r0 * Math.Cos(arg0_1), r0 * Math.Sin(arg0_1));
                            if (F(x1) > 1E-9 || F(x1) < -1E-9)
                                x1 = new Complex(r0 * Math.Cos(arg0_2), r0 * Math.Sin(arg0_2));
                            Complex x2 = new Complex(-r0 * Math.Cos(arg0_1), -r0 * Math.Sin(arg0_1));
                            if (F(x2) > 1E-9 || F(x2) < -1E-9)
                                x2 = new Complex(-r0 * Math.Cos(arg0_2), -r0 * Math.Sin(arg0_2));
                            Complex x3 = new Complex(r1 * Math.Cos(arg1_1), r1 * Math.Sin(arg1_1));
                            if (F(x3) > 1E-9 || F(x3) < -1E-9)
                                x3 = new Complex(r1 * Math.Cos(arg1_2), r1 * Math.Sin(arg1_2));
                            Complex x4 = new Complex(-r1 * Math.Cos(arg1_1), -r1 * Math.Sin(arg1_1));
                            if (F(x4) > 1E-9 || F(x4) < -1E-9)
                                x4 = new Complex(-r1 * Math.Cos(arg1_2), -r1 * Math.Sin(arg1_2));
                            return new List<Complex> { x1, x2, x3, x4 };
                        }
                        else
                        {
                            double a = a1 / a0, b = a2 / a0, c = a3 / a0, d = a4 / a0;
                            double p = b - 3 * Math.Pow(a, 2) / 8;
                            double q = Math.Pow(a, 3) / 8 - a * b / 2 + c;
                            double r = -3 * Math.Pow(a, 4) / 256 + Math.Pow(a, 2) * b / 16 - c * a / 4 + d;
                            IEnumerable<Complex> list = EquationOfTheThirdDegree(2, -p, -2 * r, r * p - Math.Pow(q, 2) / 4);
                            double s = double.MaxValue;
                            foreach (Complex item in list)
                            {
                                if (item.Imaginary % 1 < 1E-14 && item.Imaginary % 1 > -1E-14)
                                {
                                    if (item.Real > 1E-14 || item.Real < -1E-14)
                                    {
                                        s = item.Real;
                                        if (item.Real % 1 == 0)
                                        {
                                            s = item.Real;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (2 * s - p > 0)
                            {
                                double dis1 = 2 * s - p - 2 * q / Math.Sqrt(2 * s - p) - 4 * s;
                                double dis2 = 2 * s - p + 2 * q / Math.Sqrt(2 * s - p) - 4 * s;
                                if (dis1 < 1E-14 && dis1 > -1E-14)
                                    dis1 = 0;
                                if (dis2 < 1E-14 && dis2 > -1E-14)
                                    dis2 = 0;
                                if (dis1 >= 0 && dis2 > 0)
                                {
                                    double x1 = Math.Sqrt(2 * s - p) / 2 - Math.Sqrt(dis1) / 2 - a / 4;
                                    double x2 = Math.Sqrt(2 * s - p) / 2 + Math.Sqrt(dis1) / 2 - a / 4;
                                    double x3 = -Math.Sqrt(2 * s - p) / 2 - Math.Sqrt(dis2) / 2 - a / 4;
                                    double x4 = -Math.Sqrt(2 * s - p) / 2 + Math.Sqrt(dis2) / 2 - a / 4;
                                    return new List<Complex> { x1, x2, x3, x4 };
                                }
                                else
                                {
                                    if (dis1 >= 0 && dis2 < 0)
                                    {
                                        double x1 = Math.Sqrt(2 * s - p) / 2 - Math.Sqrt(dis1) / 2 - a / 4;
                                        double x2 = Math.Sqrt(2 * s - p) / 2 + Math.Sqrt(dis1) / 2 - a / 4;
                                        Complex x3 = new Complex(-Math.Sqrt(2 * s - p) / 2 - a / 4, -Math.Sqrt(-dis2) / 2);
                                        Complex x4 = new Complex(-Math.Sqrt(2 * s - p) / 2 - a / 4, Math.Sqrt(-dis2) / 2);
                                        return new List<Complex> { x1, x2, x3, x4 };
                                    }
                                    else
                                    {
                                        if (dis1 < 0 && dis2 >= 0)
                                        {
                                            Complex x1 = new Complex(Math.Sqrt(2 * s - p) / 2 - a / 4, -Math.Sqrt(-dis1) / 2);
                                            Complex x2 = new Complex(Math.Sqrt(2 * s - p) / 2 - a / 4, Math.Sqrt(-dis1) / 2);
                                            double x3 = -Math.Sqrt(2 * s - p) / 2 - Math.Sqrt(dis2) / 2 - a / 4;
                                            double x4 = -Math.Sqrt(2 * s - p) / 2 + Math.Sqrt(dis2) / 2 - a / 4;
                                            return new List<Complex> { x1, x2, x3, x4 };
                                        }
                                        else
                                        {
                                            Complex x1 = new Complex(Math.Sqrt(2 * s - p) / 2 - a / 4, -Math.Sqrt(-dis1) / 2);
                                            Complex x2 = new Complex(Math.Sqrt(2 * s - p) / 2 - a / 4, Math.Sqrt(-dis1) / 2);
                                            Complex x3 = new Complex(-Math.Sqrt(2 * s - p) / 2 - a / 4, -Math.Sqrt(-dis2) / 2);
                                            Complex x4 = new Complex(-Math.Sqrt(2 * s - p) / 2 - a / 4, Math.Sqrt(-dis2) / 2);
                                            return new List<Complex> { x1, x2, x3, x4 };
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (2 * s - p < 0)
                                {
                                    Complex dis1 = new Complex(2 * s - p - 4 * s, 2 * q * Math.Sqrt(p - 2 * s) / (p - 2 * s));
                                    Complex dis2 = new Complex(2 * s - p - 4 * s, -2 * q * Math.Sqrt(p - 2 * s) / (p - 2 * s));
                                    if (dis1.Imaginary < 1E-14 && dis1.Imaginary > -1E-14)
                                        dis1 = new Complex(dis1.Real, 0);
                                    if (dis2.Imaginary < 1E-14 && dis2.Imaginary > -1E-14)
                                        dis2 = new Complex(dis2.Real, 0);
                                    double r1 = Math.Sqrt(Math.Pow(dis1.Real, 2) + Math.Pow(dis1.Imaginary, 2));
                                    double r2 = Math.Sqrt(Math.Pow(dis2.Real, 2) + Math.Pow(dis2.Imaginary, 2));
                                    double arg1 = Math.Atan(dis1.Imaginary / dis1.Real);
                                    double arg2 = Math.Atan(dis2.Imaginary / dis2.Real);
                                    if (arg1 < 1E-14 && arg1 > -1E-14)
                                        arg1 = 0;
                                    if (arg2 < 1E-14 && arg2 > -1E-14)
                                        arg2 = 0;
                                    Complex x1 = new Complex(-Math.Sqrt(r1) * Math.Cos(arg1 / 2) / 2 - a / 4, Math.Sqrt(p - 2 * s) / 2 - Math.Sqrt(r1) * Math.Sin(arg1 / 2) / 2);
                                    Complex x2 = new Complex(Math.Sqrt(r1) * Math.Cos(arg1 / 2) / 2 - a / 4, Math.Sqrt(p - 2 * s) / 2 + Math.Sqrt(r1) * Math.Sin(arg1 / 2) / 2);
                                    Complex x3 = new Complex(-Math.Sqrt(r2) * Math.Cos(arg2 / 2) / 2 - a / 4, -Math.Sqrt(p - 2 * s) / 2 - Math.Sqrt(r2) * Math.Sin(arg2 / 2) / 2);
                                    Complex x4 = new Complex(Math.Sqrt(r2) * Math.Cos(arg2 / 2) / 2 - a / 4, -Math.Sqrt(p - 2 * s) / 2 + Math.Sqrt(r2) * Math.Sin(arg2 / 2) / 2);
                                    return new List<Complex> { x1, x2, x3, x4 };
                                }
                                else
                                {
                                    Complex x1, x2, x3, x4;
                                    if (Math.Pow(p, 2) - 4 * r >= 0)
                                    {
                                        if (-p / 2 + Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2 >= 0)
                                        {
                                            x1 = Math.Sqrt(-p / 2 + Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2) - a / 4;
                                            x2 = -Math.Sqrt(-p / 2 + Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2) - a / 4;
                                        }
                                        else
                                        {
                                            x1 = new Complex(-a / 4, Math.Sqrt(p / 2 - Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2));
                                            x2 = new Complex(-a / 4, -Math.Sqrt(p / 2 - Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2));
                                        }
                                        if (-p / 2 - Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2 >= 0)
                                        {
                                            x3 = Math.Sqrt(-p / 2 - Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2) - a / 4;
                                            x4 = -Math.Sqrt(-p / 2 - Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2) - a / 4;
                                        }
                                        else
                                        {
                                            x3 = new Complex(-a / 4, Math.Sqrt(p / 2 + Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2));
                                            x4 = new Complex(-a / 4, -Math.Sqrt(p / 2 + Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2));
                                        }
                                    }
                                    else
                                    {
                                        if (-p / 2 + Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2 >= 0)
                                        {
                                            x1 = Math.Sqrt(-p / 2 + Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2) - a / 4;
                                            x2 = -Math.Sqrt(-p / 2 + Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2) - a / 4;
                                        }
                                        else
                                        {
                                            x1 = new Complex(-a / 4, Math.Sqrt(p / 2 - Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2));
                                            x2 = new Complex(-a / 4, -Math.Sqrt(p / 2 - Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2));
                                        }
                                        if (-p / 2 - Math.Sqrt(Math.Pow(p, 2) - 4 * r) / 2 >= 0)
                                        {
                                            x3 = Math.Sqrt(-p / 2 - Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2) - a / 4;
                                            x4 = -Math.Sqrt(-p / 2 - Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2) - a / 4;
                                        }
                                        else
                                        {
                                            x3 = new Complex(-a / 4, Math.Sqrt(p / 2 + Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2));
                                            x4 = new Complex(-a / 4, -Math.Sqrt(p / 2 + Math.Sqrt(4 * r - Math.Pow(p, 2)) / 2));
                                        }
                                    }
                                    return new List<Complex> { x1, x2, x3, x4 };
                                }
                            }
                        }
                    }
                }
            }
        }

        //Решение уравнения пятой степени
        public static IEnumerable<Complex> EquationOfTheFifthDegree(double a0, double a1, double a2, double a3, double a4, double a5)
        {
            double a = a1 / a0, b = a2 / a0, c = a3 / a0, d = a4 / a0, e = a5 / a0;
            double brd = Math.Max(Math.Abs(a), Math.Max(Math.Abs(b), Math.Max(Math.Abs(c), Math.Max(Math.Abs(d), Math.Abs(e)))));
            double step = 1E-2;
            double number;
            double x1 = double.MaxValue;
            IEnumerable<Complex> list = new List<Complex>();
            List<Complex> listResults = new List<Complex>();
            for (double i = -brd; i <= brd; i += step)
            {
                i = Math.Round(i, 2);
                number = Math.Pow(i, 5) * a0 + Math.Pow(i, 4) * a1 + Math.Pow(i, 3) * a2 + Math.Pow(i, 2) * a3 + i * a4 + a5;
                if (number == 0)
                {
                    x1 = i;
                    break;
                }
            }
            if (x1 < double.MaxValue)
            {
                listResults.Add(x1);
            }
            else
            {
                // Метод Ньютона
                x1 = -brd;
                double Fx(double i)
                {
                    return Math.Pow(i, 5) * a0 + Math.Pow(i, 4) * a1 + Math.Pow(i, 3) * a2 + Math.Pow(i, 2) * a3 + i * a4 + a5;
                }
                double F_x(double i)
                {
                    return Math.Pow(i, 4) * a0 * 5 + Math.Pow(i, 3) * a1 * 4 + Math.Pow(i, 2) * a2 * 3 + i * a3 * 2 + a4;
                }
                while (Math.Abs(Fx(x1)) > 1E-9)
                    x1 = x1 - Fx(x1) / F_x(x1);
                listResults.Add(x1);
            }
            if (a1 == 0 && a2 == 0 && a3 == 0 && a4 == 0 && a5 == 0)
            {
            }
            else
            {
                if (a2 == 0 && a3 == 0 && a4 == 0 && a5 == 0)
                {
                    listResults.Add(-a1 / a0);
                }
                else
                {
                    if (a1 == 0 && a3 == 0 && a4 == 0 && a5 == 0)
                    {
                        if (-a2 / a0 >= 0)
                        {
                            listResults.Add(Math.Sqrt(-a2 / a0));
                            listResults.Add(Math.Sqrt(-a2 / a0));
                        }
                        else
                        {
                            listResults.Add(new Complex(0, Math.Sqrt(a2 / a0)));
                            listResults.Add(new Complex(0, Math.Sqrt(a2 / a0)));
                        }
                    }
                    else
                    {
                        if (a4 == 0 && a5 == 0)
                        {
                            list = EquationOfTheThirdDegree(a0, a1, a2, a3);
                        }
                        else
                        {
                            list = EquationOfTheFourthDegree(a0, a0 * x1 + a1, (a0 * x1 + a1) * x1 + a2, ((a0 * x1 + a1) * x1 + a2) * x1 + a3, (((a0 * x1 + a1) * x1 + a2) * x1 + a3) * x1 + a4);
                        }
                    }
                }
            }
            foreach (Complex item in list)
            {
                listResults.Add(item);
            }
            return listResults;
        }
    }
}
