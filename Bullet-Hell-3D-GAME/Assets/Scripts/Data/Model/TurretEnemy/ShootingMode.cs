using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMode : MonoBehaviour
{
    public int timerNextStage;
    private int timer;
    public int currentStage;
    private int timerGlobal = 10;
    public GameObject bulletPrefab; 
    public float respawnTime; 
    public int bulletsPerCircle = 5; 
    public float bulletSpeed = 5f; 
    public int bulletsPerSpiral = 5;
    public float spiralRadius = 1.5f;
    public float oscillationAmplitude = 0.5f;
    public float oscillationFrequency = 2f;

    void Start()
    {
        timer = timerNextStage;
        StartCoroutine(corrutine1());
    }

    private void corrutine1actions()
    {
        // Disparar ráfagas de círculos (10 balas por ráfaga)
        for (int i = 0; i < bulletsPerCircle; i++)
        {
            float angle = -i * (360f / bulletsPerCircle);
            Quaternion rotation = Quaternion.Euler(90, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
        }
    }

    private void corrutine2actions()
    {
        for (int i = 0; i < bulletsPerSpiral; i++)
        {
            float angle = i * (360f / bulletsPerSpiral);
            float x = Mathf.Cos(angle) * spiralRadius;
            float y = Mathf.Sin(angle) * spiralRadius + Mathf.Sin(Time.time * oscillationFrequency) * oscillationAmplitude;

            Vector3 spawnPosition = transform.position + new Vector3(x, y, 0f);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, rotation);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
        }
    }

    private void corrutine3actions()
    {
        int numBullets = 36; 
        float spiralRadius = 1.5f; 
        float rotationSpeed = 10f; 

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * (360f / numBullets);
            float x = Mathf.Cos(angle) * spiralRadius;
            float y = Mathf.Sin(angle) * spiralRadius;

            Vector3 spawnPosition = transform.position + new Vector3(x, y, 0f);
            Quaternion rotation = Quaternion.Euler(0, 0, angle + Time.time * rotationSpeed);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, rotation);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
        }
    }

    IEnumerator corrutine1()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            corrutine1actions();
            timerNextStage--;

            if (timerNextStage <= 0)
            {
                currentStage++;
                timerNextStage = timerGlobal;
                StartCoroutine(corrutine2());
                break;
            }

            yield return new WaitForSeconds(respawnTime);
        }
    }

    IEnumerator corrutine2()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            corrutine2actions();
            timerNextStage--;

            if (timerNextStage <= 0)
            {
                currentStage++;
                timerNextStage = timerGlobal;
                StartCoroutine(corrutine3());
                break;
            }

            yield return new WaitForSeconds(respawnTime);
        }
    }

    IEnumerator corrutine3()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            corrutine3actions();
            timerNextStage--;

            if (timerNextStage <= 0)
            {
                currentStage++;
                timerNextStage = timerGlobal;
                StartCoroutine(corrutine1());
                break;
            }

            yield return new WaitForSeconds(respawnTime);
        }
    }
}
