using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This player controller class will update the events from the vehicle player.
/// Standar coding documentarion can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f * Time.timeScale;
    public float turnSpeed = 200.0f * Time.timeScale;
    public float horizontalInput;
    public float forwardInput;
    public string inputId;

    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputId);
        forwardInput = Input.GetAxis("Vertical" + inputId);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime* turnSpeed * horizontalInput);
    }
}
