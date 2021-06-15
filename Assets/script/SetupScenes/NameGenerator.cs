using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameGenerator : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;

    public Button btnENTER; // 创建库，进入游戏按钮
    public Text Mistake; // 输入错误提示
    public Text Success; // 创建库成功提示
    public Toggle IsMale; // 玩家男性
    public Toggle IsFemale; // 玩家女性
    public InputField FNameInput; //姓氏输入
    public InputField GNameInput; //名字输入

    static int name_count = 30;  // 人名总数
    static int Gender = -1;  // 性别  0-male 1-female ...

    void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _systems = new NameGenerateSystem(_contexts);
    }
    // Start is called before the first frame update
    void Start()
    {
        Success.gameObject.SetActive(false); // 提示标语不显示
        Mistake.gameObject.SetActive(false);
        IsMale.onValueChanged.AddListener((bool value) => GetPlayerGender(value));
        IsFemale.onValueChanged.AddListener((bool value) => GetPlayerGender(value));
        btnENTER.onClick.AddListener(SceneSwitch); // call Scene switching function
    }
    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
    private void GetPlayerGender(bool value)  //  性别赋值
    {
        if (IsMale.isOn == true && IsFemale.isOn == false)
        {
            Gender = 0;
            Debug.Log("玩家性别选择为男性");
        }
        else if (IsMale.isOn == false && IsFemale.isOn == true)
        {
            Gender = 1;
            Debug.Log("玩家性别选择为女性");
        }
        else
        {
            Gender = -1;
        }
    }

    public void SceneSwitch()
    {
        Debug.Log("进入游戏按钮功能正常");
        // TODO: 检查玩家姓名是否符合规范，若不符则重新输入 - return
        if (FNameInput.text == "" || GNameInput.text == "" || Gender == -1)
        {
            Mistake.gameObject.SetActive(true);
            StartCoroutine(Disappear());
            return;
        }
        // TextAsset odb_PNames = Resources.Load("prohibited") as TextAsset;
        // string[] db_PNames = odb_PNames.text.Replace("\r", "").Split('\n');
        // string p_name = PlayerName.getCharacterName();

        Success.gameObject.SetActive(true); // 文本显示：正在创建库...
        StartCoroutine(Disappear()); //调用协程
        // 读入并存入玩家姓名
        _systems.Add(new AddPlayerGenderSystem(_contexts, Gender));
        _systems.Add(new AddPlayerNameSystem(_contexts, FNameInput.text, GNameInput.text));
        _systems.Initialize();  // 创建玩家角色，编号0

        // 从姓名库(分男女)中随机生成人名，得到n+1个数据
        var r_system = new RandomNameInitSystem(_contexts, name_count);
        r_system.Initialize();

        SceneManager.LoadScene("test0.1.0"); // load new scene
    }

    IEnumerator Disappear() //文字协程
    {
        yield return new WaitForSeconds(3); //产生效果n秒
        Mistake.gameObject.SetActive(false); //消失
        Success.gameObject.SetActive(false);
    }

}