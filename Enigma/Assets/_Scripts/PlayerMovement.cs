using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float playerSpeed = 2.0f;
    private float jumpVelocity = 15.0f;

    [SerializeField]
    private AudioManager am;

    [SerializeField]
    private AudioClip jumpClip;

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
            am.PlaySfx(jumpClip);
            //Jump
        }
    }

    private bool isGrounded(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        Debug.Log(hit.collider.tag);

        if(hit.collider!=null && hit.collider.tag == "Ground"){
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log(distance);
            if(distance < 0.6f){
                return true;
            }
        }

        return false;
        
    }

    // Gerald was here!!!
}
