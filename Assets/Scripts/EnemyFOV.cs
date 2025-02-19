using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float radius = 35f;
    [Range(0, 360)]
    public float angle = 180f;

    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public GameObject player;

    public bool canSeePlayer { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        float waitTime = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(waitTime);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if(rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                if(!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                {
                    canSeePlayer = true;
                }
                else 
                {
                    canSeePlayer = false;
                }
            }
            else 
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirectionfromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirectionfromAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

        if(canSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.transform.position);
        }

    }

    private Vector2 DirectionfromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
