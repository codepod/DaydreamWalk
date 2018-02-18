using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour {

    [SerializeField] private string LoadScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter");
            SceneManager.LoadScene(LoadScene);
        }
    }

    // Use this for initialization
    void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "mountain")
        {
            PlayerPrefs.SetInt("Transition", 1);
            PlayerPrefs.Save();
        }else if(sceneName == "cave")
        {
            PlayerPrefs.SetInt("Transition", 2);
            PlayerPrefs.Save();
        }
      

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
