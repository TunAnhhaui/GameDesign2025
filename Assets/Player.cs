using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // private để ẩn thuộc tính set bên unity
    // Muộn hiện cái nào thì dùng SerializeField
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed; // Tốc độ di chuyển
    [SerializeField] private float jumpForce; // Chiều cao nhảy

    private float xInput;

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = new Vector2(5, rb.velocity.y); // Di chuyển sang phải là dương. sang trái là âm
        //rb.velocity = new Vector2(0, 10); // Nhảy lên

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        xInput = Input.GetAxisRaw("Horizontal"); // Set giá trị theo keydown: a trừ dần, d tăng dần

        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y); // Di chuyển

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // nhảy
        }

    }
}
