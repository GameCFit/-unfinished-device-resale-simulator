using UnityEngine;

public class Cash : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _registerMoneyValue;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
