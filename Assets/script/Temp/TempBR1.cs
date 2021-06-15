using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempBR1 : MonoBehaviour
{
    public Button btnBattle; // Start Button

    private void Start()
    {
        btnBattle.onClick.AddListener(SceneSwitch); // call Scene switching function
    }

    public void SceneSwitch()
    {
        SceneManager.LoadScene("TempBattleScene"); // load new scene
    }
}
