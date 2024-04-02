using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneHandle : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}
