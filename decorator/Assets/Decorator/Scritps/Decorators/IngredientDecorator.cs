public class IngredientDecorator : Hotdog
{
    private Hotdog _base;
    public IngredientDecorator(Hotdog baseDog, HotdogItemSO info) : base(info) => _base = baseDog;

    public override string GetName() => $"{_base.GetName()} {Data.Label}";
    public override int GetCost() => _base.GetCost() + Data.Cost;
    public override int GetWeight() => _base.GetWeight() + Data.Weight;
}