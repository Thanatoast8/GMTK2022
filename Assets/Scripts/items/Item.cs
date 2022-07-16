using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite image;

    //this is for die for when being moved out of the inventory;
    public bool destroyAfterSuccessfulUse = false;



    public virtual bool Use()
    {
        //use item
        Debug.Log("Using " + name);
        return true;
    }
    public virtual bool getShouldBeDeleted()
    {
        return false;
    }

}



