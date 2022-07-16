using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName="New Die",menuName = "Inventory/Die")]
public class Die : Item
{
    public int faces;



    public override void Use()
    {
        base.Use();
        if (SubMenu.instance.isActiveAndEnabled)
        {
            SubMenu.instance.slots[1].AddItem(this);

        }




    }
}
