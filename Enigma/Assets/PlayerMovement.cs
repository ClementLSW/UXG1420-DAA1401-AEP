using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float playerSpeed = 2.0f;
    private float jumpVelocity = 15.0f;

    void Awake(){
       rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 velocity = new Vector2(1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump")){
            Jump();
        }
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

    }

    private void Jump(){
        if (isGrounded()){
            Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            //Jump
        }
    }

    private bool isGrounded(){
        return true;
    }
}
