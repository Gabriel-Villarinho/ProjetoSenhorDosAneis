using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem
{
    public int vida { get; set; }
    public int ataque { get; set; }
    public float velocidade { get; set; }
    public float velocidadePulo { get; set; }
    public string nome { get; set; }

    public Personagem(int vida, int ataque, float velocidade, float velocidadePulo, string nome)
    {
        this.vida = vida;
        this.ataque = ataque;
        this.velocidade = velocidade; 
        this.velocidadePulo = velocidadePulo; //Construtor da classe
        this.nome = nome; 
    }
    public void PerderVida(int ataque)
    {
        vida -= ataque; //Reduz a vida presente na variável vida
    }
}
