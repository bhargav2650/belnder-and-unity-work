using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinfan : MonoBehaviour
{
    float spinSpeed = 150.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 11.61528f + (spinSpeed * Time.deltaTime), 0);
    }
}