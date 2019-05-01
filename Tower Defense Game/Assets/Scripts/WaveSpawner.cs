using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
  public Transform enemyPrefab;

  public Transform SpawnPoint;
  //public float timeBetweenWaves = 5f;
  //private float countdown = 2f;

  public Text WaveCounterText;
  private int waveIndex = 0;

  public void StartWave ()
  {
    // if (countdown <= 0f)
    //{
      StartCoroutine(SpawnWave());
      ///countdown = timeBetweenWaves;
    //}

    //countdown -= Time.deltaTime;
  }
  IEnumerator SpawnWave ()
  {
    waveIndex++;
    WaveCounterText.text = "Wave: " + waveIndex.ToString();
    for (int i = 0; i < waveIndex; i++)
    {
      SpawnEnemy();
      yield return new WaitForSeconds(0.5f);
    }
  }

  void SpawnEnemy()
  {
    Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
  }
}
