using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    private Transform target;
    public float range = 10f;
    public float fireRate = 1f;
    
    //[Header("Untiy Setup Fields")]
    private float fireCountdown = 0f;  
    public string enemyTag = "Enemy";
    public Transform PartToRotate;
    public float RotateSpeed = 10f;

    public GameObject bulletPreFab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.25f); //Calls UpdateTarget twice a second
    }

    //Tracking enemies
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

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

        //Rotation
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * RotateSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }       

        fireCountdown -= Time.deltaTime;

    }

    void Shoot ()
    {
        Instantiate (bulletPreFab, firePoint.position, firePoint.rotation);
    }
    
    
    //Draw range wireframe
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

//
