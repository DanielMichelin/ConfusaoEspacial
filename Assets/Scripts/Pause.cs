using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	// O update é chamado uma vez por frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
