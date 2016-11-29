using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    public Camera mainCam;
    public float sailSpeed;
    public GameObject overlay;

    Transform myTrans;
    Vector3 targetPos;

    // Use this for initialization
    void Start()
    {
        myTrans = GetComponent<Transform>();
        targetPos = myTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(overlay.activeSelf == false)
        {
            if (Input.GetMouseButtonDown(0))
                SetTargetPosition();
            MovePlayerShip();
        }
    }

    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, myTrans.position);
        Ray movement = mainCam.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(movement, out point))
            targetPos = movement.GetPoint(point);
    }

    void MovePlayerShip()
    {
        myTrans.LookAt(targetPos);
        myTrans.position = Vector3.MoveTowards(myTrans.position, targetPos, sailSpeed * Time.deltaTime);
        Debug.DrawLine(myTrans.position, targetPos, Color.red);
    }
}
