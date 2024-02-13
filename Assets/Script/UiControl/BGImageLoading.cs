using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BGImageLoading : MonoBehaviour
{
    Image image;
    float fillAmo=0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 0;
        
        StartCoroutine(FillSet());
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount += fillAmo;
    }
    IEnumerator DeLoad()
    {
        yield return new WaitForSecondsRealtime(5f);
        fillAmo = -fillAmo;
        image.fillClockwise = false;
        
    }
    IEnumerator FillSet()
    {
        yield return new WaitForSecondsRealtime(5f);
        fillAmo = 0.002f;
        StartCoroutine(DeLoad());
    }
    
}
