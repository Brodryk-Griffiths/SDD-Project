using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
  public Transform enemyPrefab;
  public Transform SpawnPoint;
  public Text WaveCounterText;
  private int waveIndex = 0;
  public static int activeEnemies = 0;

  private int enemyNo = 0;
  private int enemycount = 0;
  private float waitTime = 0.5f;

  
  public void StartWave ()
  {
      if (activeEnemies == 0)
      {
        StartCoroutine(SpawnWave());
      }
  }
  IEnumerator SpawnWave ()
  {
    waveIndex++;
    enemycount = 0;
    WaveCounterText.text = "Wave: " + waveIndex.ToString();
    enemyNo = (int)(waveIndex * 1.5f);
    for (int i = 0; i < enemyNo; i += 1)
    {
      enemycount += 1;
      SpawnEnemy();
      yield return new WaitForSeconds(waitTime);
    }
  }

  void SpawnEnemy()
  {
    Transform enemyball = (Transform)Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    if (waveIndex >= 20) 
    {
      waitTime = 0.2f;
      if (enemycount >= 2)
      {
        enemyball.GetComponent<enemy>().health += 1f;
        enemycount = 0;
      }
    }
    if (waveIndex >= 10) 
    {
      waitTime = 0.3f;
      if (enemycount >= 3)
      {
        enemyball.GetComponent<enemy>().health += 1f;
        enemycount = 0;
      }
    if (waveIndex >=5)
    {
      waitTime = 0.4f;
    }
    }
  }
}
