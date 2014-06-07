using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Vector3 _respawnPoint;
	// Use this for initialization
	void Start ()
	{
	    _respawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (GetComponent<Unit>().HealthPoints <= 0)
	    {
	        Die();
	    }
	}

    private void Die()
    {
        transform.position = _respawnPoint;
        GetComponent<Unit>().HealthPoints = 1;
    }
}
