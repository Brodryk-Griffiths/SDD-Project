using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
  public static WaveSpawner instance;
  public Transform enemyPrefab;
  public Transform SpawnPoint;
  public Text WaveCounterText;
  private int waveIndex = 0;
  public int activeEnemies = 0;
  private bool CanStartWave = true;

  private int enemyNo = 0;
  private int enemycount = 0;
  private float waitTime = 0.5f;

  void Awake()
  {
    instance = this;
  }
  public void SetActiveEnemies()
  {
    activeEnemies += 1;
  }
  public void RemoveActiveEnemies()
  {
    activeEnemies -= 1;
  }
  public void StartWave ()
  {
      
      if (CanStartWave == true)
      {
        if (activeEnemies == 0)
        {
          ScoreStore.instance.addWaveCount(waveIndex);
        }
        CanStartWave = false;
        AudioManager.buttonSound();
        StartCoroutine(SpawnWave());
      }
  }

  IEnumerator SpawnWave ()
  {
    //increments teh wave number by one
    waveIndex++;
    //resets counter to 0 for start of each wave
    enemycount = 0;
    //accesed by the UI to display the current wave on screen
    WaveCounterText.text = "Wave: " + waveIndex.ToString();
    //determines the amount of enemies to spawn per wave
    enemyNo = (int)(waveIndex * 1.5f);
    //increases the amount of enemies spawning after wave 49
    if (waveIndex >= 50)
    {
      enemyNo = (int)(enemyNo * 1.5f);
    }
    //loop repeats, spawning 1 enemy each repetition, until the predetermined number of enemies have spawned.
    for (int i = 0; i < enemyNo; i += 1)
    {
      //adds one to the counter used for increasing the health of every second or third enemy (see below)
      enemycount += 1;
      //calls the spawn enemy function
      SpawnEnemy();
      //waits the designated amount of time before preforming next action, in this case repeating the loop
      yield return new WaitForSeconds(waitTime);
    }
    //once all enemys have spawned, sets thsi true so next wabe can be started if user presses button
    CanStartWave = true;
  }
  //Spawns enemy 
  void SpawnEnemy()
  {
    //instantiates the enemy inside of their spawn box
    Transform enemyball = (Transform)Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    if (waveIndex >= 60) 
    {
      enemyball.GetComponent<enemy>().health += 7f;
      waitTime = 0.1f;
      if (enemycount >= 2)
      {
        enemycount = 0;
      }
    }
    else if (waveIndex >= 50) 
    {
      enemyball.GetComponent<enemy>().health += 6f;
      waitTime = 0.2f;
      if (enemycount >= 2)
      {
        enemycount = 0;
      }
    }
    else if (waveIndex >= 40) 
    {
      enemyball.GetComponent<enemy>().health += 5f;
      waitTime = 0.2f;
      if (enemycount >= 2)
      {
        enemyball.GetComponent<enemy>().health += 1f;
        enemycount = 0;
      }
    }
    else if (waveIndex >= 30) 
    {
      enemyball.GetComponent<enemy>().health += 3f;
      waitTime = 0.2f;
      if (enemycount >= 2)
      {
        enemyball.GetComponent<enemy>().health += 1f;
        enemycount = 0;
      }
    }
    else if (waveIndex >= 20) 
    {
      enemyball.GetComponent<enemy>().health += 2f;
      waitTime = 0.2f;
      if (enemycount >= 2)
      {
        enemyball.GetComponent<enemy>().health += 1f;
        enemycount = 0;
      }
    }
    else if (waveIndex >= 15)
    {
      //adjusts the health of the enemy spawned
      enemyball.GetComponent<enemy>().health += 1f;
      //sets time to wait before next enemy is spawned
      waitTime = 0.3f;
      //using the counter created above, increases the health of every third enemy even further
      if (enemycount >= 3)
      {
        enemyball.GetComponent<enemy>().health += 1f;
        //resets counter to 0
        enemycount = 0;
      }
    }
    else if (waveIndex >=5)
    {
      waitTime = 0.4f;
    }
    
  }
}
