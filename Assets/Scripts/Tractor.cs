using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float hmoveSpeed;
    [SerializeField] GameObject[] trailers;

    private bool isSucceed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, Time.deltaTime * moveSpeed);
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * hmoveSpeed, 0, 0);
        transform.forward = new Vector3(0,0,1);
    }





    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "ExtraTrailer")
        {
            Debug.Log("ExtraTrailer");
            Destroy(collider.gameObject);
            foreach (var trailer in trailers)
            {
                // trailer.transform.localScale += new Vector3(0, transform.localScale.y, 0);
                // trailer.transform.position += new Vector3(0, transform.localScale.y/2, 0);
            }
        }
    }
    void OnTriggerExit()
    {

    }

}
