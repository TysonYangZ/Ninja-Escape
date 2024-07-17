using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    private Rigidbody2D enemyRb;
    private GameObject player;
    public GameObject projectile;
    public Transform projectilePos;

    public float timer;
    

    public float gravityModifier;
    public float moveSpeed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Physics.gravity *= gravityModifier;

        
    }

    // Update is called once per frame
    void Update()
    {
        //shoot.
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < 15)
        {
            timer += Time.deltaTime;

            if (timer > 1.5f)
            {
                timer = 0;
                ShootRotate();
            }
        }





    }

    void ShootRotate()
    {
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }

}
