using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{

    Vector3 noktaA = new Vector3(40, 1, 0);
    Vector3 noktaB = new Vector3(60, 1, 0);
    float hiz = 0.8f;
    float t;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //volta
        t += Time.deltaTime * hiz;
        transform.position = Vector3.Lerp(noktaA, noktaB, t);
        if (t >= 1)
        {
            var b = noktaB;
            var a = noktaA;
            noktaA = b;
            noktaB = a;
            t = 0;
        }
    }
}
