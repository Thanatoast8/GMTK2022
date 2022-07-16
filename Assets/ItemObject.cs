using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        Obtain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Obtain()
    {
        Debug.Log("obtaining " + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
