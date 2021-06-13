using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float hmoveSpeed;
    [SerializeField] GameObject extraTrailer;
    public List<GameObject> trailers;


    public Animator tractor;
    public Animator trailer;

    public int test = 5;



    private bool isSucceed;

    // Start is called before the first frame update
    void Start()
    {
        tractor.SetBool("isMoving", true);
        // tractor.SetBool("isMoving", true);
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
            Destroy(collider.gameObject);
            if (trailers.Count > 0) {
                GameObject newTrailer = Instantiate(extraTrailer, trailers[trailers.Count - 1].transform.position - new Vector3(0, 0, 10.8f), Quaternion.identity);
                newTrailer.transform.rotation= Quaternion.Euler(0, 90, 0);
                newTrailer.GetComponent<HingeJoint>().connectedBody=trailers[trailers.Count-1].GetComponent<Rigidbody>();
                trailers.Add(newTrailer);
            } 
            else {
                Debug.Log("Else");
                GameObject newTrailer = Instantiate(extraTrailer, gameObject.transform.position - new Vector3(8, 0, 10.8f), Quaternion.identity);
                newTrailer.transform.rotation= Quaternion.Euler(0, 90, 0);
                newTrailer.GetComponent<HingeJoint>().connectedBody=gameObject.GetComponent<Rigidbody>();
                trailers.Add(newTrailer);
            }
        }
    }
    void OnTriggerExit()
    {

    }

}
