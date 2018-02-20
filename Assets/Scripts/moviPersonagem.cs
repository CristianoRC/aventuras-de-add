using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class moviPersonagem : MonoBehaviour {
	
	private Rigidbody2D rb;
	private Transform tr;
	private Animator an;


	public Transform verificaChao; 
	public Transform verificaParede;

	private bool estaAndando;
	private bool estaNoChao;
	private bool estaNaAgua;
	private bool estaNaParede;
	private bool estaVivo;
	private bool ViradoParaDireita;
	private bool podePular;


	private float Axis;
	public float velocidade;
	public float forcaPulo;
	public float raioValidaChão;
	public float raioValidaParede;
	public float faseAtual;
	public LayerMask solido;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<Transform> ();
		an = GetComponent<Animator> ();

		estaVivo = true;
		ViradoParaDireita = true;

	}
	
	// Update is called once per frame
	void Update () 
	{ 
		


		estaNoChao = Physics2D.OverlapCircle (verificaChao.position, raioValidaChão, solido);
		estaNaParede = Physics2D.OverlapCircle (verificaParede.position, raioValidaParede, solido);



		if (estaVivo)
		{
			
			animations ();

			Axis = Input.GetAxisRaw ("Horizontal"); //pegando o valor do eixo X

			estaAndando = Mathf.Abs (Axis) > 0f; //convertendo para float e verificando, se for maior que 0 é por que está virado para direita

			if (Axis > 0f && !ViradoParaDireita) {
				flip ();
			} else if (Axis < 0f && ViradoParaDireita) {
				flip ();
			}

			if (Input.GetButtonDown ("Jump") && estaNoChao || Input.GetButtonDown ("Jump") && podePular) {
				if(!estaNaParede)
					pulo ();
			}
		}
	}

	void FixedUpdate() 
	{
		
		if (estaAndando) 
		{
			if (ViradoParaDireita && !estaNaParede) 
			{
				andaDireita ();

			} else if(!ViradoParaDireita && !estaNaParede)	
			{
				andaEsquerda ();
			}
		}

	}

	public void flip()
	{
		ViradoParaDireita = !ViradoParaDireita;
		tr.localScale = new Vector2 (-tr.localScale.x, tr.localScale.y); //trocando a escala do objeto para efetuar o flip
	}

	//setando as animações 
	void animations()
	{
		an.SetBool ("movendo", estaNoChao && estaAndando);
	}

	void OnCollisionEnter2D(Collision2D colisao)
	{
		if (colisao.gameObject.tag == "morre") 
		{
			SceneManager.LoadScene ("gameOver");

		}else if (colisao.gameObject.tag == "fase02") 
		{
			SceneManager.LoadScene ("cena_02");
		}else if (colisao.gameObject.tag == "fim") 
		{
			SceneManager.LoadScene ("fim");
		}else if (colisao.gameObject.tag == "objetoPulo") 
		{
			podePular = true;
		}


	}

	//Função para desenhar as linhas de marcação dos colisores (não interfere no codigo)
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere (verificaChao.position, raioValidaChão);
		Gizmos.DrawWireSphere (verificaParede.position, raioValidaParede);
	}

	public void pulo()
	{
		rb.AddForce (tr.up * forcaPulo);	
	}

	public void andaDireita()
	{
		rb.velocity = new Vector2 (velocidade, rb.velocity.y);	

	}
	public void andaEsquerda()
	{
		rb.velocity = new Vector2 (-velocidade, rb.velocity.y);

	}
}
//teste github
