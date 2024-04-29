namespace SuperMarket;

public class Customer : Person
{
    private int? _fidelity_card;

    protected override double GetRating => _totalInvoiced * .02;

    protected override void AddPoints(int pointsToAdd)
    {
        if (_id != "CASH" && _fidelity_card is not null)
            _points += pointsToAdd;
    }

    public Customer(string id, string fullName, int? fidelityCard) : base(id, fullName)
    {
        if (fidelityCard is not null)
            _fidelity_card = fidelityCard;
    }

    public override string ToString()
    {
        return $"DNI/NIE →{_id} NOM →{_fullName}\tRATING →{GetRating}\tVENDES →{_totalInvoiced}\u20AC\tPUNTS →{_points}\t{base.ToString()}";
    }
}