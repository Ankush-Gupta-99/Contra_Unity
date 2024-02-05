/*using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;*/
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 speed;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            speed = new Vector2(-7, 7);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            speed = new Vector2(7, 7);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            speed = new Vector2(-7, -7);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            speed = new Vector2(7,-7);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            speed = new Vector2(0,7);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed = new Vector2(0, -7);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = new Vector2(-7, 0);
        }
        else 
        {
            speed = new Vector2(7,0);
        }
        rb.velocity = speed;
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
