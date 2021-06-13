using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
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
        if (collider.tag == "ExtraTrailer")
        {
            var index = tractor.trailers.IndexOf(gameObject);
            var length = tractor.trailers.Count - index;
            // foreach (var item in tractor.trailers)
            // {
            //     if(index <= tractor.trailers.IndexOf(item))
            //     {
            //         item.GetComponent<HingeJoint>().breakForce = 0;
            //     }
            // }

            gameObject.transform.position += new Vector3(0, 0, Time.deltaTime * 10);
            tractor.trailers.RemoveRange(index, length);
            gameObject.GetComponent<Rigidbody>().mass = 1000;
            gameObject.GetComponent<HingeJoint>().breakForce = 0;
        }

    }

}
