using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    private int hp = 20;
    public GameObject Bullet;
    public GameObject key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            key.SetActive(true);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {            
            StartCoroutine(BFire());
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp--;
        }
    }
    IEnumerator BFire()
    {
        yield return new WaitForSeconds(1.3f);
        Instantiate(Bullet,transform.position,Quaternion.identity);
        StartCoroutine(BFire());
    }
}
