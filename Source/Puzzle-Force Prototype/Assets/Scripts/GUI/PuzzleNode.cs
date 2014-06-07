using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class PuzzleNode
{
    /*NODE TYPES:
     * 1 - blue
     * 2 - green
     * 3 - orange
     * 4 - red
     * 5 - yellow
     * 6 - bomb
     */
    private int _type;
    private List<int> _matchesWith;
    private int _specialAction;
    private Sprite _sprite;
    private string _name;
    private int _age;

    public PuzzleNode(int type)
    {
        _type = type;
        _specialAction = 0;
        _matchesWith = new List<int>(){0,1,2,3,4,5};
        //SETUP THE TYPE
        switch (type)
        {
            case 0: // blue
                _name = "blue";
                break;
            case 1: // green

                _name = "green";
                break;
            case 2: // orange
                _name = "orange";

                break;
            case 3: // red
                _name = "red";

                break;
            case 4: // yellow
                _name = "yellow";

                break;
            case 5: // bomb
                _name = "bomb";
                _specialAction = 1;
                _matchesWith.Clear();
                break;
            default:
                Debug.LogError("PuzzleNode constructor: PuzzleNode type " + type + " does not exist!");
                break;
        }
        _sprite = Resources.Load<Sprite>("Sprites/PuzzleNode_" + this._name);
        Age = 0;
    }

    public int Type
    {
        get { return _type; }
    }

    public List<int> MatchesWith
    {
        get { return _matchesWith; }
    }

    public bool SpecialAction
    {
        get
        {
            bool result = false;
            switch (_specialAction)
            {
                case 0:
                    result = false;
                    break;
                case 1:
                    //blow up bomb
                    result = true;
                    break;

            }
            return result;
        }
    }

    public Sprite Sprite
    {
        get { return _sprite; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }


    public bool ConnectsWith(int nodeType)
    {
        if (_matchesWith.Contains(nodeType))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    override 
    public string ToString()
    {
        return _name;
    }
}
