using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public bool isGameOver = false;
    public Rigidbody2D rb2d;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0;
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity += new Vector2(0f, 8f);
        }
    }
}
