using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject upEffect;
    public GameObject downEffect;
    public GameObject gameOverMenu;
    public GameObject gameOverSound;
    public GameObject pauseMenu;

    public Animator playerAnim;

    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI scoreDisplay;

    private Vector2 targetPos;
    public float yIncrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health;
    public float score;
    public float AstronautaScore = 0;

    public float timeElapsed = 0;

    public List<float> validY = new List<float> { -3, 0, 3 };

    void Start() {
        targetPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update() {

        // Pause o jogo
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

		// Se a vida for 0 ou menos, puxe a tela de game over
        if (health <= 0) {
            gameOverMenu.SetActive(true);
            Instantiate(gameOverSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

		// Defina o texto da IU de vida para o valor atual do jogador
        healthDisplay.text = "Vida: " + health.ToString();

		// Definir pontuação para o tempo decorrido * 100
		score = ((int)(timeElapsed * 100)) + AstronautaScore;
        scoreDisplay.text = "Pontuação: " + score.ToString();

        // Flechina pra cima ou W para ir pra cima
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            && transform.position.y + yIncrement <= maxHeight
            && validY.Contains(transform.position.y)) {

            Instantiate(upEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
        }
		// Flechina pra baixo ou S para ir pra baixo
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            && transform.position.y - yIncrement >= minHeight
            && validY.Contains(transform.position.y)) {

            Instantiate(downEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
        }

        // Mover em direção ao targetPos
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

		// Atualização do tempo decorrido enquanto o jogador estiver vivo
        if (health > 0) {
            timeElapsed += Time.deltaTime;
        }
    }
}
