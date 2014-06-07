using System;
using UnityEngine;
using System.Collections;

public class PuzzleGrid : MonoBehaviour
{
    public int GridHorizontalSize;
    private int _gridVerticalSize;
    private PuzzleNode[,] _puzzleGrid;
    private int _currentlySelectedRow;
    private GameObject[,] _anchors;
    private GameObject _rowSelector;
	// Use this for initialization
	void Start ()
	{
	    _rowSelector = GameObject.Find("PuzzleGrid/RowSelector");
	    _currentlySelectedRow = 1;
	    _gridVerticalSize = 4;
        //instantiate puzzle grid
	    _puzzleGrid = new PuzzleNode[4,GridHorizontalSize];



        //Create array of gameobjects in game where puzzle nodes are placed
        _anchors = new GameObject[_gridVerticalSize,GridHorizontalSize];
        for (int row = 0; row < _anchors.GetLength(0); row++)
        {
            for (int col = 0; col < _anchors.GetLength(1); col++)
            {
                //find current lane's left and right anchors
                var currentLaneLeftAnchor = GameObject.Find("LaneAnchors/Row" + row + "/Left");
                var currentLaneRightAnchor = GameObject.Find("LaneAnchors/Row" + row + "/Right");
                //divide the distance of anchors by amount of anchors to determine spacing between them
                float rowAnchorSpacing = Vector3.Distance(currentLaneLeftAnchor.transform.position,currentLaneRightAnchor.transform.position)/GridHorizontalSize;
                //create new vector3 for where the current anchor will be placed
                var putAnchorAt = new Vector3(currentLaneLeftAnchor.transform.position.x + rowAnchorSpacing * col,0);
                //create game object, name it, make it's parent the parent of the rest of the row elements
                var currentAnchor = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/PuzzleNode"));
                currentAnchor.name = row + "_" + col;
                currentAnchor.transform.parent = GameObject.Find("LaneAnchors/Row" + row).transform;
                //change it's position
                currentAnchor.transform.localPosition = putAnchorAt;
                //add game object to array
                _anchors[row, col] = currentAnchor;
            }
        }

	}
	
	// Update is called once per frame
	void Update ()
	{
    //deal with the row selector and arrow
	    _currentlySelectedRow -= (int) Input.GetAxis("Mouse ScrollWheel");
	    if (_currentlySelectedRow > _gridVerticalSize-1)
	    {
	        _currentlySelectedRow = _gridVerticalSize-1;
	    }
        if (_currentlySelectedRow <= 0)
        {
            _currentlySelectedRow = 0;
        }
    //change position row selector game object
	    _rowSelector.transform.position = GameObject.Find("LaneAnchors/Row" + _currentlySelectedRow + "/Right").transform.position;

	//draw grid
        for (int row = 0; row < _puzzleGrid.GetLength(0);row++)
	    {
	        for (int col = 0; col < _puzzleGrid.GetLength(1); col++)
	        {
	            PuzzleNode currentlySelectedNode = _puzzleGrid[row, col];
	            if (currentlySelectedNode != null)
	            {
                    //draw node
	                _anchors[row, col].GetComponent<SpriteRenderer>().sprite = currentlySelectedNode.Sprite;
	            }
	        }
	    }
	    //loop through for matches
        //increase _age for each node;
	}

    public void AddNodeToGrid(PuzzleNode node)
    {
        for (int col = 0; col < _puzzleGrid.GetLength(1); col++)
        {
            if (col > _puzzleGrid.GetLength(1))
            {
                //puzzle grid is full
                Array.Clear(_puzzleGrid,0,GridHorizontalSize*_gridVerticalSize);
            }
            else
            {
                if (_puzzleGrid[_currentlySelectedRow, col] == null)
                {
                    _puzzleGrid[_currentlySelectedRow, col] = node;
                    break;
                }
            }
        }
    }


    public static PuzzleGrid Instance()
    {
        return GameObject.Find("PuzzleGrid").GetComponent<PuzzleGrid>();
    }
}
