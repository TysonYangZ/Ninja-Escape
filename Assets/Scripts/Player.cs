using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private bool facingRight = true;
    private bool isDead;

    private Rigidbody2D playerRb;
    public GameManager gameManager;

    public float horizontalInput;
    public float speed = 15.0f;
    //Jump
    public float jumpForce = 7;
    public float gravityModifier;
    public bool isOnGround = false;
    public bool canSlash = true;
    public bool canShoot = true;
    //Shoot Gun
    
    public GameObject projectilePrefabRight;
    public GameObject projectilePrefabLeft;
    //melee  
   
    public GameObject projectileMeleeRight;
    public GameObject projectileMeleeLeft;

    
    
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        //jump
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //destory on fall
        if (transform.position.y < -500)
        {
            Destroy(gameObject);
        }

        if (!isDead)
        {
            //Controls
            //Turn left and right
            float horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(Vector3.right * speed * horizontalInput);

            if (horizontalInput < 0 && facingRight)
            {
                Flip();
            }
            else if (horizontalInput > 0 && !facingRight)
            {
                Flip();
            }

            //Get jump
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                isOnGround = false;
            }
            //Get Shoot Gun

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (facingRight)
                {
                    Shoot(projectilePrefabRight);

                }
                if (!facingRight)
                {
                    Shoot(projectilePrefabLeft);
                }

            }
                //melee
                if (Input.GetKeyDown(KeyCode.F) && canSlash)
                {
                    if (facingRight)
                    {
                        Shoot(projectileMeleeRight);

                    }
                    if (!facingRight)
                    {
                        Shoot(projectileMeleeLeft);
                    }
                }
            
        }

    }


    void Shoot(GameObject projectileDirection)
    {
        Instantiate(projectileDirection, transform.position, projectileMeleeLeft.transform.rotation);


    }
  

    void Flip()
    {
       facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") && !isDead)
        {
            isDead = true;
            gameManager.GameOver();

        }

        if (other.gameObject.CompareTag("Exit"))
        {
            gameManager.Victory();
            
        }
    }


        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("box"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            isDead = true;
            
            gameManager.GameOver();
        }
        if (collision.gameObject.CompareTag("danger") && !isDead)
        {
            isDead = true;
            
            gameManager.GameOver();
        }

    }

  
   


}
