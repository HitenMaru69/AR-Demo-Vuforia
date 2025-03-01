using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void ClickOnArDemoButton()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void ClickOnArGameButton()
    {
        SceneManager.LoadScene("ZombieGamePlay");
    }
}
