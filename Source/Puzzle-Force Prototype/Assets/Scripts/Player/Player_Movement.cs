using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    private float _movementSpeed;
	// Use this for initialization
	void Start ()
	{
	    _movementSpeed = 10;
	}


	
	// Update is called once per frame
	void Update ()
	{
        //Apply Movement to Player
	    var proposedNewLocation = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal")*_movementSpeed*Time.deltaTime, transform.position.y, transform.position.z);
        if (!GameState.Instance.IsOutsideScreen(proposedNewLocation))
	    {
	        transform.position = proposedNewLocation;
	    }
        proposedNewLocation = new Vector3(transform.position.x, transform.position.y + Input.GetAxisRaw("Vertical") * _movementSpeed * Time.deltaTime, transform.position.z);
        if (!GameState.Instance.IsOutsideScreen(proposedNewLocation))
        {
            transform.position = proposedNewLocation;
        }
	}

    public static GameObject GetPlayerShip()
    {
        GameObject playerGameObject;
        string PlayerShip = "/Middleground/Player";
        playerGameObject = GameObject.Find(PlayerShip);
        if (!playerGameObject)
        {
            Debug.LogError("Cant find GameObject '" + PlayerShip + "'");
            return new GameObject();
        }
        else
        {
            return playerGameObject;
        }
    }
}
