using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tempo : MonoBehaviour {
	public Text contagem;
	public float tempo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (tempo > 0.0f) {
			tempo -= Time.deltaTime;
			contagem.text = tempo.ToString ("F0");
		} else 
		{
			SceneManager.LoadScene ("gameOver");
		}
			
	}
}
