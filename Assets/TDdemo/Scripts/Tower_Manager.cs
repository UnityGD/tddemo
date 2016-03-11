using UnityEngine;
using System.Collections;

public class Tower_Manager : MonoBehaviour
{
    public Main_Manager Manager;

    int HP_Max = 300;
    int HP_Crnt;

    void Start()
    {
        HP_Crnt = HP_Max;
        Manager = GameObject.Find("Main_Manager").GetComponent<Main_Manager>();
        Manager.SetHP(HP_Crnt, HP_Max);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bots")
        {
            GetDamage(collider.GetComponent<Bot_Behaviour>().BotType);
        }
    }

    void GetDamage(Bot_Type bType)
    {
        int dmg = bType.Damage;
        HP_Crnt -= dmg;
        Manager.SetHP(HP_Crnt, HP_Max);

        if (HP_Crnt <= 0)
        {
            DestroyTower();
        }
    }

    void DestroyTower()
    {
        Manager.GameOver();
    }
}
