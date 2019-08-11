using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    private Transform target;
    public float range = 10f;
    public float fireRate = 1f;
    [Header("Untiy Setup Fields")]
    private float fireCountdown = 0f;  
    public string enemyTag = "Enemy";
    public Transform PartToRotate;
    public float RotateSpeed = 10f;
    public GameObject bulletPreFab;
    public Transform firePoint;
    public AudioClip fireSound;
    public AudioClip buildSound;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = AudioManager.sfxVolume;
        InvokeRepeating("UpdateTarget", 0f, 0.25f); //Calls UpdateTarget twice a second
        soundEffect(buildSound);
        
        
    }
    void soundEffect(AudioClip sound)
    {
        if (AudioManager.sfxEnabled == 1)
        {
            audioSource.PlayOneShot(sound);
        }
        else 
        {
            return;
        }
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
        //Rotates the turrret to face the direction of the enemy it is currently targeting
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * RotateSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
        //calls the Shoot Subroutine each time the countdown reaches 0
        if (fireCountdown <= 0f)
        {
            Shoot();
            //resets the countdown
            fireCountdown = 1f / fireRate;
        }       
        //reduces time until next fire by real time
        fireCountdown -= Time.deltaTime;

    }

    void Shoot ()
    {
        //Creates bullet at the end of turret barrel.
        GameObject bulletGO = (GameObject)Instantiate (bulletPreFab, firePoint.position, firePoint.rotation); 
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        soundEffect(fireSound);

        //when a bullet exists, it is set to chase the current target. This target recieved by Bullet script
        if (bullet != null)
            bullet.Chase(target);
    }
    
    
    //Draw range wireframe
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

//
