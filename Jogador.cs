using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    float horizontal; //Velocidade horizontal
    float velocidadee;
    float velocidadeePulo;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject projetil;
    public Vector2 projetilPosicao;

    public Personagem personage = new Personagem(50, 20, 20f, 15f, "Gandalf");
    public bool estaDireita = true;
    public int quantInstancia = 0;

    [SerializeField]private LayerMask chaoLayer; //Pega a layer do ch�o 
    [SerializeField]private Transform checarChao; //Checa se o Jogador est� no ch�o para pular

    //Magia de escudo
    public float delayEscudo = 0;
    public float tamanhoEscudo;
    public Transform escudoPos;
    public LayerMask projeteis;
    public AudioSource somParry;
    public GameObject magiaEscudoSprite;

    public BarradeVida barraPlayer;
    public GameObject balrog;
    public void Awake()
    {
        //Define atributos b�sicos como velocidade e o valor da barra de vida
        velocidadee = 10f;
        velocidadeePulo = 10f;
        personage.velocidade = velocidadee;
        personage.velocidadePulo = velocidadeePulo;

        barraPlayer.VidaMaxina(personage.vida);

        magiaEscudoSprite.SetActive(false);
    }

    private void Update()
    {
        Atacar();
        Defender();
        PlayerMorrer();
        GirarPersonagem();

        horizontal = Input.GetAxisRaw("Horizontal"); //Detecta se o eixo X est� recebendo algum input, sendo A, D, Seta Esquerda ou Direita
        if (Input.GetButtonDown("Jump") && estaNoChao()) //Se o jogador estiver no ch�o, adicionar velociade vertical
        {
            rb.velocity = new Vector2(rb.velocity.x, velocidadeePulo);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * velocidadee, rb.velocity.y); //Adiciona velocidade horizontal, feito no FixedUpdate pois � independente de fps
    }

    public void Atacar()
    {
        if (Input.GetButtonDown("Fire1") && quantInstancia == 0)
        {
            projetilPosicao = new Vector2(this.transform.position.x , this.transform.position.y); //Instancia o projetil um pouco a frente do jogador para n�o puxar
            if (estaDireita == true)
            {
                projetilPosicao.x += 2f;
            }
            else
            {
                projetilPosicao.x -= 3f;
            }
            Instantiate(projetil, projetilPosicao, Quaternion.identity);
        }
    }

    public void Defender()
    {
        if (Input.GetButtonDown("Fire2") && delayEscudo <= 0) 
        {
            //Verifica todos os Collider2D presentes no OverlapCircleAll na layer Proj�teis, que recebe os valores da posi��o e tamanho do escudo
            Collider2D[] projeteisRefletir = Physics2D.OverlapCircleAll(escudoPos.position, tamanhoEscudo, projeteis);

            magiaEscudoSprite.SetActive(true);
            //A cada proj�til presente nele, chame a fun��o "Defendido" do proj�til, reseta o delay do escudo, mostra o sprite e toca um som
            for (int i = 0; i < projeteisRefletir.Length; i++)
            {
                if (balrog.activeSelf == false && personage.vida >= 1)
                {
                    projeteisRefletir[i].GetComponent<ProjetilInimigo>().Defendido();

                }
                else if(balrog.activeSelf == true && personage.vida >= 1) { 
                    projeteisRefletir[i].GetComponent<BalrogMagiaScript>().Defendido();
                }
                delayEscudo = 0f;
                somParry.Play();
            }
            delayEscudo += Time.deltaTime; //Recarrega o delay 
        }
        else
        {
            delayEscudo -= Time.deltaTime; //Para n�o aumentar infinitamente o delay do escudo
            magiaEscudoSprite.SetActive(false); //Desativa o escudo novamente
        }
    }

    public void PlayerMorrer() {
        if (personage.vida <= 0) {
            Destroy(this.gameObject);
            Destroy(barraPlayer.gameObject);
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            personage.PerderVida(5);
            barraPlayer.SetarVida(personage.vida);
        }
        else if (collision.gameObject.tag == "ParedeFogo")
        {
            personage.PerderVida(5);
            barraPlayer.SetarVida(personage.vida);
        }
        else if (collision.gameObject.tag == "Chefe")
        {
            bossScript balrogScript = GameObject.FindGameObjectWithTag("Chefe").GetComponent<bossScript>();
            personage.PerderVida(balrogScript.boss.ataque);
            barraPlayer.SetarVida(personage.vida);
        }
        else if (collision.gameObject.tag == "Magia")
        {
            Destroy(collision.gameObject);
        }
    }
    void GirarPersonagem()
    {
        if (estaDireita == true && horizontal < 0f || !estaDireita && horizontal > 0f)
        {
            estaDireita = !estaDireita; //Jogador muda de dire��o
            Vector3 localScale = transform.localScale; 
            localScale.x *= -1f;
            transform.localScale = localScale; //Multiplica a escala X por -1, assim mudando a rota��o do sprite
        }
    }

    public bool estaNoChao()
    {//Cria uma �rea de c�rculo de tamanho 0.3f, retornar� verdadeiro caso o checarChao encontre algo presente no circulo que est� na layer Ch�o
        return Physics2D.OverlapCircle(checarChao.position, 0.3f, chaoLayer); 
    }
}
