using System;
using UnityEngine;
using UnityEngine.Timeline;



public class PlayerCombat : MonoBehaviour
{
    //public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer; //or layers and have multiple enemy layers

    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float endlag = 1f;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            animator.SetBool("Attack", true);
            Invoke("delay", endlag);
        }
        else{
            animator.SetBool("Attack", false);
        }
    }

    void Attack()
    {
        //play attack animation
        //animator.SetTrigger("Attack");

        //detect enemies in range
        Debug.Log("Attack recieved");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //damage the enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("We hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {

        if(attackPoint == null){return;}
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void delay(){
        Attack();
    }
}
