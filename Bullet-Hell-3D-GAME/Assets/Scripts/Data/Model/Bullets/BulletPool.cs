using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

    enum SpawnerType { Straight}
    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1.0f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    void Update() {
        timer += Time.deltaTime;
        if (timer >= firingRate) {
            Fire();
            timer = 0f;
        }
    }

    private void Fire() {
        if (bullet) {
            spawnedBullet = Instantiate(bullet, transform.position, transform.rotation);
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().rotation = transform.eulerAngles.z;
        }
    }
}