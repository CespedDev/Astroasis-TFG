using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// Namespaces
using GameplayData;


public class GameManager : MonoBehaviour
{
    private GameData gameData;

    void Start()
    {
        CreateGameData();
    }

    void Update()
    {
        
    }

    public void CreateGameData()
    {
        gameData = new GameData();
    }

    public void IncreaseScore()
    {
        // Carlos 9-2-24: Make a scriptable object that works like a queue of score 
        // which where given by external objects like enemies.

        /*
        if (data.GetAttributeValue(AttributeType.SCORE_VALUE, out float value))
            gameData.score += value * gameData.bonus;
        */

        Debug.Log($"Score: {gameData.score}");
    }

    public void ResetBonus()
    {
        gameData.bonus = 1;
    }
}
