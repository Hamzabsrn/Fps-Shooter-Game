using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Hareket hýzý

    void Start()
    {
        // Y ekseninde 180 derece dönme
        transform.Rotate(Vector3.up, 180f);
    }
    void Update()
    {
        // Z ekseni boyunca hareket etme
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
