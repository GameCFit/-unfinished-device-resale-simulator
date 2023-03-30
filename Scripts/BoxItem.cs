using UnityEngine;

[CreateAssetMenu(fileName="BoxItem")]
public class BoxItem : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    public int Id => _id;
    public int Price => _price;
    public string NameProduct => _name;
}
