using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 10f;
    //public string enemyTag = "Enemy";
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //Calls UpdateTarget twice a second
    }

    //Tracking enemies
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } 
        else
        {
            target = null;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        
    }

    //Draw range wireframe
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

//
