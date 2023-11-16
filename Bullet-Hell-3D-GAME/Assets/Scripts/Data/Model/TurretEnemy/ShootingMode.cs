// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ShootingMode : MonoBehaviour
// {
//     [Header("Burst Shot Settings")]
//     [SerializeField]
//     private int bulletsPerShot = 5;
//     [SerializeField]
//     private float startAngle = 90f;
//     [SerializeField]
//     private float endAngle = 270f;

//     [Header("Circle Shot Settings")]
//     [SerializeField]
//     private int bulletsInCircle = 10;
//     [SerializeField]
//     private float circleRadius = 5f;
//     [SerializeField]
//     private float timeBetweenCircles = 5f;

//     [Header("Spiral Shot Settings")]
//     [SerializeField]
//     private int bulletsInSpiral = 10;
//     [SerializeField]
//     private float spiralRadius = 1f;
//     [SerializeField]
//     private float spiralAngleStep = 10f;
//     [SerializeField]
//     private float timeBetweenSpirals = 5f;

//     private Vector3 bulletMoveDirection;

//     void Start()
//     {
//         InvokeRepeating("BurstShot", .5f, 1f);
//     }

//     public void BurstShot()
//     {
//         float angleStep = (endAngle - startAngle) / bulletsPerShot;
//         float angle = startAngle;

//         for (int i = 0; i < bulletsPerShot; i++) 
//         {
//             float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
//             float bulDirZ = transform.position.z + Mathf.Cos((angle * Mathf.PI) / 180f);

//             bulletMoveDirection = new Vector3(bulDirX, 0f, bulDirZ);
//             bulletMoveDirection = transform.TransformDirection(bulletMoveDirection.normalized);

//             GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
//             bul.transform.position = transform.position;
//             bul.transform.rotation = Quaternion.LookRotation(bulletMoveDirection);
//             bul.SetActive(true);
//             bul.GetComponent<Bullet>().SetMoveDirection(bulletMoveDirection);

//             angle += angleStep;
//         }
//     }

    // public void CircleShot()
    // {
    //     float angleStep = 360f / bulletsInCircle;

    //     for (int i = 0; i < bulletsInCircle; i++)
    //     {
    //         float angle = i * angleStep;
    //         float bulDirX = transform.position.x + circleRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
    //         float bulDirZ = transform.position.z + circleRadius * Mathf.Sin(angle * Mathf.Deg2Rad);

    //         Vector3 bulletMoveDirection = new Vector3(bulDirX, transform.position.y, bulDirZ);

    //         GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
    //         bul.transform.position = transform.position;
    //         bul.transform.rotation = Quaternion.LookRotation(bulletMoveDirection - transform.position);
    //         bul.SetActive(true);
    //         bul.GetComponent<Bullet>().SetMoveDirection(bulletMoveDirection);
    //     }
    // }

//     public void SpiralShot()
//     {
//         float angle = 0f;

//         for (int i = 0; i < bulletsInSpiral; i++)
//         {
//             float bulDirX = transform.position.x + spiralRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
//             float bulDirZ = transform.position.z + spiralRadius * Mathf.Sin(angle * Mathf.Deg2Rad);

//             Vector3 bulletMoveDirection = new Vector3(bulDirX, transform.position.y, bulDirZ);

//             GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
//             bul.transform.position = transform.position;
//             bul.transform.rotation = Quaternion.LookRotation(bulletMoveDirection - transform.position);
//             bul.SetActive(true);
//             bul.GetComponent<Bullet>().SetMoveDirection(bulletMoveDirection);

//             angle += spiralAngleStep;
//         }
//     }
// }