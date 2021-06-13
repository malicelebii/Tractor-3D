using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tractor : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float hmoveSpeed;
    int diamondCounter;
    [SerializeField] Text diamondText;
    [SerializeField] GameObject extraTrailer;
    public List<GameObject> trailers;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject nextLevelPanel;
    [SerializeField] AudioSource[] audioSource;
    [SerializeField] AudioSource trailerSound;
    [SerializeField] AudioSource diamondSound;
    [SerializeField] GameObject vcamera;

    public Animator tractor;
    public Animator trailer;
    public Animator sheep;
    public Animator chicken;
    public Animator elephant;

    public int test = 5;


    private bool isSucceed;
    private bool gameOver;
    private bool isCrashed;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        trailerSound = audioSource[0];
        diamondSound = audioSource[1];
        // tractor.SetBool("isMoving", true);
        // tractor.SetBool("isMoving", true);
        gameOver = false;
        isSucceed=false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(gameOver==true){
            gameOverPanel.SetActive(true);
            vcamera.SetActive(false);
            return;
        }
        if(isSucceed==true){
            nextLevelPanel.SetActive(true);
            return;
        }
        // if(Input.GetKeyDown("a")){
        //     transform.rotation=Quaternion.Euler(0f,-20f,0f);
        // }
        // if(Input.GetKeyUp("a")){
        //     transform.rotation=Quaternion.Euler(0f,0f,0f);
        // }
        transform.position += new Vector3(0, 0, Time.deltaTime * moveSpeed);
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * hmoveSpeed, 0, 0);
        transform.forward = new Vector3(1, 0, 0);
        // transform.forward = new Vector3(1, 0, 0);

        if (gameOver == true)
        {
            //gameoverpaneli aktif et.
            gameOverPanel.SetActive(true);
        }
        if (isSucceed == true)
        {
            //succeedpaneli aktif et.
            nextLevelPanel.SetActive(true);
        }


        diamondText.text = diamondCounter.ToString();
    }





    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "ExtraTrailer")
        {
            audioSource[0].Play();
            Destroy(collider.gameObject);
            if (trailers.Count > 0) {
                GameObject newTrailer = Instantiate(extraTrailer, trailers[trailers.Count - 1].transform.position - new Vector3(0, 0, 10.8f), Quaternion.identity);
                newTrailer.transform.rotation= Quaternion.Euler(0, 90, 0);
                newTrailer.GetComponent<HingeJoint>().connectedBody=trailers[trailers.Count-1].GetComponent<Rigidbody>();
                trailers.Add(newTrailer);
            } 
            else {
                Debug.Log("Else");
                GameObject newTrailer = Instantiate(extraTrailer, gameObject.transform.position - new Vector3(0, 0, 0.25f), Quaternion.identity);
                newTrailer.transform.rotation= Quaternion.Euler(0, 90, 0);
                newTrailer.GetComponent<HingeJoint>().connectedBody=gameObject.GetComponent<Rigidbody>();
                trailers.Add(newTrailer);
            }
        }
        if (collider.tag == "Diamond")
        {
            audioSource[1].Play();
            Debug.Log("Diamond");
            
            Destroy(collider.gameObject);
            diamondCounter++;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle"){

            Crashed();
        }
        if (collision.gameObject.tag == "LastGround"){
            moveSpeed = 10f;
            sheep.SetBool("eat",true);
            chicken.SetBool("eat",true);
            elephant.SetBool("eat",true);
            Debug.Log("collision detected");
           Invoke("Succeed",5f);
        }
    }
    void OnTriggerExit()
    {

    }
    void Succeed(){
            isSucceed=true;
    }

    void Crashed()
    {
        tractor.SetBool("isCrashed", true);
        gameOver = true;
        isSucceed = false;
    }


}
