using UnityEngine;
using UnityEngine.UI;

public class BorderManager : MonoBehaviour
{
    public Transform rightBorderTransform, leftBorderTransform;
    public GameObject gameOverPanel;
    public Text finalScoreText;

    private void Awake()
    {
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
        while (rightBorder - leftBorder < 12)
        {
            Camera.main.orthographicSize++;
            leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
        }
        leftBorderTransform.position = new Vector2(leftBorder, transform.position.y);
        rightBorderTransform.position = new Vector2(rightBorder, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager scoreManager = GameObject.Find("Manager").GetComponent<ScoreManager>();
        gameOverPanel.SetActive(true);
        finalScoreText.text = scoreManager.score.ToString();
        PlayerPrefs.SetInt("stars", scoreManager.stars);
    }
}
