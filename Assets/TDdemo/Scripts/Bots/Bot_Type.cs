using UnityEngine;
using System.Collections;

//Одна структура ботов для более легкого введения новых типов
public abstract class Bot_Type
{
    public Bots_Manager BotsManager;
    public GameObject GoBot;
    public int Damage;
    public float Speed;
    public int Score_Reward;
}

public class botSimple : Bot_Type
{
    public botSimple(Bots_Manager botsManager, GameObject goBot)
    {
        BotsManager = botsManager;
        GoBot = goBot;
        Damage = Random.Range(15, 30);
        Speed = 40f;
        Score_Reward = 10;
    }
}

public class botFast : Bot_Type
{
    public botFast(Bots_Manager botsManager, GameObject goBot)
    {
        BotsManager = botsManager;
        GoBot = goBot;
        Damage = Random.Range(10, 20);
        Speed = 60f;
        Score_Reward = 15;
    }
}

public class botBig : Bot_Type
{
    public botBig(Bots_Manager botsManager, GameObject goBot)
    {
        BotsManager = botsManager;
        GoBot = goBot;
        Damage = Random.Range(40, 60);
        Speed = 40f;
        Score_Reward = 20;
    }
}