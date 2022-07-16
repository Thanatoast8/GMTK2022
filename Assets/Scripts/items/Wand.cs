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
    public override bool Use()
    {
        base.Use();
        Debug.Log("use wand!!");
        //SubMenu.instance.open(this);

        if (!SubMenu.instance.isActiveAndEnabled)
        {
            Debug.Log("Submenu is CLOSED and we will attempt to open the submenu");
            SubMenu.instance.open(this);
            return true;
        }
        else
        {
            Debug.Log("Submenu is OPEN and we will attempt to close the submenu");
            SubMenu.instance.close();
            return true;
        }

    }
}
