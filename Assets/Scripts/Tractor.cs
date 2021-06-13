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
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject nextLevelPanel;
    public GameObject[] trailers;


    public Animator tractor;
    public Animator trailer;


    private bool isSucceed;
    private bool gameOver;
    private bool isCrashed;

    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("ExtraTrailer");
            Destroy(collider.gameObject);
            GameObject newTrailer = Instantiate(extraTrailer, trailers[trailers.Length - 1].transform.position - new Vector3(0, 0, 4.5f), Quaternion.identity);

            foreach (var trailer in trailers)
            {
                // trailer.transform.localScale += new Vector3(0, transform.localScale.y, 0);
                // trailer.transform.position += new Vector3(0, transform.localScale.y/2, 0);
            }
        }
        if (collider.tag == "Diamond")
        {
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

            isSucceed=true;
        }
    }
    void OnTriggerExit()
    {

    }

    void Crashed()
    {
        tractor.SetBool("isCrashed", true);
        gameOver = true;
        isSucceed = false;
    }


}
