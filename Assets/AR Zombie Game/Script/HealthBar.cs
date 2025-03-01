
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image heathBar;
    [SerializeField] Image health;
    [SerializeField] float totalHealth;

    private Camera m_Cam;
    private float currentHealth;


    private void Start()
    {
        m_Cam = Camera.main;
        currentHealth = totalHealth;
    }

    private void Update()
    {
        heathBar.gameObject.transform.rotation = Quaternion.LookRotation(heathBar.gameObject.transform.position - m_Cam.transform.position);
    }

    public void ReduceHealth()
    {
        currentHealth -= 1;
        health.fillAmount = currentHealth / totalHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;   
    }
}
