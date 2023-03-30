using System.Threading;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private BoxItem _boxItem;

    [SerializeField] private GameObject _panel;

    [SerializeField] private float _radius;

    [SerializeField] private int _price;

    private IPlayerInventoble _playerInventory;
    private BuyPanel _buyPanel;
    private bool _onBuy = false;

    private void Start()
    {
        _playerInventory = PlayerInventory.Instance;
        _buyPanel = BuyPanel.Instance;
    }

    private void Update()
    {
        if (_onBuy == false && _playerInventory.BoxesCount() < 1 && Vector3.Distance(_playerInventory.PlayerTransform().position, transform.position) < _radius)
        {
            _panel.SetActive(true);
            Thread.Sleep(6);
            _playerInventory = PlayerInventory.Instance;
            _buyPanel = BuyPanel.Instance;
            _buyPanel.ActivePanel(_boxItem, gameObject);
        }
    }

    public void Buy()
    {
        _onBuy = true;
        _panel.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
