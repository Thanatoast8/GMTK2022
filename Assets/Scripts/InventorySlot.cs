//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image image;
    Item item; 
    public void AddItem(Item newItem)
    {
        item = newItem;

        image.sprite = item.image;
        image.enabled = true;
        
    }

    public void ClearSlot()
    {
        item = null;

        image.sprite = null;
        image.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            
        }
    }
}
