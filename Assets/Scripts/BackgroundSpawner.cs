using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundSpawner : MonoBehaviour
{
    public float speed;
   
    public float endX;
    public float startX;

    private float timeElapsed = 0;

    public float speedMultiplierCoefficient;
    private float speedMultiplier;

    void Update() {

		if (SceneManager.GetActiveScene().name == "Main") { // O plano de fundo acelera se estiver no jogo principal
            timeElapsed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().timeElapsed;
            speedMultiplier = 1 + (speedMultiplierCoefficient * timeElapsed);
        }
		else if (SceneManager.GetActiveScene().name == "Menu") { // A velocidade de fundo é constante se estiver no menu
            speedMultiplier = 1;
        }

        transform.Translate(Vector2.left * (speed * speedMultiplier) * Time.deltaTime);

        if (transform.position.x <= endX) { // Repetir background
            Vector3 pos = new Vector3(startX, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }
}
