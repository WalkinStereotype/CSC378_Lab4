using UnityEngine;

public class Enemy : MonoBehaviour
{
public int maxHealth = 100;
int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die(){
        Debug.Log("Enemy died!");

        //animator.SetBool("IsDead", true);
        GetComponent<SpriteRenderer>().enabled = false; //make the enemy dissapear
        GetComponent<Collider2D>().enabled = false; //make it so you can't bump into the enemy
        this.enabled = false;   //disable the enemy (despawn)
    }
}
