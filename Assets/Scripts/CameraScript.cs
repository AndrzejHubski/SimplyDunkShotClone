using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform ball;
    public float speed;

    private void Start()
    {
        if(PlayerPrefs.GetInt("blackBG") == 1)
        {
            Camera.main.backgroundColor = Color.black;
        }
        else
        {
            Camera.main.backgroundColor = Color.white;
        }
    }

    private void Update()
    {
        if (transform.position.y - 2 < ball.position.y)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (transform.position.y - 4 > ball.position.y)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
