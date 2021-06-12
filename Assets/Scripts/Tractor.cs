using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float hmoveSpeed;

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





    void OnTriggerEnter()
    {

    }
    void OnTriggerExit()
    {

    }

}
