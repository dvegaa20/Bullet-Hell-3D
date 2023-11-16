using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        Invoke("Destroy", 5f);
    }

    public void OnDisable()
    {
        CancelInvoke();
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
