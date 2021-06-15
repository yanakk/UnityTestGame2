using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Return : MonoBehaviour
{
    // Start is called before the first frame update

    public Button btnSTART; // Start Button
    public Button btnEXIT; // Exit Button
    public Button btnNEW; // New game Button
    // Settings, About, etc.
    //public Button btnRETURN; // Return Button

    private void Start()
    {
        btnSTART.onClick.AddListener(SceneSwitch); // call Scene switching function
        btnEXIT.onClick.AddListener(ExitGame); // call exit function
        btnNEW.onClick.AddListener(ToGameStart); // call exit function
        //btnRETURN.onClick.AddListener(ReturnStart); // call exit function
    }

    public void SceneSwitch()
    {
        SceneManager.LoadScene("test0.1.0"); // load new scene
        Debug.Log("按钮功能正常，预计进入游戏界面");
    }
    public void ToGameStart()
    {
        SceneManager.LoadScene("SetupScenes"); // load new scene
        Debug.Log("开始新游戏，设定人物");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("退出游戏按钮");
    }
    /*public void ReturnStart()
    {
        SceneManager.LoadScene("1"); // load new scene
        Debug.Log("按钮功能正常，预计返回开始界面");
    }*/

}
