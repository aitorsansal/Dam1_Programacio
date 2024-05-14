namespace Super;

public class Customer : Person
{
    private int? _fidelity_card;

    public override double GetRating => _totalInvoiced * .02;

    public override void AddPoints(int pointsToAdd)
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
        return $"DNI/NIE →{_id} NOM →{_fullName} RATING →{GetRating} VENDES →{_totalInvoiced}\u20AC PUNTS →{_points} {base.ToString()}";
    }
}