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
        GameObject newEnemy = (GameObject) Instantiate(Resources.Load("Prefabs/enemy_ship"));
        newEnemy.transform.position = new Vector3(UnityEngine.Random.Range(0,GameState.Instance.ScreenToWorldLimits.x),UnityEngine.Random.Range(-GameState.Instance.ScreenToWorldLimits.y,GameState.Instance.ScreenToWorldLimits.y));
        newEnemy.transform.parent = GameObject.Find("middleground").transform;
        newEnemy.gameObject.GetComponent<EnemyShip>().ShipColor = (EnemyShip.shipColor) UnityEngine.Random.Range(1, 5);
    }
}
