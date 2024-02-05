using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.FilePathAttribute;

public class EnemyBullet : MonoBehaviour
{
    private GameObject Player;
    Rigidbody2D Rigidbody;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Dest");
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Vector3 rotateDir = Player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(rotateDir, Vector3.forward);
        rotation.x = 0;
        rotation.y = 0;
        rotation.eulerAngles = new Vector3(0, 0, rotation.eulerAngles.z - 87.7f);
        transform.rotation = rotation;        
        Rigidbody.velocity = new Vector2(rotateDir.x, rotateDir.y).normalized * 6;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsCollided", true);

            Rigidbody.velocity = Vector2.zero;
            StartCoroutine(Destroyed());
            
        }
    }
    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    IEnumerator Dest()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
