using System;
using UnityEngine;
using System.Collections;

public class EnemyShip: MonoBehaviour
{
    public enum shipColor
    {
        blue,green,orange,red,yellow
    }

    public float ShootingCooldown;


    public shipColor ShipColor;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{

        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/Ship_" + ShipColor);
	    if (GetComponent<Unit>().HealthPoints <= 0)
	    {
	        Die();
	    }
	}

    

    private void Die()
    {
        Destroy(gameObject);
    }
}
