using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // private để ẩn thuộc tính set bên unity
    // Muộn hiện cái nào thì dùng SerializeField
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float moveSpeed; // Tốc độ di chuyển
    [SerializeField] private float jumpForce; // Chiều cao nhảy

    private int facingDir = 1;
    private bool facingRight = true;
    private float xInput;

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = new Vector2(5, rb.velocity.y); // Di chuyển sang phải là dương. sang trái là âm
        //rb.velocity = new Vector2(0, 10); // Nhảy lên

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); // Di chuyển

        CheckInput();

        FlipController();

        AnimatorController();

    }

    private void Movement()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal"); // Set giá trị theo keydown: a trừ dần, d tăng dần


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();// nhảy
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void AnimatorController()
    {
        bool isMoving = rb.velocity.x != 0;

        anim.SetBool("isMoving", isMoving);
    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (rb.velocity.x > 0 && !facingRight)
            Flip();
        else if (rb.velocity.x < 0 && facingRight)
            Flip();
    }

}
