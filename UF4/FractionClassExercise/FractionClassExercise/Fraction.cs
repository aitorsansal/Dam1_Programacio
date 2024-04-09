using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Xml.Schema;

namespace Fraction;

public class Fraction
{
#region Attributes
    private int a_num;
    private int a_den;
    private char a_sign;
#endregion

#region Properties

    public int Numerator
    {
        get => a_num;
        set
        {
            if (value < 0) throw new Exception("Numerator cannot be negative");
            a_num = value;
        }
    }
    public int Denominator
    {
        get => a_den;
        set
        {
            if (value <= 0) throw new Exception("Denominator cannot be negative or 0");
            a_den = value;
        }
    }
    public char Sign
    {
        get => a_sign;
        set
        {
            if (value != '+' && value != '-') throw new Exception("Sign can only be \"+\" or \"-\"");
            a_sign = value;
        }
    }
    public double RealValue => Numerator/Convert.ToDouble(Denominator) * (Sign == '-' ? -1 : 1);

    #endregion

#region Constructors
    public Fraction(int num, int den, char sign)
    {
        if (num < 0) throw new Exception("Numerator cannot be negative");
        if (den <= 0) throw new Exception("Denominator cannot be negative or 0");
        if (sign != '+' && sign != '-') throw new Exception("Sign can only be \"+\" or \"-\"");
        Numerator = num;
        Denominator = den;
        Sign = sign;
    }

    public Fraction():this(0,1,'-') { }

    public Fraction(Fraction f) : this(f.Numerator, f.Denominator, f.Sign) { }

#endregion

#region PrivateMethods

    private int MCD(int a, int b)
    {
        int max = Math.Max(a, b);
        int min = Math.Min(a, b);
        int result;
        do
        {
            result = min;
            min = max % min;
            max = result;
        }
        while(min!=0);

        return result;
    }

#endregion

#region Instance Methods

    public void Simplify()
    {
        int mcd = MCD(Numerator, Denominator);
        Numerator /= mcd;
        Denominator /= mcd;
    }

    public void Add(Fraction f)
    {
        int numSPrimer, numSSegon, denS;
        char signS;
        denS = Denominator * f.Denominator;
        numSPrimer = Numerator * f.Denominator;
        numSSegon = Denominator * f.Numerator;

        if (Sign == f.Sign)
        {
            numSPrimer += numSSegon;
            signS = Sign;
        }
        else
        {
            if (Sign == '-') numSPrimer = -numSPrimer;
            else numSSegon = -numSSegon;
            signS = numSPrimer + numSSegon >= 0 ? '+' : '-';

            numSPrimer = Math.Abs(Math.Abs(numSPrimer) - Math.Abs(numSSegon));
        }

        Numerator = numSPrimer;
        Denominator = denS;
        Sign = signS;
        Simplify();
    }

    public void Multiply(Fraction f)
    {
        int numM = Numerator * f.Numerator;
        int denM = Denominator * f.Denominator;
        char signM = Sign == f.Sign ? '+' : '-';

        Numerator = numM;
        Denominator = denM;
        Sign = signM;
        Simplify();
    }

    public void Divide(Fraction f)
    {
        Fraction inverted = new Fraction(
            f.Denominator, 
            f.Numerator, 
            f.Sign);
        Multiply(inverted);
    }
#endregion

#region Static Methods
    public static bool Equivalents(Fraction f1, Fraction f2)
    {
        Fraction copyF1 = new Fraction(f1);
        Fraction copyF2 = new Fraction(f2);
        copyF1.Simplify();
        copyF2.Simplify();
        bool areEquivalents = copyF1.Numerator == copyF2.Numerator 
                              && copyF1.Denominator == copyF2.Denominator 
                              && copyF1.Sign == copyF2.Sign;

        return areEquivalents;
    }
    public static Fraction Add(Fraction f1, Fraction f2)
    {
        Fraction fraction1Copy = new Fraction(f1);
        fraction1Copy.Add(f2);
        return fraction1Copy;
    }

    public static Fraction Multiply(Fraction f1, Fraction f2)
    {
        Fraction fraction1Copy = new Fraction(f1);
        fraction1Copy.Multiply(f2);
        return fraction1Copy;
    }

    public static Fraction Divide(Fraction f1, Fraction f2)
    {
        Fraction fraction1Copy = new Fraction(f1);
        fraction1Copy.Divide(f2);
        return fraction1Copy;
    }

#endregion

#region Conversions

    public static implicit operator Fraction(int n)
    {
        return new Fraction(Math.Abs(n), 1, n < 0 ? '-' : '+');
    }

    public static explicit operator double(Fraction f)
    {
        return f.RealValue;
    }
#endregion

#region Operators

    public static bool operator ==(Fraction f1, Fraction f2)
    {
        return Equivalents(f1, f2);
    }
    public static bool operator !=(Fraction f1, Fraction f2)
    {
        return !Equivalents(f1, f2);
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        return Add(f1, f2);
    }
    public static Fraction operator -(Fraction f)
    {
        return new Fraction(f.Numerator, 
                            f.Denominator, 
                                f.Sign == '-' ? '+' : '-');
    }
    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        return Add(f1, -f2);
    }
    
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return Multiply(f1, f2);
    }

    public static Fraction operator !(Fraction f)
    {
        return new Fraction(f.Denominator, 
                            f.Numerator, 
                                f.Sign);
    }

    public static Fraction operator ++(Fraction f)
    {
        return f + new Fraction(1,1,'+');
    }

    public static Fraction operator --(Fraction f)
    {
        return f - new Fraction(1, 1, '+');
    }
    
    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        return Divide(f1, f2);
    }

#endregion
#region Overrides

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Sign);
        if (Numerator % Denominator == 0)
        {
            int result = Numerator / Denominator;
            if (result == 0)
            {
                sb.Remove(0, 1);
            }
            sb.Append(result);
        }
        else
        {
            sb.Append($"{Numerator}/{Denominator}");
        }
        return sb.ToString();
    }

    public override bool Equals(object obj)
    {
        bool areEqual = true;
        if (this is null) areEqual = obj is null;
        else if (obj is Fraction f) areEqual = Equivalents(this, f);
        else areEqual = false;
        return areEqual;
    }

    #endregion
}