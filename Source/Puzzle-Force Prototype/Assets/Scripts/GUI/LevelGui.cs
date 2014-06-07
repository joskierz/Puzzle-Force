using UnityEngine;
using System.Collections;

public class LevelGui : MonoBehaviour {

    private const float OriginalWidth = 1600.0f;  // define here the original resolution
    private const float OriginalHeight = 900.0f; // you used to create the GUI contents 
    private Vector3 _scale;

    void OnGUI(){
        _scale.x = Screen.width/OriginalWidth; // calculate hor scale
        _scale.y = Screen.height/OriginalHeight; // calculate vert scale
        _scale.z = 1;
        var svMat = GUI.matrix; // save current matrix
        // substitute matrix - only scale is altered from standard
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, _scale);
        //Draw GUI Controls



        //GUI.Box(new Rect(10,10,200,50), "Box");
        //GUI.Button(new Rect(1580,180,230,50), "Button");
        //restore matrix
        GUI.matrix = svMat;
    }
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

        //draw red lines where screen is showing
	        DrawRect(GameState.Instance.ScreenToWorldLimits);
           
	}

    public static void DrawRect(Rect rect)
    {
        var rectToDraw = rect;
        Debug.DrawLine(new Vector3(rectToDraw.xMin, rectToDraw.yMin), new Vector3(rectToDraw.xMin, rectToDraw.yMax), Color.red);//left
        Debug.DrawLine(new Vector3(rectToDraw.xMin, rectToDraw.yMax), new Vector3(rectToDraw.xMax, rectToDraw.yMax), Color.red);//top
        Debug.DrawLine(new Vector3(rectToDraw.xMax, rectToDraw.yMax), new Vector3(rectToDraw.xMax, rectToDraw.yMin), Color.red);//right
        Debug.DrawLine(new Vector3(rectToDraw.xMax, rectToDraw.yMin), new Vector3(rectToDraw.xMin, rectToDraw.yMin), Color.red);//bottom
    }
}
