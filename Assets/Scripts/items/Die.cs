using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName="New Die",menuName = "Inventory/Die")]
public class Die : Item
{
    public int faces;
    //new public override bool destroyAfterSuccessfulUse = true;

    bool shouldBeDeleted = false;

    public override bool Use()
    {
        base.Use();
        if (SubMenu.instance.isActiveAndEnabled)
        {
            

            if (SubMenu.instance.slots[1].item== this)
            {
                Inventory.instance.Add(this);
                shouldBeDeleted = true;
                return true;
            }
            
            else if (SubMenu.instance.slots[0].item is Wand) {
                //Debug.Log("attempting to move die");
                SubMenu.instance.slots[1].AddItem(this);
                shouldBeDeleted = true;
                return true;
            }
        }
        return false;


    }

    public override bool getShouldBeDeleted()
    {
        return shouldBeDeleted;
    }
}
