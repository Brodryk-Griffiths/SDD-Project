using UnityEngine;
public class enemy : MonoBehaviour
{
  public float speed = 10f;
  public int health = 2;
  Renderer thisRend;
  private Transform target;
  private int wavepointIndex = 0;
  PlayerStats playerStats;
  void Start ()
  {
    target = Waypoints.points[0];
    playerStats = PlayerStats.instance;
    thisRend = GetComponent<Renderer>();
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
    if (health == 3)
    {
      thisRend.material.SetColor("_Color", Color.yellow);
    }
    else if (health == 2)
    {
      thisRend.material.SetColor("_Color", Color.cyan);
    }
   
    else if (health == 1)
    {
      thisRend.material.SetColor("_Color", Color.red);
    }

    else //Destroys enemy when health zero
    {
      Destroy(gameObject);
      return;
    }
  }

  void GetNextWaypoint()
  {
    if (wavepointIndex >= Waypoints.points.Length - 1)
    {
      Destroy(gameObject);
      if (health == 2)
      {
        playerStats.PlayerHealth -= 2;
        return;
      }
      else 
      {
        playerStats.PlayerHealth -= 1;
        return;
      }
      return;
    }
    wavepointIndex++;
    target = Waypoints.points[wavepointIndex];
  }
}
