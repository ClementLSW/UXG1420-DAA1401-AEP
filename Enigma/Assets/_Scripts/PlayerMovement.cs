using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;
using static _GameManager;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Player player;
    private SpriteRenderer sr;
    private _GameManager gm;

    [SerializeField]
    private float playerSpeed = 2.0f;
    private float jumpVelocity = 18.0f;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        sr = GetComponent<SpriteRenderer>();
        gm = _GameManager.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 velocity = new Vector2(1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update() {
        if (player.isAlive) {
            var horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput < 0) sr.flipX = true;
            else if (horizontalInput > 0) sr.flipX = false;
            if(Input.GetButtonDown("Jump")){
                Debug.Log("Jump");
                Jump(); 
            }
            rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
        }
        
    }

    private void Jump(){
        if (isGrounded()){
            Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            player.PlayJump();
        }
    }

    private bool isGrounded(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up * 2.0f);
        Debug.Log(hit.collider.tag);

        if(hit.collider!=null && hit.collider.tag == "Ground"){
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log(distance);
            if(distance < 1.7f){
                return true;
            }
        }

        return false;
        
    }
}
