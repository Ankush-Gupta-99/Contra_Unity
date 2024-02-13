using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PlayerLoop;

public class MachineGun : MonoBehaviour
{
    int hp = 3;
    private GameObject Player;
    public GameObject Bullet;
    bool isOut = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Update() {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
        
    }
    
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1.3f);
        Instantiate(Bullet,transform.position,Quaternion.identity);
        if (!isOut)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Rota()
    {
        Vector3 rotateDir = Player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(rotateDir, Vector3.forward);
        rotation.x = 0;
        rotation.y = 0;
        rotation.eulerAngles = new Vector3(0, 0, rotation.eulerAngles.z - 3f);
        transform.rotation = rotation;
        yield return new WaitForSeconds(1);
        if (!isOut)
        {            
            StartCoroutine(Rota());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            isOut = false;
            StartCoroutine(Rota());
            StartCoroutine(Fire());
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
            hp = 0;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MainCamera"))
        {            
            isOut = true;
            StopCoroutine(Rota());
            StopCoroutine(Fire());
        }
    }
}
