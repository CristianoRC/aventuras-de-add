#pragma strict

var Animador: Animator;
var rb: Rigidbody2D;
var colisao: RaycastHit2D;
var caixaColisao: BoxCollider2D;
var forcaPulo: float;

function Start ()
{
	Animador.SetBool ("noChao", true);
	Animador.SetBool ("movendo", false);
	Animador.SetBool ("atacando", false);
} 

function Update () 
{
	Animador.SetBool ("noChao", noChao());

	if(noChao())
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			pulando();
		}
	}
}

function pulando()
{
	Animador.SetBool ("noChao", false);
	rb.AddForce(transform.up*forcaPulo); 
}
function noChao():boolean
{
	colisao = Physics2D.Raycast(transform.position,-transform.up,caixaColisao.size.y/1.958);
	if(colisao)
		return(true);
	else
		return(false); 
}
