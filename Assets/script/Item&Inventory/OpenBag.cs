using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBag : MonoBehaviour
{
    public GameObject myBag;
    bool isOpen;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        OpenMyBag();
    }

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.O)) // O键摁下
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
