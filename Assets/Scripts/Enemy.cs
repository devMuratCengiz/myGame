using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] AudioSource killSound;
    [SerializeField] Animator animator;

    private Player playerSc;
    private GameManager gameManager;
    private GameObject player;
    private Rigidbody2D rb;
    private Renderer renderer;
    private Image xpImage;

    private float a;
    private bool isFacingRight = true;
    private float speed = 2f;
    private int health = 3;
    private bool itsOk = true;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        xpImage = GameObject.Find("Fill").GetComponent<Image>();
        playerSc = GameObject.Find("Player").GetComponent<Player>();
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }
   
    void Update()
    {
        Move();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Knife") && playerSc.itsOk)
        {

            health--;
            speed = 1f;
            animator.SetTrigger("hit");
            if (health==0)
            {
                killSound.Play();
                itsOk = false;
                renderer.sortingOrder = 9;
                rb.simulated = false;
                animator.SetBool("dead", true);
                xpImage.fillAmount += .1f;
                gameManager.EarnCoin();
                Destroy(gameObject, 2f);
                if (xpImage.fillAmount >= 1f)
                {
                    gameManager.LevelUp();
                    xpImage.fillAmount = 0;
                }
            }
        }
        if (collision.CompareTag("Knife2") && playerSc.itsOk)
        {

            health-=2;
            speed = 1f;
            animator.SetTrigger("hit");
            if (health <= 0)
            {
                killSound.Play();
                itsOk = false;
                renderer.sortingOrder = 9;
                rb.simulated = false;
                animator.SetBool("dead", true);
                xpImage.fillAmount += .1f;
                gameManager.EarnCoin();
                Destroy(gameObject, 2f);
                if (xpImage.fillAmount >= 1f)
                {
                    gameManager.LevelUp();
                    xpImage.fillAmount = 0;
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife"))
        {
            speed = 2f;
            
        }
    }
    public void Move()
    {
        if (itsOk)
        {
            a = player.transform.position.x - transform.position.x;
            if ((a <= 0 && isFacingRight) || (a > 0 && !isFacingRight))
            {
                isFacingRight = !isFacingRight;
                Vector2 tempScale = transform.localScale;
                tempScale.x *= -1;
                transform.localScale = tempScale;
            }
            transform.position =
                Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }


}
