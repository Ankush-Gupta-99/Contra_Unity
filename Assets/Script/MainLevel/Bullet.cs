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
            speed = new Vector2(-1, 1)*9;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            speed = new Vector2(1, 1)*9;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            speed = new Vector2(-1, -1)*9;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            speed = new Vector2(1,-1)*9;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            speed = new Vector2(0,1)*9;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed = new Vector2(0, -1) * 9;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            speed = new Vector2(1, 0) * 9;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = new Vector2(-1, 0) * 9;
        }
        else 
        {
            speed = new Vector2(1, 0) * 9;
        }
        rb.velocity = speed;
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("Zomby"))
        {
            Destroy(gameObject);
        }
    }
}
