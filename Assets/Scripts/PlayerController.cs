using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 30f;
    public Transform vrCamera;
    private CharacterController cc;
    public GameObject player;

    private Vector3 headDirection = Vector3.zero;



	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        if(player.transform.position.y < -130)
        {
            player.transform.position = new Vector3(-18, 78, -71);
        }

        Debug.Log(GvrControllerInput.TouchPos.x);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }




        //---------------------------------- FORWARDS AND BACKWARDS ------------------------------------------------------------------
        if (GvrControllerInput.TouchPos.x > 0.3 && GvrControllerInput.TouchPos.x < 0.7)
        {
            //---------------------------------------------- MOVE IN CAMERA DIRECTION ------------------------------------------------
            if (GvrControllerInput.TouchPos.y < 0.3)
            {
                Debug.Log("Top of controller pressed");

                if (isWalking())
                {
                    transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
                }
                


            }
            //------------------------------------------- MOVE OPPOSITE CAMERA DIRECTION ---------------------------------------------
            if (GvrControllerInput.TouchPos.y > 0.7)
            {
                Debug.Log("Bottom of controller pressed");

                if (isWalking())
                {
                    transform.position = transform.position - Camera.main.transform.forward * speed * Time.deltaTime;
                }
                
            }

        }



        //-------------------------------------- LEFT AND RIGHT ----------------------------------------------------------------------
        if (GvrControllerInput.TouchPos.y > 0.3 && GvrControllerInput.TouchPos.y < 0.7)
        {


            //---------------------------------------------- MOVE TO THE LEFT --------------------------------------------------------
            if (GvrControllerInput.TouchPos.x < 0.3)
            {
                Debug.Log("Left of controller pressed");

                if (isWalking())
                {
                    Vector3 v3 = -Camera.main.transform.right;
                    transform.position = transform.position - Camera.main.transform.right * speed * Time.deltaTime;
                }
                

            }


            //---------------------------------------------- MOVE TO THE RIGHT -------------------------------------------------------
            if (GvrControllerInput.TouchPos.x > 0.7)
            {
                Debug.Log("Right of controller pressed");

                if (isWalking())
                {
                    transform.position = transform.position + Camera.main.transform.right * speed * Time.deltaTime;
                }
                

              
            }
            

        }



    }

    private bool isWalking()
    {
        if (GvrControllerInput.IsTouching)
        {
            return true;
        }
        return false;
    }



}
