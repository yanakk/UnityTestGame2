using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempBR2 : MonoBehaviour
{
    public Button btnMain; // Start Button

    private void Start()
    {
        btnMain.onClick.AddListener(SceneSwitch); // call Scene switching function
    }

    public void SceneSwitch()
    {
        SceneManager.LoadScene("TempMainScene"); // load new scene
    }
}
