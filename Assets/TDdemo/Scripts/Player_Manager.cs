using UnityEngine;
using System.Collections;

public class Player_Manager : MonoBehaviour
{
    //Пока только одна бомба
    public GameObject PF_Bomb;
    public Main_Manager Manager;

    Vector3 AirStrike_Coords;
    float Bomb_High = 70f;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (Manager.Main_Menu.activeInHierarchy == false))
        {
            //Ограничиваем количество одновременных бомб до 10
            if (transform.childCount < 10)
                AirStrike();
        }
    }

    void AirStrike()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            AirStrike_Coords = hit.point;
            BombCreate();
        }
    }

    void BombCreate()
    {
        GameObject go = Object.Instantiate(PF_Bomb, AirStrike_Coords + new Vector3(0f, Bomb_High, 0f), Quaternion.identity) as GameObject;
        //Добавляем немного вращения для эффектности
        go.GetComponent<Rigidbody>().AddTorque(new Vector3(100f, 100f, 100f), ForceMode.Impulse);
        go.transform.parent = transform;
    }
}
