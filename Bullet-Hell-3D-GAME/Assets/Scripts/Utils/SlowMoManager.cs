using UnityEngine;

public class SlowModeManager : MonoBehaviour
{
    public float slowDownFactor = 0.1f;
    public bool isSlowModeActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleSlowMode();
        }
    }

    void ToggleSlowMode()
    {
        isSlowModeActive = !isSlowModeActive;

        Time.timeScale = isSlowModeActive ? slowDownFactor : 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}