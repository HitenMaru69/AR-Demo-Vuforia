using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] private bool isPlaced;
    [SerializeField] private GameObject planeFinder;
    [SerializeField] Player player;
    [SerializeField] GameObject gamePlayCanvas;
 
   

    private void Start()
    {
        isPlaced = false;
        gamePlayCanvas.SetActive(false);
    }


    public void PlaceContent(Transform content)
    {
        if (!isPlaced) 
        {
            isPlaced = true;
            player.SetToRigidbodyNormal();
            gamePlayCanvas.SetActive(true);
            planeFinder.SetActive(false);
        }
    }

    
}
