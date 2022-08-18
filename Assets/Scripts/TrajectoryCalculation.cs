using UnityEngine;

public class TrajectoryCalculation : MonoBehaviour
{
    private LineRenderer lineRendererComponent;

    private void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector2 origin, Vector2 speed, float mass)
    {
        Vector3[] points = new Vector3[10];

        lineRendererComponent.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = (origin + speed * time + Physics2D.gravity * time * time / 2f)/(mass * mass);
        }

        lineRendererComponent.SetPositions(points);
    }
}
