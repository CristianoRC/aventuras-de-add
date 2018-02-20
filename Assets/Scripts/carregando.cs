using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class carregando : MonoBehaviour {
	/*public float faseAtual2;
	public GameObject cavaleiro;*/

	// Use this for initialization
	void Start () {
		

		/*faseAtual2 = cavaleiro.GetComponent<moviPersonagem> ().faseAtual;

		if (faseAtual2 == 0) 
		{
			print ("caiu no primeiro if. valor da variavel = " +faseAtual2);
			SceneManager.LoadScene ("cena_01");
		}else if (faseAtual2 == 1) 
		{
			print ("caiu no segundo if. valor da variavel = " +faseAtual2);
			SceneManager.LoadScene ("cena_02");
		}
*/
	}
	
	// Update is called once per frame
	void Update () {

			SceneManager.LoadScene ("cena_01");
	}
}
