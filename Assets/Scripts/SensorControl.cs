using UnityEngine;

public class SensorControl : MonoBehaviour
{
    public float sensivity = 2, power, force = 15;
    [HideInInspector] public Vector2 startTouchPosition, currentTouchPosition;
    public Vector2 angle;
    public bool isTouch;

    private void Update()
    {
        Vector2 delta;

        if (Input.GetMouseButtonDown(0))
        {
            power = 0;
            isTouch = true;
            startTouchPosition = Input.mousePosition;
            currentTouchPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            currentTouchPosition = Input.mousePosition;
            delta = currentTouchPosition - startTouchPosition;
            angle = delta.normalized;
            power = delta.magnitude / Screen.width * sensivity;
            if(power > 1)
            {
                power = 1;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
    }
}
