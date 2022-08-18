using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score, stars;
    public Text scoreText, starsText;

    private void Start()
    {
        stars = PlayerPrefs.GetInt("stars");
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        starsText.text = stars.ToString();
    }
}
