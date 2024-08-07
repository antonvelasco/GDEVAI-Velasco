using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private float currentHP = 100;
    public float maxHealth;

    public float getHpPercent()
    {
        return currentHP / maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            currentHP -= 10;
        }
    }
}
