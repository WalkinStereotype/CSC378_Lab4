using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    public float bulletCooldown = 2f;

    private EnemyFOV enemyFOV;

    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyFOV = GetComponent<EnemyFOV>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyFOV.canSeePlayer){
            timer += Time.deltaTime;
        }
        
        if (timer > bulletCooldown){
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
