using BNG;
using GameplayEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameEventSO startEvent;

    public void OnStart()
    {
        Debug.Log("Hola");
        SceneManager.LoadScene("Nivel", LoadSceneMode.Additive);
        startEvent.Raise();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainMenu"));
    }

    public void OnExit()
    {
        
    }
}
