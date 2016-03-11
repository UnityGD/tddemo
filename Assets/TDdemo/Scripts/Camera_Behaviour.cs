using UnityEngine;
using System.Collections;

public class Camera_Behaviour : MonoBehaviour
{
    public GameObject GO_Camera;
    
    Vector2 Move_Area_Down = new Vector3(20f, 250f);
    Vector2 Move_Area_Up = new Vector3(480f, 550f);

    public Vector3 Move_Direction;
    public Vector3 Move_Destination;
    float Move_Speed = 30f;
    float Move_Wheel_Speed = 100f;

    void Update()
    {
        CameraMove();
        CameraWheelMove();
        CameraRotate();
    }

    void CameraMove()
    {
        Move_Direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Move_Destination = transform.position + (Move_Direction * Move_Speed);
        Move_Destination = new Vector3(Mathf.Clamp(Move_Destination.x, Move_Area_Down.x, Move_Area_Up.x),
            transform.position.y, Mathf.Clamp(Move_Destination.z, Move_Area_Down.y, Move_Area_Up.y));
        transform.position = Vector3.Lerp(transform.position, Move_Destination, 0.1f);
    }

    void CameraWheelMove()
    {
        Move_Direction = GO_Camera.transform.TransformDirection(Vector3.forward * Input.GetAxis("Mouse ScrollWheel")).normalized;
        Move_Destination = GO_Camera.transform.position + (Move_Direction * Move_Wheel_Speed);
        GO_Camera.transform.position = Vector3.Lerp(GO_Camera.transform.position, Move_Destination, 0.1f);
    }

    void CameraRotate()
    {
        //Пока не сделано
    }
}
