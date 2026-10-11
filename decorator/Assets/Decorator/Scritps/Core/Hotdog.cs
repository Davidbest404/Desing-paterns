public abstract class Hotdog
{
    protected HotdogItemSO Data;
    public Hotdog(HotdogItemSO data) => Data = data;

    public virtual string GetName() => Data.Label;
    public virtual int GetCost() => Data.Cost;
    public virtual int GetWeight() => Data.Weight;
}
