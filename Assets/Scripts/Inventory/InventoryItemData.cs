using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basically a struct that holds item data
//Nathan took this from https://www.youtube.com/watch?v=SGz3sbZkfkg&t=586s&ab_channel=GameDevGuide

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
}
