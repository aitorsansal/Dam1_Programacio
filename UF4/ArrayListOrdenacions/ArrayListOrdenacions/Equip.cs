namespace TL;

public class Equip : IComparable<Equip>, IComparable
{

    private string nom;
    private int golsF, golsC, punts;
    
    public Equip(string nom, int punts, int golsF, int golsC)
    {
        this.nom = nom;
        this.golsF = golsF;
        this.golsC = golsC;
        this.punts = punts;
    }

    #region Properties

    public string Nom
    {
        get => nom;
        set => nom = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int GolsF
    {
        get => golsF;
        set => golsF = value;
    }

    public int GolsC
    {
        get => golsC;
        set => golsC = value;
    }

    public int Punts
    {
        get => punts;
        set => punts = value;
    }

    #endregion

    #region Overrides

    public override string ToString()
    {
        return $"{Nom}→ Punts:{Punts} GolsF:{GolsF} GolsC:{GolsC}";
    }

    #endregion

    #region IComparable

    public int CompareTo(Equip other)
    {
        // ReSharper disable once StringCompareToIsCultureSpecific
        return Nom.CompareTo(other.Nom);
    }
    
    public int CompareTo(object? obj)
    {
        if (obj is not Equip) throw new Exception("Object is not an Equip");
        if (obj is null) return 1;
        return CompareTo(obj as Equip);
    }

    public class ComparadorPerGolsMarcats : IComparer<Equip>
    {
        public int Compare(Equip? x, Equip? y)
        {
            if (x is null || y is null) throw new Exception("Un dels equips es null");
            int result = x.GolsF - y.GolsF;
            if (result == 0) result = -x.CompareTo(y);
            return -result;
        }
    }

    public class ComparadorPerGolsEncaixats : IComparer<Equip>
    {
        public int Compare(Equip? x, Equip? y)
        {
            if (x is null || y is null) throw new Exception("Un dels equips es null");
            int result = x.GolsC - y.GolsC;
            if (result == 0) result = -x.CompareTo(y);
            return -result;
        }
    }

    public class ComparadorPerClassificacio : IComparer<Equip>
    {
        public int Compare(Equip? x, Equip? y)
        {
            if (x is null || y is null) throw new Exception("Un dels equips es null");
            int result = x.Punts - y.Punts;
            if (result == 0)
            {
                result = x.GolsF - x.golsC > y.GolsF - y.GolsC ? 1 : x.GolsF - x.GolsC == y.GolsF - y.GolsC ? 0 : -1;
                if (result == 0)
                {
                    result = x.GolsF - y.GolsF;
                    if (result == 0)
                    {
                        Random r = new Random();
                        result = r.Next(50) - r.Next(50);
                    }
                }
            }

            return -result;
        }
    }
    
    #endregion
}
