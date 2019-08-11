using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;    
    public float speed = 70f;
    public float damage = 1f;
    public GameObject impactEffect;
    public void Chase (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        //Destroys bullet if target is destroyed
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        //direction and distance to move towards target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        //Detects if impacted with enemy and calls HitEnemy subprogram
        if (dir.magnitude <= distanceThisFrame)
        {
            HitEnemy();
            return;
        }
        //Moves toward target
        transform.Translate (dir.normalized * distanceThisFrame, Space.World);

    }

    void HitEnemy()
    {
        //Spawns particle effect and stores as a game object
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //waits 2 sec before destroying particle effect
        Destroy(effectIns, 2f);
        //Destroys bullet, does 1 damage to enemy and adds $5 to player funds
        Destroy(gameObject);
        target.GetComponent<enemy>().health -= damage;
        
    }
}
