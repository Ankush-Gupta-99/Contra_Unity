using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BufferScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(1);
    }
}
