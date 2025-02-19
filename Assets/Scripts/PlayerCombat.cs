using UnityEngine;
using UnityEngine.Timeline;



public class PlayerCombat : MonoBehaviour
{
    //public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer; //or layers and have multiple enemy layers

    public float attackRange = 0.5f;
    public int attackDamage = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            Attack();
        }
    }

    void Attack()
    {
        //play attack animation
        //animator.SetTrigger("Attack");

        //detect enemies in range
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
}
