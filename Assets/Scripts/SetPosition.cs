using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPosition : MonoBehaviour {

    [SerializeField] GameObject player;
    Vector3 positionInit = new Vector3(-149, 4, -207);
    Vector3 rotationInit = new Vector3(0, 27, 0);

    Vector3 positionMount = new Vector3(228, 9, -4);
    Vector3 rotationMount = new Vector3(0, -92, 0);

    Vector3 positionCave = new Vector3(-12, 4, 118);
    Vector3 rotationCave = new Vector3(0, -183, 0);


    // Use this for initialization
    void Start () {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "woods")
        {
            Debug.Log("Woods");
            switch (PlayerPrefs.GetInt("Transition"))
            {
                case 0:
                    {
                        Debug.Log("Spawn");

                        player.transform.position = positionInit;
                        player.transform.rotation = Quaternion.Euler(rotationInit);
                        
                    }
                    break;
                case 1:
                    {
                        Debug.Log("Mount to Woods");
                        player.transform.position = positionMount;
                        player.transform.rotation = Quaternion.Euler(rotationMount);
                    }
                    break;
                case 2:
                    {
                        Debug.Log("Cave to Woods");
                        player.transform.position = positionCave;
                        player.transform.rotation = Quaternion.Euler(rotationCave);
                    }
                    break;
            }
        }


    
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
