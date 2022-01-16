using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemSlot
{
    [SerializeField]
    private Sprite m_icon;
    
    [SerializeField]
    private string m_label;
    
    // used to make a stack counter.....
    //[SerializeField]
    //private GameObject m_stackObj;
    
    //[SerializeField]
    //private TextMeshProUGUI m_stackLabel;

    public void Set(InventoryItem item)
    {
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;

        //you could add stackSize.. just dont know how to do that with UI
        //if (item.stackSize <= 1)
        //{
        //    m_stackObj.SetActive(false);
        //    return;
        //}
    }
}
