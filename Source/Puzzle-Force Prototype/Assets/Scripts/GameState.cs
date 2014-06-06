using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{
    private Vector3 _screenToWorldLimits;

    public Vector3 ScreenToWorldLimits
    {
        get
        {
            return _screenToWorldLimits;
        }
    }

    private static GameState _instance;
    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("_gamestate").AddComponent<GameState>();
                _instance._screenToWorldLimits.y = Camera.main.orthographicSize;
                _instance._screenToWorldLimits.x = _instance._screenToWorldLimits.y * 16 / 9;

            }

            return _instance;
        }
    }	
	// Use this for initialization

    public void OnApplicationQuit()
    {
        _instance = null;
    }

    public bool IsOutsideScreen(GameObject go)
    {
        if (go.transform.position.x > ScreenToWorldLimits.x)
        {
            return true;
        }
        if (go.transform.position.x < -ScreenToWorldLimits.x)
        {
            return true;
        }
        if (go.transform.position.y > ScreenToWorldLimits.y)
        {
            return true;
        }
        if (go.transform.position.y < -ScreenToWorldLimits.y)
        {
            return true;
        }

        return false;
    }
}
