using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageTargetAnimation : MonoBehaviour
{
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;

    public bool isShowmodel1;
    public bool isShowmodel2;

    private void Start()
    {
        animator1.enabled = false;
        animator2.enabled = false;
    }

    private void Update()
    {
        if(isShowmodel1 && isShowmodel2)
        {
            animator1.enabled = true;
            animator2.enabled = true;
        }
        else
        {
            animator1.enabled = false;
            animator2.enabled = false;
        }
    }

    public void Model1Show()
    {
        isShowmodel1 = true;
    }

    public void Model2Show()
    {
        isShowmodel2 = true;
    }

    public void Model1Hide()
    {
        isShowmodel1 = false;
    }

    public void Model2Hide()
    {
        isShowmodel2 = false;
    }
}
