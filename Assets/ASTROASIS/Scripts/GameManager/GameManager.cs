using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// Namespaces
using GameplayData;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public GameData gameData { get; private set; }


    void Start()
    {
        CreateGameData();
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Update()
    {
        
    }

    public void CreateGameData()
    {
        gameData = new GameData();
    }

    public void IncreaseScore(ObjectDataListSO data)
    {
        // Carlos 9-2-24: Make a scriptable object that works like a queue of score 
        // which where given by external objects like enemies.

        
        if (data.GetAttributeValue(AttributeType.SCORE_VALUE, out float value))
            gameData.score += value * gameData.bonus;
        

        Debug.Log($"Score: {gameData.score}");
    }

    public void ResetBonus()
    {
        gameData.bonus = 1;
    }
}
