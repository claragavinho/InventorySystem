using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            if (isOpen == false)
            {
                this.gameObject.SetActive(true);
                isOpen = true;
            }
            else 
            {
                this.gameObject.SetActive(false);
                isOpen = false;
            }
        }
    }
}
