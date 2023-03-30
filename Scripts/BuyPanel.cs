using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    public static BuyPanel Instance;

    [SerializeField] private Text _header;
    [SerializeField] private Text _text;
    [SerializeField] private Text _price;

    [SerializeField] private GameObject _destroyEffect;

    private IPlayerInventoble _playerInventory;
    private IPlayerScore _playerScore;

    private string _productName;

    private BoxItem _item;
    private GameObject _itemObject;

    public void FirstActive()
    {
        Instance = this;
        _playerInventory = PlayerInventory.Instance;
        _playerScore = PlayerScore.Instance;
    }

    private void Update()
    {
        if(Instance == null)
        {
            FirstActive();
        }
    }

    public void ActivePanel(BoxItem boxItem, GameObject effectPosition)
    {
        _itemObject = effectPosition;
        _item = boxItem;
        _productName = boxItem.NameProduct;
        _header.text = "Купить " + _productName + "?";
        _text.text = "Вы действительно хотите купить" + _productName + "?";
        _price.text = boxItem.Price + "$";
    }

    public void BuyProduct()
    {
        if (_playerScore.Money() >= _item.Price)
        {
            _playerScore.Buy(_item.Price);
            _playerInventory.AddBox(_item);
            Instantiate(_destroyEffect, _itemObject.transform.position, Quaternion.identity);
            Thread.Sleep(100);
            Destroy(_itemObject);
        }
    }
}
