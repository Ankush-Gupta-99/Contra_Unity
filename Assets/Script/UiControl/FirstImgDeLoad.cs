using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FirstImgDeLoad : MonoBehaviour
{
    Image image;
    float fillAmo = 0.002f;
    // Start is called before the first frame update
    void Start()
    {

        image = GetComponent<Image>();
        image.fillAmount = 1;
        StartCoroutine(DeLoad());
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount += fillAmo;
    }
    IEnumerator DeLoad()
    {
        yield return new WaitForSecondsRealtime(2f);
        fillAmo = -fillAmo;
    }
}
