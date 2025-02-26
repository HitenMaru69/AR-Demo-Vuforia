using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] private bool isPlaced;
    [SerializeField] private GameObject planeFinder;
    [SerializeField] Player player;
   

    private void Start()
    {
        isPlaced = false;
    }

    public void PlaceContent(Transform content)
    {
        if (!isPlaced) 
        {
            isPlaced = true;
            player.SetToRigidbodyNormal();
            planeFinder.SetActive(false);
        }
    }

    
}
