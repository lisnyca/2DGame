using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject inv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void  Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) { 
            if(!inv.active)
                inv.SetActive(true);
            else
                inv.SetActive(false);
        }
    }
}
