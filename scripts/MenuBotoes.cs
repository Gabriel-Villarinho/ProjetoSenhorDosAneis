using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBotoes : MonoBehaviour
{
    public void JogarClique()
    {
        SceneManager.LoadSceneAsync("Jogo");
    }

    public void SairClique()
    {
        Application.Quit();
    }
}
