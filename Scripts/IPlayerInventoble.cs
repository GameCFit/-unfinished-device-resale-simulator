using UnityEngine;

interface IPlayerInventoble
{
    void AddBox(BoxItem boxItem);
    void RemoveBox();
    Transform PlayerTransform();
    int BoxesCount();
    BoxItem Item();
}