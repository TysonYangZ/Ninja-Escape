using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float speed = 25.0f;
    public float gravityModifier;
    public float timer = 0.8f;
   

    // Start is called before the first frame update
    void Start()
    { 
        Physics.gravity *= gravityModifier;
        StartCoroutine(TimeTilDeath());


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        
 


    }

    IEnumerator TimeTilDeath()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Enemy"))
        {

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
