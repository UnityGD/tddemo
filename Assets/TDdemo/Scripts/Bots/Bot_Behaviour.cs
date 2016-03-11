using UnityEngine;
using System.Collections;

public class Bot_Behaviour : MonoBehaviour
{
    Transform Bot_Destination;
    bool Have_Destination = false;

    NavMeshAgent Bot_Agent;
    public Bot_Type BotType;

    public void SetBot(Bot_Type botType)
    {
        Bot_Agent = GetComponent<NavMeshAgent>();
        Bot_Destination = GameObject.Find("Tower").transform;
        BotType = botType;

        if (Bot_Destination != null)
        {
            Bot_Agent.destination = Bot_Destination.position;
            Bot_Agent.speed = BotType.Speed;
            Have_Destination = true;
        }
        else
        {
            Debug.Log("Select destination Transform!");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Tower")
        {
            BotDestroy();
        }
        else if (collider.tag == "Bombs")
        {
            //Проверяем наличие стены между бомбой и ботом
            Ray ray = new Ray(transform.position, collider.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50f))
            {
                if (hit.transform.tag != "Walls")
                {
                    BotDestroy();
                }
            }
            else
            {
                BotDestroy();
            }
        }
    }

    public void BotDestroy()
    {
        GameObject.Find("Main_Manager").GetComponent<Main_Manager>().AddScore(BotType.Score_Reward);
        Object.Destroy(gameObject);
    }
}
