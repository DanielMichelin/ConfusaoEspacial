using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			SceneManager.UnloadSceneAsync ("Main2");
			SceneManager.LoadScene("Menu");
		} 
    }
}

//SceneManager.GetActiveScene().buildIndex