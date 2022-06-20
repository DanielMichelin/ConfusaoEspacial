using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronauta : MonoBehaviour
{
    public GameObject[] AstronautaSounds;
    public GameObject effect;

    public float speed;

    private float timeElapsed = 0;

    public float speedMultiplierCoefficient;
    private float speedMultiplier = 1;

	void Start()
	{

	}


    // Update é chamado uma vez por frame
    void Update()
    {
        timeElapsed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().timeElapsed;
        speedMultiplier = 1 + (speedMultiplierCoefficient * timeElapsed);

        transform.Translate(Vector2.left * (speed * speedMultiplier) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

			int randAstronautaSounds = Random.Range(0, AstronautaSounds.Length);
			Instantiate(AstronautaSounds[randAstronautaSounds], transform.position, Quaternion.identity); // Som de ganho de placar na colisao com o player

            Instantiate(effect, transform.position, Quaternion.identity); // Particula na colisao com o Player

            other.GetComponent<PlayerController>().AstronautaScore += 500; // 500 de pontacao quando coleta o Astronauta

            Destroy(gameObject);
        }
    }
}
