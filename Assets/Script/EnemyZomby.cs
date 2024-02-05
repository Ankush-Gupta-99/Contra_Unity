using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EnemyZomby : MonoBehaviour
{
    Vector2 move = new Vector2(2,0);
    // Start is called before the first frame update
    Rigidbody2D rb;
    SpriteRenderer sr;
    int hp = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Movements());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (move);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Movements()
    {
        yield return new WaitForSeconds(5);
        move = -move;
        sr.flipX = !sr.flipX;
        StartCoroutine(Movements());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
