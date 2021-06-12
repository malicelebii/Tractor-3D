using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float hmoveSpeed;
    [SerializeField] GameObject extraTrailer;
    [SerializeField] GameObject[] trailers;

    public Animator tractor;



    private bool isSucceed;

    // Start is called before the first frame update
    void Start()
    {
        tractor.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, Time.deltaTime * moveSpeed);
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * hmoveSpeed, 0, 0);
        transform.forward = new Vector3(1, 0, 0);
    }





    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "ExtraTrailer")
        {
            Debug.Log("ExtraTrailer");
            Destroy(collider.gameObject);
            GameObject newTrailer = Instantiate(extraTrailer, trailers[trailers.Length - 1].transform.position - new Vector3(0, 0, 4.5f), Quaternion.identity);

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
