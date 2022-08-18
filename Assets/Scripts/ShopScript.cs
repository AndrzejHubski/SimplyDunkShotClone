using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] skins;
    public int[] cost;
    public int id, stars;
    public Text buyButtonText, starsText;

    private void Start()
    {
        stars = PlayerPrefs.GetInt("stars");
        PlayerPrefs.SetInt("skin0", 1);
    }

    private void Update()
    {
        starsText.text = stars.ToString();

        spriteRenderer.sprite = skins[id];

        if (PlayerPrefs.GetInt("skin" + id.ToString()) == 1)
        {
            buyButtonText.text = "Choose";
        }
        else
        {
            buyButtonText.text = "Buy \n" + cost[id];
        }
    }

    public void NextSkin()
    {
        if (id < skins.Length - 1)
        {
            id++;
        }
    }

    public void PreviousSkin()
    {
        if (id > 0)
        {
            id--;
        }
    }

    public void BuyButton()
    {
        if (PlayerPrefs.GetInt("skin" + id.ToString()) == 1)
        {
            PlayerPrefs.SetInt("id", id);
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            if (stars >= cost[id])
            {
                stars -= cost[id];
                PlayerPrefs.SetInt("stars", stars);
                PlayerPrefs.SetInt("skin" + id.ToString(), 1);
            }
        }
    }
}
