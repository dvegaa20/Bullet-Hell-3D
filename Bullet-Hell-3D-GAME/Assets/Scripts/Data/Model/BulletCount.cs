using TMPro;
using UnityEngine;

public class BulletDisplay : MonoBehaviour
{
    public TextMeshProUGUI bulletTextMesh;
    private int bulletCount;

    public int GetActiveBulletCount()
    {
        int count = 0;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            count++;
        }
        return count;
    }

    void Update()
    {
        if (bulletTextMesh != null)
        {
            bulletCount = GetActiveBulletCount();
            
            if (bulletCount >= 0)
            {
                bulletTextMesh.text = "Bullet Count " + bulletCount.ToString();
            }
            else
            {
                bulletTextMesh.text = "0";
            }
        }
    }
}