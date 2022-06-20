using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryMenu : MonoBehaviour
{
	public GameObject History1;
	public GameObject History2;
	public GameObject History3;
	public GameObject History4;


	void Start()
	{
		StartCoroutine(waiter());
	}

	IEnumerator waiter()
	{
		History1.SetActive(true);

		yield return new WaitForSecondsRealtime(2);

		History2.SetActive(true);

		yield return new WaitForSecondsRealtime(5);

		History3.SetActive(true);

		yield return new WaitForSecondsRealtime(5);

		History4.SetActive(true);

		yield return new WaitForSecondsRealtime(5);
	
		SceneManager.LoadScene("Main");
	}
		
    // Update is called once per frame
    void Update()
    {
        
    }
}
