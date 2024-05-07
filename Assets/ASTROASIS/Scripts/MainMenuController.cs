using GameplayEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameEventSO startEvent;

    public void OnStart()
    {
        Debug.Log("LOADING level");
        SceneManager.LoadScene("Nivel", LoadSceneMode.Additive);
        startEvent.Raise();
        Debug.Log("UNLOADING main menu");
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainMenu"));
    }

    public void Options()
    {

    }

    public void OnExit()
    {
        Application.Quit();
    }
}
