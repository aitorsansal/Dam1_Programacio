using System.Runtime.InteropServices.JavaScript;

namespace Super;

public class Cashier : Person
{
    private DateTime _joiningDate;

    public int YearsOfService => GetDays()/ 365;


    public override double GetRating => GetDays() * _totalInvoiced * .1;

    public override void AddPoints(int pointsToAdd)
    {
        _points += pointsToAdd * (YearsOfService + 1);
    }

    public Cashier(string id, string fullName, string joinDate) : base(id, fullName, 0)
    {
        _joiningDate = DateTime.ParseExact(joinDate, "dd/MM/yyyy H:mm:ss",
            System.Globalization.CultureInfo.InvariantCulture);
    }


    public override string ToString()
    {
        return
            $"DNI/NIE →{_id} NOM →{_fullName}\tRATING →{GetRating}\tANTIGUITAT →{YearsOfService}\tVENDES →{_totalInvoiced}\u20AC\tPUNTS →{_points}\t{base.ToString()}";
    }

    private int GetDays() { return (DateTime.Now - _joiningDate).Days; }
}