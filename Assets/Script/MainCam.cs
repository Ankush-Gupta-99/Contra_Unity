/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
/*using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;*/

public class MainCam : MonoBehaviour
{
 /*   public PlayerScript player;


    private float smoothSpeed = 0.021f;
    private Vector3 offset = new(6, 0, 0);
*/
    // Start is called before the first frame update
    void Start()
    {

    }



   /* private void LateUpdate()
    {
        if (
            (player.transform.position.x < (transform.position.x - 9)) || 
            (player.transform.position.x > (transform.position.x - 1)) || 
            (player.transform.position.y < (transform.position.y - 4)) || 
            (player.transform.position.y > (transform.position.y+4))
            )
        {
            Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y, -1) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        
    }*/






    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")|| collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

    }














}
