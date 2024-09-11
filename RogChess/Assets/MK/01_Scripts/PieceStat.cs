using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat")]
public class PieceStat : ScriptableObject
{
    public int Hp { get; private set; }
    public int Damage { get; private set; }
}
