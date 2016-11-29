using UnityEngine;
using System.Collections;

public class PirateShipScript : MonoBehaviour {

    public float speed;
    public Vector3 targetpos;
    public Transform [] PatrolPoints;

    //bool playerLoot = false;
    Transform playerShip, pirateShip;

	// Use this for initialization
	void Start ()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pirateShip = this.GetComponent<Transform>();
        targetpos = PatrolPoints[0].position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Patrol();
	}

    void Patrol()
    {
        if(ScoreManager.Score <= 150)
        {
            int path = Mathf.RoundToInt(Random.Range(0f, 3f));
            if (pirateShip.position == targetpos)
            {
                switch(path)
                {
                    case 0: targetpos = PatrolPoints[0].position;
                        break;
                    case 1: targetpos = PatrolPoints[1].position;
                        break;
                    case 2: targetpos = PatrolPoints[2].position;
                        break;
                    case 3: targetpos = PatrolPoints[3].position;
                        break;
                }
            }
        }
        else
        {
            targetpos = playerShip.position;
        }

        pirateShip.LookAt(targetpos);
        pirateShip.position = Vector3.MoveTowards(pirateShip.position, targetpos, speed * Time.deltaTime);
    }
}
