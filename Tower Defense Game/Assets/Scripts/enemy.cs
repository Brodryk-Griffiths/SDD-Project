using UnityEngine;
public class enemy : MonoBehaviour
{
  public float speed = 10f;
  public float health = 2f;
  Renderer thisRend;
  private Transform target;
  private int wavepointIndex = 0;
  PlayerStats playerStats;
  void Start ()
  {
    target = Waypoints.points[0];
    playerStats = PlayerStats.instance;
    thisRend = GetComponent<Renderer>();
    WaveSpawner.activeEnemies += 1;
  }
  void Update ()
  {
    Vector3 dir = target.position - transform.position;
    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    if (Vector3.Distance(transform.position, target.position) <= 0.5f)
    {
      GetNextWaypoint();
    }
    //Changes colour to provide visual representation of enemies health
    
    if (health <= 0)//Destroys enemy when health zero
    {
      deleteEnemy();
      PlayerStats.Money += 2;
      return;
    }
    
    else if (health <= 1)
    {
      thisRend.material.SetColor("_Color", Color.red);
    }
    else if (health <= 2)
    {
      thisRend.material.SetColor("_Color", Color.cyan);
    }

    else if (health <= 3)
    {
      thisRend.material.SetColor("_Color", Color.yellow);
    }
    else if (health <= 4)
    {
      thisRend.material.SetColor("_Color", Color.green);
    }
    else if (health <= 5)
    {
      thisRend.material.SetColor("_Color", Color.magenta);
    }
    
  }

  void GetNextWaypoint()
  {
    if (wavepointIndex >= Waypoints.points.Length - 1)
    {
      deleteEnemy();
      //Decreases Players health when an enemy crosses final checkpoint
      playerStats.PlayerHealth -= (int)health;
      
      return;
    }
    wavepointIndex++;
    target = Waypoints.points[wavepointIndex];
  }

  void deleteEnemy()
  {
    Destroy(gameObject);
    WaveSpawner.activeEnemies -= 1;
  }
}
