using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public static HomeScreen instance;
    public StoreNU storeNU;


    [SerializeField] Canvas mainCanvas;
    [SerializeField] Canvas loadingCanvas;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        mainCanvas.enabled = true;
        loadingCanvas.enabled = false;
    }

    public void ButtonClick(int nu)
    {
        storeNU = new StoreNU();
        storeNU.nu = nu;

        mainCanvas.enabled = false;
        loadingCanvas.enabled =true;

        StartCoroutine(WaitForSomeTime());
    }

    IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainScene");
    }
}


public class StoreNU{

    public int nu;
}

