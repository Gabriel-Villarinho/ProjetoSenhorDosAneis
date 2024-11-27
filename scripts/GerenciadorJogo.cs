using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class GerenciadorJogo : MonoBehaviour
{
    int hordas = 0;

    public BarradeVida barraDeVida;

    public List<GameObject> inimigos = new List<GameObject>();

    public bool estaPausado = false;
    [SerializeField]private GameObject menuPausa = null!;

    private Jogador player;

    public GameObject menuGameOver;

    //Spawn Inimigos
    public GameObject inimigoGameObject;
    private float limiteXPositivo = 17.6f; //Limite para Spawn do inimigo
    private float limiteXNegativo = 2f; //Limite para Spawn do inimigo

    public GameObject balrog;
    public GameObject barraBalrog;
    void Start()
    {
        Time.timeScale = 1f;
        barraBalrog.SetActive(false);
        //Hordas de Inimigos
        GameObject[] inimigosArray = GameObject.FindGameObjectsWithTag("Inimigo");
        inimigos = inimigosArray.ToList();
        //Converte uma Array imutável para uma lista mutável, assim conseguindo atualizar o valor da barra de HP dependendo do numero de inimigos
        barraDeVida.VidaMaxina(inimigos.Count);

        hordas = 4;
        barraDeVida.nomeChefe.text = string.Concat("Horda ", hordas);

        //Menu de Pausa e Game Over
        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        GerarInimigos();

        GameObject[] inimigosArray = GameObject.FindGameObjectsWithTag("Inimigo");
        inimigos = inimigosArray.ToList();
        barraDeVida.SetarVida(inimigos.Count);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                ContinuarJogo();
            }
            else
            {
                PausarJogo();
            }
        }
    }
    public void ContinuarJogo()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    public void PausarJogo() {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = true;
        
    }
    public void FinalizarJogo() {
        SceneManager.LoadSceneAsync("Menu");
        Time.timeScale = 1f;
    }
    public void GameOver() { 
        if (player.personage.vida == 0)
        {
            Time.timeScale = 0f;
            menuGameOver.SetActive(true);
        }
    }

    public void GerarInimigos()
    {
        GameObject[] inimigosArray = GameObject.FindGameObjectsWithTag("Inimigo");
        inimigos = inimigosArray.ToList();
        barraDeVida.SetarVida(inimigos.Count);
        if (hordas > 1 && inimigos.Count == 0)
        {
            //Spawna os inimigos da horda em posições aleatórias
            hordas--;
            Instantiate(inimigoGameObject, new Vector2(UnityEngine.Random.Range(limiteXNegativo, limiteXPositivo), transform.position.y), transform.rotation);
            Instantiate(inimigoGameObject, new Vector2(UnityEngine.Random.Range(limiteXNegativo, limiteXPositivo), transform.position.y), transform.rotation);
            Instantiate(inimigoGameObject, new Vector2(UnityEngine.Random.Range(limiteXNegativo, limiteXPositivo), transform.position.y), transform.rotation);
            Instantiate(inimigoGameObject, new Vector2(UnityEngine.Random.Range(limiteXNegativo, limiteXPositivo), transform.position.y), transform.rotation);
            barraDeVida.nomeChefe.text = string.Concat("Horda ", hordas);
        }
        else if (hordas == 1 && inimigos.Count == 0)
        {
            balrog.SetActive(true);
            barraDeVida.gameObject.SetActive(false);
        }
    }
}
