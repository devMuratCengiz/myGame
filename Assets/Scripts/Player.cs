using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource gameOverSound;

    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float xRange = 16;
    [SerializeField] private float yRange = 8;
    [SerializeField] private GameObject gun;

    public Animator animator;

    public bool itsOk = true;
    private bool isFacingRight = true;

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if (itsOk)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement.Normalize();
            transform.Translate(Vector3.right * movement.x * moveSpeed * Time.fixedDeltaTime);
            transform.Translate(Vector3.up * movement.y * moveSpeed * Time.fixedDeltaTime);

            animator.SetFloat("speed", movement.sqrMagnitude);

            transform.position =
                new Vector3(Mathf.Clamp(transform.position.x, -xRange, xRange),
                Mathf.Clamp(transform.position.y, -yRange, yRange), transform.position.z);

            if ((movement.x > 0 && !isFacingRight) || (movement.x < 0 && isFacingRight))
            {
                isFacingRight = !isFacingRight;
                Vector3 tempScale = transform.localScale;
                tempScale.x *= -1;
                transform.localScale = tempScale;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy" && itsOk)
        {
            animator.SetTrigger("hit");
            gameManager.TakeDamage();
        }
    }
    public void Death()
    {
        itsOk = false;
        animator.SetBool("death", true);
        gameOverSound.Play();
        gun.gameObject.SetActive(false);
    }

}
