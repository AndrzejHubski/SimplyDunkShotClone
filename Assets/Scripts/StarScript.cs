using UnityEngine;

public class StarScript : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreManager.stars++;
        gameObject.SetActive(false);
    }
}
