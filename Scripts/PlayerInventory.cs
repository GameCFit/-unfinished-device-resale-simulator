using UnityEngine;

public class PlayerInventory : MonoBehaviour, IPlayerInventoble
{
    public static PlayerInventory Instance;

    private int _boxesCount;

    [SerializeField] private BoxItem _item;

    private PlayerMove _playerMove;

    public Transform PlayerTransform() => transform;

    public int BoxesCount() => _boxesCount;

    public BoxItem Item() => _item;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _playerMove = PlayerMove.Instance;
    }
    public void AddBox(BoxItem boxItem)
    {
        _boxesCount = 1;
        _item = boxItem;
        _playerMove.GetBox(true);
        Debug.Log(boxItem.Id + boxItem.Price);
    }

    public void RemoveBox()
    {
        _boxesCount = 0;
        _item = null;
        _playerMove.GetBox(false);
    }
}
