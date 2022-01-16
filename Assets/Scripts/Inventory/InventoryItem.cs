using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basically a struct that holds instance version of data
//Nathan took this from https://www.youtube.com/watch?v=SGz3sbZkfkg&t=586s&ab_channel=GameDevGuide

public class InventoryItem
{

    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}
