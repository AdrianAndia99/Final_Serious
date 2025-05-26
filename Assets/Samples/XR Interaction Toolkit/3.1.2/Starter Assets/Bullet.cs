using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody rb= bullet.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
    }
}
