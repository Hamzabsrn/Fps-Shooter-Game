using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] objPrefabs; // Oluþturulacak obje prefablarýnýn dizisi

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
        // Rastgele bir obje prefabý seçin
        GameObject randomPrefab = objPrefabs[Random.Range(0, objPrefabs.Length)];

        // Spawner'ýn konumunda seçilen objeyi oluþturun
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }

    private void SetRandomSpawnTime()
    {
        // Minimum ve maksimum doðma süresi arasýnda rastgele bir süre seçin
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        timer = 0f; // Zamanlayýcýyý sýfýrlayýn
    }

}


