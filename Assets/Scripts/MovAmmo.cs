using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAmmo : MonoBehaviour
{

    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0,0,vel * Time.deltaTime);
    }
}
