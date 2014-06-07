using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{
    private Rect _screenToWorldLimits;

    public Rect ScreenToWorldLimits
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
                _instance._screenToWorldLimits.yMax = Camera.main.orthographicSize;
                //IF YOU ARE GOING TO CHANGE THE GUI HEIGHT YOU MUST FIND THE RATIO OF THE MAX HEIGHT OF MOVEMENT AND MIN HEIGHT OF MOVEMENT
                _instance._screenToWorldLimits.yMin = -Camera.main.orthographicSize*.6f;// (4.5/7.5=0.6)  
                _instance._screenToWorldLimits.xMax = _instance._screenToWorldLimits.yMax * 16 / 9;
                _instance._screenToWorldLimits.xMin = -_instance._screenToWorldLimits.xMax;
                print(_instance._screenToWorldLimits.xMin + "," + _instance._screenToWorldLimits.xMax + "  " + _instance._screenToWorldLimits.yMin + ", " + _instance._screenToWorldLimits.yMax);
            }

            return _instance;
        }
    }	
	// Use this for initialization

    public void OnApplicationQuit()
    {
        _instance = null;
    }

    public bool IsOutsideScreen(Vector3 go)
    {
        if (ScreenToWorldLimits.Contains(go))
        {
            return false;
        }

        /*if (go.transform.position.x > ScreenToWorldLimits.x)
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
        }*/

        return true;
    }
}
