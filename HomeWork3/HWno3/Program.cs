using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace HWno3
{
    class Program
    {
        //public class Factor : IEquatable<Factor>
        //{
        //    public int Numerator { get; set; }
        //    public int Denominator { get; set; }

        //    public Factor()
        //    {
        //        Numerator = 1;
        //        Denominator = 1;
        //    }
        //    public Factor(int numerator, int denominator)
        //    {
        //        Numerator = numerator;
        //        Denominator = denominator;
        //    }

        //    #region Унарки
        //    public static Factor operator -(Factor a)
        //    {
        //        a.Numerator *= -1;
        //        return a;
        //    }
        //    public static Factor operator ++(Factor a)
        //    {
        //        a.Numerator += a.Denominator;
        //        return a;
        //    }
        //    public static Factor operator --(Factor a)
        //    {
        //        a.Numerator -= a.Denominator;
        //        return a;
        //    }
        //    #endregion

        //    #region Бинарки

        //    public static Factor operator +(Factor f1, Factor f2)
        //    {
        //        return new Factor(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        //    }

        //    public static Factor operator -(Factor f1, Factor f2)
        //    {
        //        return new Factor(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        //    }

        //    public static Factor operator *(Factor f1, Factor f2)
        //    {
        //        return new Factor(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
        //    }

        //    public static Factor operator /(Factor f1, Factor f2)
        //    {
        //        return new Factor(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
        //    }
        //    #endregion

        //    #region Равенста, отношения

        //    public static bool operator ==(Factor f1, Factor f2)
        //    {
        //        return (double)f1.Numerator / f1.Denominator == (double)f2.Numerator / f2.Denominator;
        //    }

        //    public static bool operator !=(Factor f1, Factor f2)
        //    {
        //        return (double)f1.Numerator / f1.Denominator != (double)f2.Numerator / f2.Denominator;
        //    }

        //    public static bool operator >(Factor f1, Factor f2)
        //    {
        //        return (double)f1.Numerator / f1.Denominator > (double)f2.Numerator / f2.Denominator;
        //    }

        //    public static bool operator <(Factor f1, Factor f2)
        //    {
        //        return (double)f1.Numerator / f1.Denominator < (double)f2.Numerator / f2.Denominator;
        //    }

        //    public static bool operator >=(Factor f1, Factor f2)
        //    {
        //        return (double)f1.Numerator / f1.Denominator >= (double)f2.Numerator / f2.Denominator;
        //    }

        //    public static bool operator <=(Factor f1, Factor f2)
        //    {
        //        return (double)f1.Numerator / f1.Denominator <= (double)f2.Numerator / f2.Denominator;
        //    }

        //    #endregion

        //    public override string ToString()
        //    {
        //        try
        //        {
        //            return Numerator / Denominator > 0 ? "" : "-" + Math.Abs(Numerator) + "/" + Math.Abs(Denominator);
        //        }
        //        catch (OverflowException)
        //        {
        //            return "";
        //        }
        //    }

        //    public bool Equals(Factor other)
        //    {
        //        if (ReferenceEquals(null, other)) return false;
        //        if (ReferenceEquals(this, other)) return true;
        //        return (double)Numerator / Denominator == (double)other.Numerator / other.Denominator;
        //    }

        //    public override bool Equals(object obj)
        //    {
        //        if (ReferenceEquals(null, obj)) return false;
        //        if (ReferenceEquals(this, obj)) return true;
        //        return obj.GetType() == typeof(Factor) && Equals((Factor)obj);
        //    }

        //    public override int GetHashCode()
        //    {
        //        unchecked
        //        {
        //            return (Numerator * 397) ^ Denominator;
        //        }
        //    }
        //}


        static void Main(string[] args)
        {
            //Для меня это слишком сложное задание, я попытался его реализовать своими силами, но всё пошло прахом.
            //Я решил загуглить и наткнулся на реализацию подобного класса; прочитав её, нашёл незнакомые способы реализации и решения.
            //К сожалению, я не понимаю то тут происходит :(
        }
    }
}