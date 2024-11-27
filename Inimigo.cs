using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int classe; //Define se o inimigo será melee ou arqueiro baseado no numero
    [SerializeField]private GameObject projetil;
    public float distanciaProjetil = 0f;
    public int quantProjeteis = 0; //Delay do tiro do arqueiro

    Personagem personagem = new Personagem(0, 0, 0f, 0f, ""); //Inicializa vazio
    public Jogador jogador;

    private bool estaDireita = false;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteArcher;
    private BoxCollider2D colider;
    void Awake()
    {
        classe = UnityEngine.Random.Range(1, 3);
        ChecarClasse(classe);
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>(); //Pega o script do jogador utilizando da tag
        colider = gameObject.GetComponent<BoxCollider2D>(); // Pega o componente boxcollider
    }

    void Update()
    {
        Atacar();
        if (personagem.vida <= 0)
        {
            Destroy(this.gameObject); //Mata o inimigo
        }
        
        if (jogador.personage.vida > 0)
        {
            float distancia = jogador.transform.position.x - transform.position.x; // Se O jogador estiver na frente do inimigo, mude a rotação do sprite
            if (distancia > 0f)
            {
                estaDireita = true;
                girarSprite();
            }
        }
    }

    public void Atacar()
    {
        //Se o inimigo for guerreiro e o jogador ainda for ativo, ande para cima do jogador
        if (classe == 1)
        {
            if (jogador != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(jogador.transform.position.x, transform.position.y), 5f * Time.deltaTime);
            }
        }
        //Se o inimigo for arqueiro e não atirou ainda, mudar o sprite e atire o projétil
        if (quantProjeteis == 0 && classe == 2)
        {
            spriteRenderer.sprite = spriteArcher;
            colider.size = new Vector2(1f, 2.8185f);
            Instantiate(projetil, transform.position, Quaternion.identity);
            quantProjeteis++;
        }
     
    }
    public void ChecarClasse(int classe)
    {
        //Cria um constructor com atributos diferentes dependendo da classe
        switch(classe)
        {
            case 1:
                personagem = new Personagem(60, 30, 10f, 0f, "Tanque");
              //  Debug.Log(personagem.nome);
                break;
            case 2:
                personagem = new Personagem(25, 20, 0f, 0f, "Ranged");
               // Debug.Log(personagem.nome);
                break;
        }
    }

    void girarSprite()
    {
        //Muda a escala X do sprite para trocar dependendo da direção
        if (estaDireita == false)
        {
            estaDireita = !estaDireita;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Magia")) // Se for atingido pela magia do Gandalf, perder vida
        {
            personagem.PerderVida(jogador.personage.ataque);
            Debug.Log(personagem.vida);
        }
    }
}
