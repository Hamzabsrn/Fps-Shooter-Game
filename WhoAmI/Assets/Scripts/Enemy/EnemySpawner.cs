using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objPrefab; // Olu�turulacak obje prefab�
    public float minSpawnTime = 1f; // Minimum do�ma s�resi
    public float maxSpawnTime = 3f; // Maksimum do�ma s�resi

    private float spawnTime; // Bir sonraki objenin do�ma zaman�
    private float timer; // Zamanlay�c�

    private void Start()
    {
        // �lk objenin do�ma s�resini ayarlay�n
        SetRandomSpawnTime();
    }

    private void Update()
    {
        // Zamanlay�c�y� g�ncelleyin
        timer += Time.deltaTime;

        // Zaman, bir sonraki objenin do�ma zaman�n� ge�tiyse yeni bir obje olu�turun
        if (timer >= spawnTime)
        {
            SpawnObject();
            SetRandomSpawnTime(); // Bir sonraki objenin do�ma s�resini ayarlay�n
        }
    }

    private void SpawnObject()
    {
        // Spawner'�n konumunda bir obje olu�turun
        Instantiate(objPrefab, transform.position, Quaternion.identity);
    }

    private void SetRandomSpawnTime()
    {
        // Minimum ve maksimum do�ma s�resi aras�nda rastgele bir s�re se�in
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        timer = 0f; // Zamanlay�c�y� s�f�rlay�n
    }
}
