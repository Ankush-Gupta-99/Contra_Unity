using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyZomby Boss;
    Slider bar;
    void Start()
    {

        bar = GetComponent<Slider>();
        bar.maxValue = Boss.hp;

    }

    // Update is called once per frame
    void Update()
    {
        bar.value = Boss.hp;
    }
}
