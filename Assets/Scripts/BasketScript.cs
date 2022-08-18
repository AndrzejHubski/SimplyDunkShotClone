using UnityEngine;
using UnityEngine.UI;

public class BasketScript : MonoBehaviour
{
    private float force;
    public GameObject ball, secondBasket, star;
    public Transform ballPosition;
    private Rigidbody2D rb;
    public SensorControl sensorControl;
    public TrajectoryCalculation trajectoryCalculation;
    public ScoreManager scoreManager;
    private BasketScript secondBasketScript;
    public bool inBasket;
    [SerializeField] private bool isGotScore, isPerfect;
    private Vector3 minScreenPositions, maxScreenPositions;

    public Animator animator;
    public Text announcerText;

    private AudioSource audioSource;
    public AudioClip throwingSound;

    public int obstacleChance = 30;
    public GameObject obstacle;

    private void Start()
    {
        minScreenPositions = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); 
        maxScreenPositions = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        force = sensorControl.force;
        rb = ball.GetComponent<Rigidbody2D>();
        secondBasketScript = secondBasket.GetComponent<BasketScript>();
        audioSource = GetComponent<AudioSource>();
        if(inBasket == true)
        {
            secondBasketScript.RelocateBasket(transform.position);
        }
    }

    private void Update()
    {
        Vector2 forceVector = -sensorControl.angle * sensorControl.power * force;

        if (inBasket == true)
        {
            ball.transform.position = ballPosition.position;

            if (Input.GetMouseButton(0) && forceVector.magnitude > 0.05f) 
            {
                float angle = Mathf.Atan2((sensorControl.startTouchPosition.y - Input.mousePosition.y), (sensorControl.startTouchPosition.x - Input.mousePosition.x)) * Mathf.Rad2Deg;
                trajectoryCalculation.gameObject.SetActive(true);
                transform.eulerAngles = new Vector3(0, 0, angle);

                trajectoryCalculation.ShowTrajectory(transform.position, forceVector, ball.GetComponent<Rigidbody2D>().mass);
            }

            if (Input.GetMouseButtonUp(0))
            {
                rb.isKinematic = false;
                rb.velocity = forceVector;
                trajectoryCalculation.gameObject.SetActive(false);
                audioSource.PlayOneShot(throwingSound);
                inBasket = false;
            }

        }
    }

    public void RelocateBasket(Vector2 position)
    {
        float deltaVertical = Random.Range(2, 10);
        float horizontal = Random.Range(minScreenPositions.x + 2, maxScreenPositions.x - 2);
        while (Mathf.Abs(horizontal - position.x) < 2.5f)
        {
            horizontal = Random.Range(minScreenPositions.x + 2, maxScreenPositions.x - 2);
        }
        transform.position = new Vector3(horizontal, position.y + deltaVertical, 0);
        transform.eulerAngles = new Vector3(0,0,90);
        isGotScore = false;
        isPerfect = true;
        if(Random.Range(1,3) == 2)
        {
            star.SetActive(true);
        }

        if(Random.Range(0, 100) < obstacleChance)
        {
            obstacle.SetActive(true);
            obstacle.transform.position = new Vector2(transform.position.x + Random.Range(-3f, 3f), transform.position.y + Random.Range(3f, 5f));
        }
        else
        {
            obstacle.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        obstacle.SetActive(false);

        if(isGotScore == false)
        {
            if (isPerfect == true)
            {
                scoreManager.score += 2;
                announcerText.text = "+2";
            }
            else
            {
                scoreManager.score++;
                announcerText.text = "+1";
            }
            isGotScore = true;
            secondBasketScript.RelocateBasket(transform.position);
            animator.SetTrigger("announcerStart");
        }
        rb.isKinematic = true;
        rb.angularVelocity = 0;
        rb.velocity = Vector2.zero;
        inBasket = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isPerfect = false;
    }
}
