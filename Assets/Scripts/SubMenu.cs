using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour
{

    #region singleton
    public static SubMenu instance;
    private void Awake()
    {
        Debug.Log("singletoning submenu");
        if (instance != null)
        {
            Debug.LogWarning("Bruh wtf there's more than one wand submenu?");
            return;
        }
        instance = this;
        Debug.Log("created singleton");
    }

    #endregion
    public GameObject subMenuUI;
    public Transform itemsParent;

    public InventorySlot[] slots;

    Wand wandRefrence;

    
    


    // Start is called before the first frame update
    void Start()
    {

        //subMenuUI.SetActive(false);
        close();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();



    }

    // Update is called once per frame
    void Update()
    {
        

            

    }

    public void open(Wand wand)
    {
        Debug.Log("attempting to open submenu");
        Debug.Log("showing menu for "+wand.name);

        wandRefrence = wand;
        subMenuUI.SetActive(true);


        slots[0].AddItem(wandRefrence);
        if (slots[1] != null)
        {
            slots[1].AddItem(wandRefrence.die);

        }





    }

    public void close()
    {
        Debug.Log("closing");
        subMenuUI.SetActive(false);
    }


    public void test()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }



}
