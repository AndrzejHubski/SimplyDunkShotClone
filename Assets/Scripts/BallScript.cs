using UnityEngine;

public class BallScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hitSound;

    public Sprite[] sprites;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer.sprite = sprites[PlayerPrefs.GetInt("id")];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(hitSound);
    }
}
