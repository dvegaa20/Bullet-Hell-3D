using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    private float movementSpeed;
    private bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 500f * Time.timeScale;
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 600f)
        {
            moveRight = false;
        }
        else if(transform.position.x < -600f)
        {
            moveRight = true;
        }

        if(moveRight){
            transform.position = new Vector2(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
        }
        else{
            transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
