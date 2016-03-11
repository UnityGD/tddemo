using UnityEngine;
using System.Collections;

public class Bomb_Behaviour : MonoBehaviour
{
    bool IsDetonation = false;
    float Detonation_Time_Up = 1f;
    float Detonation_Time_Crnt;

    void Update()
    {
        if (IsDetonation == true)
        {
            if (Detonation_Time_Up < Time.time - Detonation_Time_Crnt)
            {
                BombDestroy();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsDetonation = true;
        transform.GetChild(0).gameObject.SetActive(true);
        Detonation_Time_Crnt = Time.time;
    }

    void BombDestroy()
    {
        Object.Destroy(gameObject);
    }
}
