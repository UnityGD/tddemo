using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main_Manager : MonoBehaviour
{
    //Префабы ботоспавнеров и башни
    public GameObject PF_Bots;
    public GameObject PF_Tower;

    public GameObject Main_Menu;
    public GameObject Game_Menu;

    public Button Continue_Btn;
    public Text Score_Txt;
    public Text High_Score_Txt;
    public RectTransform HP_Crnt;
    
    GameObject Bots_Managers;
    GameObject Tower;
    GameObject Player_Manager;

    int Score;
    int High_Score = 0;

    void Start()
    {
        Bots_Managers = GameObject.Find("Bots_Managers");
        Tower = GameObject.Find("Tower");
        Player_Manager = GameObject.Find("Player_Manager");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            ShowMenu();
        }
    }

    public void ShowMenu()
    {
        Main_Menu.SetActive(!Main_Menu.activeInHierarchy);
        Game_Menu.SetActive(!Game_Menu.activeInHierarchy);

        //Пауза в меню
        if (Main_Menu.activeInHierarchy == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameStart()
    {
        Continue_Btn.interactable = true;
        CreateTower();
        CreateBotsManager();
        ShowMenu();
        AddScore(-Score);
    }

    public void GameOver()
    {
        Continue_Btn.interactable = false;
        Object.Destroy(Bots_Managers);
        Object.Destroy(Tower);

        for (int i = 0; i < Player_Manager.transform.childCount; i++)
        {
            Object.Destroy(Player_Manager.transform.GetChild(i).gameObject);
        }

        if (Score > High_Score)
        {
            High_Score = Score;
        }
        
        High_Score_Txt.text = High_Score.ToString();
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    void CreateTower()
    {
        Tower = Object.Instantiate(PF_Tower, new Vector3(295f, 42f, 250f), Quaternion.identity) as GameObject;
        Tower.name = "Tower";
    }

    void CreateBotsManager()
    {
        Bots_Managers = Object.Instantiate(PF_Bots, new Vector3(250f, 0f, 0f), Quaternion.identity) as GameObject;
    }

    public void AddScore(int score)
    {
        Score += score;
        Score_Txt.text = Score.ToString();
    }

    public void SetHP(int crnt, int max)
    {
        float xSize = 1f - ((float)crnt / (float)max);
        HP_Crnt.anchorMin = new Vector2(xSize, HP_Crnt.anchorMin.y);
        HP_Crnt.offsetMin = Vector2.zero;
        HP_Crnt.offsetMax = Vector2.zero;
    }
}
