using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public InputMaster controls;
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    private void Awake()
    {
        controls = new InputMaster();
        controls.Combat.inventoryToggle.performed += ctx => toggleInventory();
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();



        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateUI();


    }

    void toggleInventory()
    {
        Debug.Log("togglelin' inventory");
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }



    void UpdateUI()
    {
        //Debug.Log("updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
