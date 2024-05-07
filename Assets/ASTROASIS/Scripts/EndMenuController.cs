using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using GameplayEvents;

public class EndMenuController : MonoBehaviour
{
    public TMP_Text score;

    [SerializeField] private GameEventSO startEvent;
    [SerializeField] private Transform pivot;

    private void OnEnable()
    {
        if(GameManager.Instance != null)
            score.text = $"Score: {GameManager.Instance.gameData.score}";

        transform.position = pivot.position;
    }

    public void OnRestart()
    {
        Debug.Log("UNLOADING level");
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Nivel"));

        Debug.Log("LOADING level");
        SceneManager.LoadScene("Nivel", LoadSceneMode.Additive);
        startEvent.Raise();
        
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
