using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ProjetilJogador : MonoBehaviour
{
    public Projetil projetil = new Projetil(0, 15f);
    [SerializeField] private GameObject magiaJogador;
    public Jogador jogador;

    private bool direita;
    private float distanciaPercorrida = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
        projetil.danoProjetil = jogador.personage.ataque;
    }

    void Start()
    {
        LancaProjetil();
        if (jogador.estaDireita == true)
        {
            direita = true;
        }

        else
        {
            direita = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanciaPercorrida += Time.deltaTime;
        if (direita == true)
        {
            transform.Translate(Vector2.right * projetil.velocidadeMovimento * Time.deltaTime);
            jogador.quantInstancia++;
        }
        else {
            transform.Translate(Vector2.left * projetil.velocidadeMovimento * Time.deltaTime);
            jogador.quantInstancia++;
        }

        if (distanciaPercorrida >= 0.5f)
        {
            jogador.quantInstancia = 0;
        }
        
        if (distanciaPercorrida >= 2f)
        {
            Destroy(this.gameObject);
        }
    }
    void LancaProjetil()
    {
        if (jogador.estaDireita == true)
        {
            transform.Translate((Vector2.right * projetil.velocidadeMovimento) * Time.deltaTime);
            distanciaPercorrida += Time.deltaTime;
        }
        else
        {
            transform.Translate((Vector2.left * projetil.velocidadeMovimento) * Time.deltaTime);
            distanciaPercorrida += Time.deltaTime;    
        }
    }
}
