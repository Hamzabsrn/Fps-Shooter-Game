using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNegative : MonoBehaviour
{
    public float speed = 5f; // Hareket hýzý

    private void Update()
    {
        // Yeni pozisyonu hesapla
        Vector3 newPosition = transform.position + Vector3.forward * speed * Time.deltaTime;

        // Pozisyonu güncelle
        transform.position = newPosition;
    }
}
