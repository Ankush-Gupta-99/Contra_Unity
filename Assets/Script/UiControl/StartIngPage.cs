using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartIngPage : MonoBehaviour
{
    Image image;
    float fillAmo = 0;
    Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 0;

        coroutine=StartCoroutine(FillSet());
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount += fillAmo;
        if (Input.GetKeyDown(KeyCode.KeypadEnter)||Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(2);
            SceneManager.UnloadScene(0);
            
        }
    }
    IEnumerator FillSet()
    {
        yield return new WaitForSecondsRealtime(13f);
        fillAmo = 0.002f;
        coroutine=StartCoroutine(NewLoad());
    }
    IEnumerator NewLoad()
    {
        yield return new WaitForSecondsRealtime(4f);
        SceneManager.LoadScene(1);
    }
    IEnumerator Dest()
    {
        yield return new WaitForSeconds(1f);
        StopAllCoroutines();
    }
}
