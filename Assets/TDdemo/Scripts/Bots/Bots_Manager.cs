using UnityEngine;
using System.Collections;

public class Bots_Manager : MonoBehaviour
{
    //Префабы разных ботов
    public GameObject[] PF_Bots;

    float Spawn_Delay = 5f;
    float Spawn_Last;
    int Spawn_Limit;

    bool Have_PF_Bots = false;

    void Start()
    {
        if (PF_Bots.Length != 0)
        {
            Have_PF_Bots = true;
            Spawn_Last = Time.time;

            //Применяем тип бота к стартовым ботам
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Bot_Behaviour>().SetBot(new botSimple(this, transform.GetChild(i).gameObject));
            }
        }
        else
        {
            Debug.Log("Set bots prefabs!");
        }
    }

    void Update()
    {
        if (Have_PF_Bots == true)
        {
            if (Spawn_Delay < Time.time - Spawn_Last)
            {
                SpawnBot();
                Spawn_Last = Time.time;
            }
        }
    }

    void SpawnBot()
    {
        //Случайно выбираем типа нового бота
        int botType = Random.Range(0, PF_Bots.Length);
        GameObject go = Object.Instantiate(PF_Bots[botType], transform.position, transform.rotation) as GameObject;
        go.transform.parent = transform;

        switch (botType)
        {
            case 0:
                {
                    go.GetComponent<Bot_Behaviour>().SetBot(new botSimple(this, go));
                    break;
                }

            case 1:
                {
                    go.GetComponent<Bot_Behaviour>().SetBot(new botFast(this, go));
                    break;
                }

            case 2:
                {
                    go.GetComponent<Bot_Behaviour>().SetBot(new botBig(this, go));
                    break;
                }
        }
    }
}
