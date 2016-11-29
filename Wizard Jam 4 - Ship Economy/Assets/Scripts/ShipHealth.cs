using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour
{
    public ShipStats thisShip;
    public ShipStats enemyShip;
    Vector3 shipTrans,enemyTrans;

    public class ShipStats
    {
        
        public float Hitpoints;
        public float Damage;
        public float Regen;
        public GameObject enemyType;
        public int DamageSpeed;
        
        public ShipStats(float hit,float dmg,int dmgspeed)
        {
            hit = 10f;
            dmg = 2f;
            dmgspeed = 3;
            enemyType = GameObject.FindGameObjectWithTag("Player");
        }

        public ShipStats()
        {
            Hitpoints = 10f;
            Damage = 2f;
            DamageSpeed = 3;
            Regen = 10f;
            enemyType = GameObject.FindGameObjectWithTag("Pirate");
        }
    }
	
    // Use this for initialization
	void Start ()
    {
        if (this.gameObject.tag == "Player")
        {
            thisShip = new ShipStats();
            print("welcome to player");
        }
        else
        {
           print("get the fuck out here");
          thisShip = new ShipStats(12, 3, 3);
        }
	}

    // Update is called once per frame
    void Update()
    {
        ShootEnemy();
    }

    void ShootEnemy()
    {
        shipTrans = this.gameObject.transform.position;
        enemyTrans = thisShip.enemyType.transform.position;
        enemyShip = thisShip.enemyType.GetComponent<ShipHealth>().thisShip;

        /************************************************
        *Find a way to access the hit points of the enemyType*
        ************************************************/

        if(Vector3.Distance(shipTrans, enemyTrans) < 1f)
        {
            Debug.Log("Time to fire");
            enemyShip.Hitpoints -= thisShip.Damage;
            print(enemyShip.Hitpoints);
        }
    }
}
