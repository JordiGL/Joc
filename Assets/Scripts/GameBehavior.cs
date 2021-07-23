using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;
using CustomInt = System.Int64;

public class GameBehavior : MonoBehaviour, IManager
{
    public string labeltext = "Collect all 4 items";
    private int _itemsCollected = 0;
    private CustomInt _playerHP = 10;
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    private string _state;
    public Stack<string> lootStack = new Stack<string>();


    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public int Items 
    {
        get { return _itemsCollected; }
        set 
        {
            _itemsCollected = value;
            if(_itemsCollected >= maxItems)
            {
                endedGameInfo("You've found all the items", ref showWinScreen);
            }
            else
            {
                labeltext = "Items found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public CustomInt HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                endedGameInfo("You want another life with that?", ref showLossScreen);
            }
            else
            {
                labeltext = "Ouch... that's got hurt.";
            }
        }
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Manager initialized...";
        _state.FancyDebug();
        Debug.Log(_state);

        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");
    }

    void endedGameInfo(string msg, ref bool showStateInScreen)
    {
        showStateInScreen = true;
        labeltext = msg;
        Time.timeScale = 0f;
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected:" + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labeltext);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }

        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel(0);
            }
        }

    }

    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();
        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items waiting for you!", lootStack.Count);
    }
}
