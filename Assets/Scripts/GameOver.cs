using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			SceneManager.UnloadSceneAsync ("Main");
			SceneManager.LoadScene("yaba2");
		} 
    }
}

//SceneManager.GetActiveScene().buildIndex