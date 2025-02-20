using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalHealthBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = health.health / health.maxHealth;
    }
}
