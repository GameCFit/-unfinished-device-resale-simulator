using System.Collections.Generic;
using UnityEngine;

public class StandSlot : MonoBehaviour
{
    [SerializeField] private List<GameObject> _products;
    [SerializeField] private GameObject _setProductEffect;

    private BoxItem _productItem;

    private Fullnes _fullnes;
    public Fullnes FullnesSlot => _fullnes;

    public enum Fullnes
    {
        full,
        not
    }

    private void Start()
    {
        _fullnes = Fullnes.not;
    }

    public void SetProduct(BoxItem boxItem)
    {
        _productItem = boxItem;
        _products[_productItem.Id].SetActive(true);
        Instantiate(_setProductEffect, _products[_productItem.Id].transform.position, Quaternion.identity);
        _fullnes = Fullnes.full;
    }
    public void BuyProduct()
    {
        _products[_productItem.Id].SetActive(false);
        _productItem = null;
        _fullnes = Fullnes.not;
    }
}
