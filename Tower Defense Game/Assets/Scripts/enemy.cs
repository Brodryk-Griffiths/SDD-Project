using UnityEngine;
public class enemy : MonoBehaviour
{
  public float speed = 10f;
  public float health = 2f;
  Renderer thisRend;
  private Transform target;
  private int wavepointIndex = 0;
  PlayerStats playerStats;
  private float moneyEarnt = 2.5f;
  void Start ()
  {
    target = Waypoints.points[0];
    playerStats = PlayerStats.instance;
    thisRend = GetComponent<Renderer>();
    WaveSpawner.instance.SetActiveEnemies();
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
      PlayerStats.Money += moneyEarnt;
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
    else if (health <= 6)
    {
      thisRend.material.SetColor("_Color", new Color(255f/255f, 140f/255f, 0f/255f));
    }
    else if (health <= 7)
    {
      thisRend.material.SetColor("_Color", Color.grey);
      moneyEarnt = 1f;
    }
    else if (health <= 8)
    {
      thisRend.material.SetColor("_Color", Color.black);
      moneyEarnt = 1f;
    }
    else if (health <= 9)
    {
      thisRend.material.SetColor("_Color", Color.white);
      moneyEarnt = 1f;
      speed = 19f;
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
    WaveSpawner.instance.RemoveActiveEnemies();
    Destroy(gameObject);
  }
}
