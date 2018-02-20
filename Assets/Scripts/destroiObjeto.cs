using UnityEngine;
using System.Collections;

public class destroiObjeto : MonoBehaviour {
	private Rigidbody2D caixaRB;
	public Vector3 posicao;
	public GameObject caixaPrefab;

	// Use this for initialization
	void Start () {
		caixaRB = GetComponent<Rigidbody2D>();
	
		posicao = transform.position;

	}

	void OnBecameInvisible(){
		
		Instantiate (caixaPrefab, posicao, transform.localRotation);
		Destroy (this.gameObject);

	}

	}