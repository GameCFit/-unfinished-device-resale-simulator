using UnityEngine;

public class PlayerScore : MonoBehaviour, IPlayerScore
{
    public static PlayerScore Instance;

    private int _money;
    public int Money() => _money;
    private void Awake()
    {
        Instance = this;
    }
    public void Buy(int price)
    {
        _money -= price;
        Debug.Log(Money());
    }
}
