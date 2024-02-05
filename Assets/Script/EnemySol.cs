using System.Collections;/*
using System.Collections.Generic;
using Unity.VisualScripting;*/
using UnityEngine;

public class EnemySol : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Destroyed());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-2, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
