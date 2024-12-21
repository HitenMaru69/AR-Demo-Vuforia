using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChnageCharacter : MonoBehaviour
{
    [SerializeField] private GameObject character1;
    [SerializeField] private GameObject character2;
    [SerializeField] private GameObject character3;



    private void Start()
    {
        character1.SetActive(true);
        character2.SetActive(false);
        character3.SetActive(false);
    }

    public void Button1()
    {
        character1.SetActive(true); 
        character2.SetActive(false);
        character3.SetActive(false);
    }

    public void Button2()
    {
        character1.SetActive(false);
        character2.SetActive(true);
        character3.SetActive(false);
    }

    public void Button3()
    {
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(true);
    }
}
