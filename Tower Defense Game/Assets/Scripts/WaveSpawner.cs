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
    waveIndex++;
    
    enemycount = 0;
    WaveCounterText.text = "Wave: " + waveIndex.ToString();
    enemyNo = (int)(waveIndex * 1.5f);
    if (waveIndex >= 50)
    {
      enemyNo = (int)(enemyNo * 1.5f);
    }
    for (int i = 0; i < enemyNo; i += 1)
    {
      enemycount += 1;
      SpawnEnemy();
      yield return new WaitForSeconds(waitTime);
    }
    CanStartWave = true;
  }

  void SpawnEnemy()
  {
    Transform enemyball = (Transform)Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    if (waveIndex >= 60) 
    {
      enemyball.GetComponent<enemy>().health += 7f;
      waitTime = 0.2f;
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
      enemyball.GetComponent<enemy>().health += 1f;
      waitTime = 0.3f;
      if (enemycount >= 3)
      {
        enemyball.GetComponent<enemy>().health += 1f;
        enemycount = 0;
      }
    }
    else if (waveIndex >=5)
    {
      waitTime = 0.4f;
    }
    
  }
}
