using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoysticController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool triggerEnter = true;
    public Joystick _joystick;
    private Vector2 MoveVelocity;

    public SpriteRenderer sprite;

    private int score;
    public static int hp = 3;

    private float tShots;
    private bool isShot = true;
    private float tEvasion = 5;

    private bool canClick = true;
    private Coroutine coroutine;

    public Text scoreText;
    public Text scoreGameOver;
    public Text hpText;

    public static bool dead = false;

    public Vector3[] position;
    public Transform shotsPoint;
    
    

    public GameObject particalEnemy;
    public GameObject particalVase;
    public GameObject bullet;

    public AudioSource shots;
    public AudioSource vase;
    
    
    void Start()
    {
        PlayerPrefs.SetInt("score", score = 0);
        rb = GetComponent<Rigidbody2D>();
        
        score = PlayerPrefs.GetInt("score", score);

        
    }

   
    void Update()
    {
        
        Time.timeScale = 1f;
        scoreText.text = "Score: " + score;
        scoreGameOver.text = "Score: " + score;
        hpText.text = "Hp: " + hp;


        if (_joystick.Horizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        if (_joystick.Horizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        Vector2 moveinput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        MoveVelocity = moveinput.normalized * speed;

        PlayerPrefs.SetInt("score", score);

        if (tShots <= 0)
        {
            isShot = true;
        }
        else
        {
            isShot = false;
            tShots -= Time.deltaTime;
        }

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            if (collision.gameObject.CompareTag("enemy"))
            {
                Instantiate(particalEnemy, position[Random.Range(0, position.Length)], Quaternion.identity);


                score += 10;

                Destroy(collision.gameObject);
            }
        if (triggerEnter)
        {
            if (collision.gameObject.CompareTag("vase"))
            {
                Instantiate(particalVase, position[Random.Range(0, position.Length)], Quaternion.identity);
                hp--;

                Destroy(collision.gameObject);
                vase.Play();
            }
        }
        
    }

    public void Shots()
    {
        if (isShot)
        {
            Instantiate(bullet, shotsPoint.position, transform.rotation);
            tShots = 2f;
            shots.Play();
        }
        
    }

    public void Evasion()
    {
        if (canClick)
        {
            canClick = false;
            coroutine = StartCoroutine(ChangeTransparency());
        }
    }

    private IEnumerator ChangeTransparency()
    {
        Color color = sprite.color;
        color.a = 0.5f;
        sprite.color = color;
        triggerEnter = false;

        yield return new WaitForSeconds(2f);

        color.a = 1f;
        sprite.color = color;
        triggerEnter = true;

        yield return new WaitForSeconds(5f);
        canClick = true;
    }
}
