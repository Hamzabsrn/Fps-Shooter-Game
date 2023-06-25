using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objPrefab; // Oluþturulacak obje prefabý
    public float minSpawnTime = 1f; // Minimum doðma süresi
    public float maxSpawnTime = 3f; // Maksimum doðma süresi

    private float spawnTime; // Bir sonraki objenin doðma zamaný
    private float timer; // Zamanlayýcý

    private void Start()
    {
        // Ýlk objenin doðma süresini ayarlayýn
        SetRandomSpawnTime();
    }

    private void Update()
    {
        // Zamanlayýcýyý güncelleyin
        timer += Time.deltaTime;

        // Zaman, bir sonraki objenin doðma zamanýný geçtiyse yeni bir obje oluþturun
        if (timer >= spawnTime)
        {
            SpawnObject();
            SetRandomSpawnTime(); // Bir sonraki objenin doðma süresini ayarlayýn
        }
    }

    private void SpawnObject()
    {
        // Spawner'ýn konumunda bir obje oluþturun
        Instantiate(objPrefab, transform.position, Quaternion.identity);
    }

    private void SetRandomSpawnTime()
    {
        // Minimum ve maksimum doðma süresi arasýnda rastgele bir süre seçin
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        timer = 0f; // Zamanlayýcýyý sýfýrlayýn
    }
}
