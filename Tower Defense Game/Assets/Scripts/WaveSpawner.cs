using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
  public Transform enemyPrefab;
  public Transform SpawnPoint;
  public Text WaveCounterText;
  private int waveIndex = 0;
  public void StartWave ()
  {
      StartCoroutine(SpawnWave());
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
