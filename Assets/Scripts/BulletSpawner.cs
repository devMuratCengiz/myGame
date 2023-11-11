using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 0f, .5f);
    }

    public void SpawnBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
