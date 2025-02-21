using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health { get; private set; }
    public float maxHealth = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void TakeDamage(float dmg)
    {
        health = Mathf.Clamp(health - dmg, 0, maxHealth);

        if (health < 1)
        {
            GameManager.instance.ShowGameOverScreen(false);
        }
        else 
        {
            if (health < 1){
                Time.timeScale = 0;
            }
        }
    }
}
