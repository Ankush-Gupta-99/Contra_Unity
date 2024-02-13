using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float tigtime;
    Transform start ;
    public Rigidbody2D rb;
    public BoxCollider2D capsuleCollider;
    public bool isGround;
    public GameObject Bullet;
    public SpriteRenderer SR;
    public static PlayerScript instance;
    public GameObject Enemysol;
    public GameObject GameOver;
    public GameObject OpenGate;
    public GameObject CloseGate;
    public GameObject WinOver;
    public TMP_Text HP;
    public int hp = 5;

    private bool key = false;
    public bool NotInWater = true;
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
        capsuleCollider= GetComponent<BoxCollider2D>();
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








        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h*5.5f, rb.velocity.y);

        if (h < 0)
        {
            transform.eulerAngles=new Vector3(0,180,0);
        }
        else
        {
            transform.eulerAngles=new Vector3(0,0,0);
           
        }      
        
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.X) && NotInWater && isGround)
        {
            isGround = false;
            capsuleCollider.isTrigger = true;
            StartCoroutine("turnofTriger");
        }
        else if (Input.GetKeyDown(KeyCode.X) && isGround)
        {
            rb.AddForce(new Vector2(0, 12), ForceMode2D.Impulse);
            
            capsuleCollider.isTrigger = true;
            isGround = false;
            NotInWater = true;
            StartCoroutine("turnofTriger");
            
        }
        
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }




    IEnumerator turnofTriger()
    {
        yield return new WaitForSeconds(tigtime);
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
        
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Water")
            || collision.gameObject.CompareTag("Bridge"))
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
