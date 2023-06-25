using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int totalWaves = 3;
    public int enemiesPerWave = 10;
    public float timeBetweenWaves = 5f;

    private int currentWave = 0;
    private int enemiesRemaining = 0;
    private float countdown = 2f;

    public Text waveText;

    void Start()
    {
        enemiesRemaining = enemiesPerWave;
        UpdateWaveText();
    }

    void Update()
    {
        if (countdown <= 0f && enemiesRemaining > 0)
        {
            SpawnEnemy();
            enemiesRemaining--;
            countdown = timeBetweenWaves;
        }

        if (enemiesRemaining == 0)
        {
            if (currentWave + 1 < totalWaves)
            {
                currentWave++;
                enemiesRemaining = (currentWave + 1) * enemiesPerWave;
                UpdateWaveText();
            }
            else
            {
                Debug.Log("Game Over!");
                // Do something else when the game is over.
            }
        }

        countdown -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    void UpdateWaveText()
    {
        waveText.text = "Wave " + (currentWave + 1);
    }
}
