using System;
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    private int _shipsOnScreen;
    public int AmountOfEnemies;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _shipsOnScreen = GameObject.FindGameObjectsWithTag("Enemy").Length;
	    if (_shipsOnScreen < AmountOfEnemies)
	    {
	        SpawnEnemy();
	    }
	}

    void SpawnEnemy()
    {
        var newEnemy = (GameObject) Instantiate(Resources.Load("Prefabs/enemy_ship"));
        var screenRect = GameState.Instance.ScreenToWorldLimits;
        newEnemy.transform.position = new Vector3(UnityEngine.Random.Range(0,screenRect.xMax),UnityEngine.Random.Range(screenRect.yMin,screenRect.yMax));
        newEnemy.transform.parent = GameObject.Find("/Middleground").transform;
        newEnemy.gameObject.GetComponent<EnemyShip>().ShipColor = (EnemyShip.shipColor) UnityEngine.Random.Range(0, 5);
    }
}
