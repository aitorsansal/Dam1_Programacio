using System.Runtime.InteropServices.JavaScript;

namespace SuperMarket;

public class Cashier : Person
{
    private DateTime _joiningDate;

    public int YearsOfService => GetDays()/ 365;


    protected override double GetRating => GetDays() * _totalInvoiced * .1;

    protected override void AddPoints(int pointsToAdd)
    {
        _points += pointsToAdd * (YearsOfService + 1);
    }

    public Cashier(string id, string fullName, int points) : base(id, fullName, points)
    {
    }


    public override string ToString()
    {
        return
            $"DNI/NIE →{_id} NOM →{_fullName}\tRATING →{GetRating}\tANTIGUITAT →{YearsOfService}\tVENDES →{_totalInvoiced}\u20AC\tPUNTS →{_points}\t{base.ToString()}";
    }

    private int GetDays() { return (DateTime.Now - _joiningDate).Days; }
}