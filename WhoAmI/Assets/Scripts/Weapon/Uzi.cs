using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    public GameObject impactEffect;
    public GameObject electricEffect;

    private bool isAttack = false;
    private float nextTimeToFire = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else
        {
            isAttack = false;
            animator.SetBool("isAttack", isAttack);
        }
    }

    private void Shoot()
    {
        isAttack = true;
        animator.SetBool("isAttack", isAttack);
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            muzzleFlash.Play();
            EnemyController enemyController = hit.transform.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
            // Parçacýk sistemi oluþtur
            GameObject particleEffect = Instantiate(electricEffect, hit.point, Quaternion.identity);
            // Parçacýk sistemi öðesini yok et
            Destroy(particleEffect, 1.5f);
        }
    }

}
