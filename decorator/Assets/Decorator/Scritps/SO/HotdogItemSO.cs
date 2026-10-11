using UnityEngine;

[CreateAssetMenu(fileName = "HotdogItem", menuName = "Hotdogs/Item")]
public class HotdogItemSO : ScriptableObject
{
    [field: SerializeField] public string Label { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public int Weight { get; private set; }
}
