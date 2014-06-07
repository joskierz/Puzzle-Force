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
    private float _lastShot;


    public shipColor ShipColor;
	// Use this for initialization
	void Start ()
	{
	    _lastShot = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Time.time > _lastShot + ShootingCooldown)
	    {
	        //shoot
	        Shoot();
	        _lastShot = Time.time;
	    }
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/Ship_" + ShipColor);
	    if (GetComponent<Unit>().HealthPoints <= 0)
	    {
	        Die();
	    }
	}

    

    private void Die()
    {
        var thisNode = new PuzzleNode((int) ShipColor);
        PuzzleGrid.Instance().AddNodeToGrid(thisNode);
        Destroy(gameObject);
    }

    private void Shoot()
    {
        var laser = (GameObject)Instantiate(Resources.Load("Prefabs/enemy_shot"));
        laser.transform.position =
            transform.position;
        laser.transform.parent = GameObject.Find("/Middleground").transform;
        laser.GetComponent<Projectile>().Friendly = false;
    }
}
