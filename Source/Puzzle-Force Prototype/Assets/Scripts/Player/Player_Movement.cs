using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    private float _movementSpeed;
    private Vector3 _maxMovement;
	// Use this for initialization
	void Start ()
	{
	    _movementSpeed = 10;
	    _maxMovement = GameState.Instance.ScreenToWorldLimits;
	}

    void FixedUpdate()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
	{
        //Apply Movement to Player
	    var proposedNewLocation = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal")*_movementSpeed*Time.deltaTime, transform.position.y, transform.position.z);
        if (proposedNewLocation.x < _maxMovement.x && proposedNewLocation.x > -_maxMovement.x)
	    {
	        transform.position = proposedNewLocation;
	    }
        proposedNewLocation = new Vector3(transform.position.x, transform.position.y + Input.GetAxisRaw("Vertical") * _movementSpeed * Time.deltaTime, transform.position.z);
        if (proposedNewLocation.y < _maxMovement.y && proposedNewLocation.y > -_maxMovement.y)
        {
            transform.position = proposedNewLocation;
        }
	}

    public static GameObject GetPlayerShip()
    {
        GameObject playerGameObject;
        string PlayerShip = "/middleground/player";
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
