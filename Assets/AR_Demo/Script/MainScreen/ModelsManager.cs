using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelsManager : MonoBehaviour
{
    [SerializeField] GameObject[] cars;


    private void Start()
    {
        ShowSpecificCar();
    }



    void ShowSpecificCar()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if(HomeScreen.instance.storeNU.nu == i)
            {
                cars[i].gameObject.SetActive(true);
            }
            else cars[i].gameObject.SetActive(false);
        }
    }
}
