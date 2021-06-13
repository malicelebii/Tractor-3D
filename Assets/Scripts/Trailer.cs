using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    [SerializeField] Animator trailer;
    // Start is called before the first frame update
    public Tractor tractor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
        void FixedUpdate()
    {

        transform.forward = new Vector3(1,0,0);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Obstacle")
        {

        }

    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Obstacle") {
                if (tractor.trailers.Count > 0){
                var index = tractor.trailers.IndexOf(gameObject);
                if (index == -1) {
                    return;
                }
                Debug.Log(index);
                var length = tractor.trailers.Count - index;
                gameObject.transform.position += new Vector3(0, 0, Time.deltaTime * 10);
                tractor.trailers.RemoveRange(index, length);
                gameObject.GetComponent<Rigidbody>().mass = 1000;
                gameObject.GetComponent<HingeJoint>().breakForce = 0;
                Debug.Log("obstacle carpis");
            }
        }
        Crashed();  
    }

    void Crashed(){
        trailer.SetBool("isCrashed",true);

    }   
    
}
