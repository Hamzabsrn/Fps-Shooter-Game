using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public GameObject electricEffect; // Parçacýk sistemi örneði

    public Animator animator;
    public GameObject scope;
    public GameObject weaponCamara;
    public Camera mainCamera;
    public float scopedFov = 15f;

    private float nextTimeToFire = 2f;
    private float normalFov;
    private bool isScoped = false;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);
            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnScoped();

        }

    }
    void OnUnScoped()
    {
        scope.SetActive(false);
        weaponCamara.SetActive(true);
        mainCamera.fieldOfView = normalFov;
    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.45f);
        scope.SetActive(true);
        weaponCamara.SetActive(false);
        normalFov = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFov;
    }
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            EnemyController enemyContoroller = hit.transform.GetComponent<EnemyController>();
            if (enemyContoroller != null)
            {
                enemyContoroller.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            // Parçacýk sistemi oluþtur
            GameObject particleEffect = Instantiate(electricEffect, hit.point, Quaternion.identity);

            // Parçacýk sistemi öðesini yok et
            Destroy(particleEffect, 1.5f);
        }

    }

}
