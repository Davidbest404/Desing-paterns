using UnityEngine;

public class HotdogShopDebug : MonoBehaviour
{
    [SerializeField] private HotdogItemSO _classic, _caesar, _meat, _pickles, _onion;

    void Start()
    {
        if (_classic) PrintInfo(new ClassicHotdog(_classic));
        if (_caesar) PrintInfo(new CaesarHotdog(_caesar));
        if (_meat) PrintInfo(new MeatHotdog(_meat));
    }

    void PrintInfo(Hotdog dog)
    {
        var withPickles = new IngredientDecorator(dog, _pickles);
        var withOnion = new IngredientDecorator(dog, _onion);

        Debug.Log($"--- {dog.GetName()} ---\n" +
            $"Базовая цена: {dog.GetName()} ({dog.GetWeight()}г) — {dog.GetCost()}р.\n" +
            $"Доп: {withPickles.GetName()} ({withPickles.GetWeight()}г) — {withPickles.GetCost()}р.\n" +
            $"Доп: {withOnion.GetName()} ({withOnion.GetWeight()}г) — {withOnion.GetCost()}р.");
    }
}
