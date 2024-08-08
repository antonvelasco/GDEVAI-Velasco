using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public GameObject[] tanks;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTank(int tankNumber)
    {
        gameObject.SetActive(false);
        tanks[tankNumber].SetActive(true);
    }
    public void GoBackToSelection(int tankNumber)
    {
        gameObject.SetActive(true);
        tanks[tankNumber].SetActive(false);
    }
}
