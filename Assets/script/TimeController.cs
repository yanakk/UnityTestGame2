using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        

    }


    public void StopAll() {

        Time.timeScale = 0;

    }

    public void StartAll()
    {

        Time.timeScale = 1;

    }

    public void DoubleTime()
    {

        Time.timeScale = 2;

    }
}
