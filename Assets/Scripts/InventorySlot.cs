//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
   // public Sprite debugImage;
    public Image image;
    public Item item;
    public void AddItem(Item newItem)
    {
        
        
        if (newItem == null)
        {
            Debug.LogError("null item detected");
            image.enabled = false;
        }
        else if (newItem != null)
        {
            item = newItem;
            image.sprite = item.image;
            image.enabled = true;
        }
        
        //image.sprite = debugImage;
        //

        
    }
   

    public void ClearSlot()
    {
        item = null;

        image.sprite = null;
        image.enabled = false;
    }
   
    public bool isGamer______________________________________________________()
    {
        return true;
    }

    public void UseItem()
    {

        Debug.Log("aaa");
        bool successful = false;
        if (item != null)
        {
            successful = item.Use();
            Debug.Log("bbb");
        }

        if (item is Die && successful)
        {
            ClearSlot();
            Debug.Log("ccc");
        }

       
        //return successful;
    }
}
