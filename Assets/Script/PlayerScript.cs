using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Transform start ;
    public Rigidbody2D rb;
    public CapsuleCollider2D capsuleCollider;
    private bool isGround=false;
    public GameObject Bullet;
    public SpriteRenderer SR;
    public static PlayerScript instance;
    public GameObject Enemysol;
    public GameObject GameOver;
    public GameObject OpenGate;
    public GameObject CloseGate;
    public GameObject WinOver;
    public TMP_Text HP;
    int hp = 5;
    private bool key=false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        start = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnEnemy());
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider= GetComponent<CapsuleCollider2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        HP.SetText("Life: " + hp);
        if ((int)transform.position.x < -16)
        {
            transform.position = new Vector3(start.position.x, start.position.y, 0);
            return;
        }


        if ((hp <= 0))
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            transform.Translate(4 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        {
            transform.Translate(4 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKey(KeyCode.X) && isGround)
        {
            rb.AddForce(new Vector2(0, 12), ForceMode2D.Impulse);
            isGround = false;
            capsuleCollider.isTrigger = true;
            StartCoroutine("turnofTriger");
            isGround = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKey(KeyCode.X))
        {
            capsuleCollider.isTrigger = true;
            StartCoroutine("turnofTriger");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }


    IEnumerator turnofTriger()
    {
        yield return new WaitForSeconds(0.4f);
        capsuleCollider.isTrigger = false;
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        if (transform.position.x < 148)
        {
            Instantiate(Enemysol, new Vector3(gameObject.transform.position.x + 20, 1, 0), Quaternion.identity);
            StartCoroutine(SpawnEnemy());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Water")|| collision.gameObject.CompareTag("Bridge"))
        {
            isGround= true;
        }        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp--;
            
        }
        if (collision.gameObject.CompareTag("Life"))
        {
            hp++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            key = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Gate") && key==true)
        {
            OpenGate.SetActive(true);
            CloseGate.SetActive(false);
            Time.timeScale = 0f;
            WinOver.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            hp--;
        }
        if (collision.gameObject.CompareTag("BossBullet")|| collision.gameObject.CompareTag("Boss"))
        {
            hp -= 2;
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("In Key");
            key = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Gate")&& key==true)
        {
            Debug.Log("In Gate");
            OpenGate.SetActive(true);
            Destroy(CloseGate);
            Time.timeScale = 0f;
            WinOver.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Life"))
        {
            hp++;
            Destroy(collision.gameObject);
        }
    }


}
