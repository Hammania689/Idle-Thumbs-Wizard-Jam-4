using UnityEngine;
using System.Collections;

public class CameraFollowScritpt : MonoBehaviour
{

    public bool bounds;
    public Vector3 camZone;
    public Vector3 minPos;
    public Vector3 maxPos;

    float max, min, camPos;

    Transform camTrans;
    Transform playerTrans;

	// Use this for initialization
	void Start ()
    {
        camTrans = gameObject.GetComponent<Transform>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        max = playerTrans.position.z + .8f;
        max = playerTrans.position.z - .8f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 camRelay = playerTrans.position - camZone;
        float playPos = playerTrans.position.magnitude;
        float horCamPos = playerTrans.position.x;
        float verCamPos = playerTrans.position.z;
        camTrans.position = new Vector3(Mathf.Clamp(horCamPos / (Time.smoothDeltaTime * .8f), (horCamPos - 1.25f), horCamPos + 1.25f), camTrans.position.y,
            Mathf.Clamp(verCamPos / (Time.smoothDeltaTime * .8f), (verCamPos - 1.25f) , (verCamPos + 1.25f)));

        if(bounds)
        {
            camTrans.position = new Vector3(Mathf.Clamp(camTrans.position.x, minPos.x, maxPos.x), Mathf.Clamp(camTrans.position.y, minPos.y, maxPos.y)
                ,Mathf.Clamp(camTrans.position.z, minPos.z, maxPos.z));
        }
    }
}
