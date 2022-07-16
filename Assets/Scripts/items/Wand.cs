using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName="New Wand",menuName = "Inventory/Wand")]
public class Wand : Item
{
    public int damage;
    public Die die = null;

    private SubMenu sub;

    private void Awake()
    {
        sub = new SubMenu();
    }
    public override void Use()
    {
        base.Use();
        Debug.Log("use wand!!");

        if (!SubMenu.instance.isActiveAndEnabled)
        {
            SubMenu.instance.open(this);
        }
        else
        {
            SubMenu.instance.close();
        }

    }
}
