using UnityEngine;
using System.Collections;

public class Player_Weapons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1"))
	    {
	        var laser = (GameObject) Instantiate(Resources.Load("Prefabs/friendly_laser"));
	        laser.transform.position =
	            Player_Movement.GetPlayerShip().transform.GetChild(0).transform.position;
	        laser.transform.parent = GameObject.Find("/middleground").transform;
	        laser.GetComponent<Projectile>().Friendly = true;
	    }
	}
}
