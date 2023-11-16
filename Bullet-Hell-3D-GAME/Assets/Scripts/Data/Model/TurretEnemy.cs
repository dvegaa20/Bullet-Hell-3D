using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    public float alertRange;
    public LayerMask playerLayer;
    bool alert;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.CheckSphere(transform.position, alertRange, playerLayer);
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawSphere(transform.position, alertRange);
    // }
}
