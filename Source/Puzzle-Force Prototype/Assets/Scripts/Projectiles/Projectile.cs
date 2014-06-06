using UnityEngine;
using System.Collections;

public class Projectile: MonoBehaviour
{

    public float ProjectileSpeed;
    public float Damage;
    public bool Friendly;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
	    if (Friendly)
	    {
            transform.position = new Vector3(transform.position.x + ProjectileSpeed * Time.deltaTime, transform.position.y);
	    }
	    else
	    {
            transform.position = new Vector3(transform.position.x - ProjectileSpeed * Time.deltaTime, transform.position.y);
	    }

	    if (GameState.Instance.IsOutsideScreen(gameObject))
	    {
	        Destroy(gameObject);
	    }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Friendly)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Unit>().HealthPoints -= Damage;

                Destroy(gameObject);
            }
        }
        else
        {
            if (other.gameObject.tag == "Friendly")
            {
                other.gameObject.GetComponent<Unit>().HealthPoints -= Damage;

                Destroy(gameObject);
            }
        }

    }
}
