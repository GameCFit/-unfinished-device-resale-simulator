using System.Collections.Generic;
using UnityEngine;

public class ShopStand : MonoBehaviour
{
    [SerializeField] private float _radius;

    [SerializeField] private List<StandSlot> _standSlots;

    private IPlayerInventoble _playerInventory;

    private void Start()
    {
        _playerInventory = PlayerInventory.Instance;
    }

    private void Update()
    {
        if (_playerInventory.BoxesCount() == 1 && Vector3.Distance(transform.position, _playerInventory.PlayerTransform().position) < _radius)
        {
            Debug.Log(87);
            foreach (StandSlot standSlot in _standSlots)
            {
                if (standSlot.FullnesSlot == StandSlot.Fullnes.not)
                {
                    standSlot.SetProduct(_playerInventory.Item());
                    _playerInventory.RemoveBox();
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
