using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil
{
   public int danoProjetil { get; set; }
    public float velocidadeMovimento { get; set; }

    public Projetil(int danoProjetil, float velocidadeMovimento)
    {
        this.danoProjetil = danoProjetil;
        this.velocidadeMovimento = velocidadeMovimento;
    }

    public int CausarDano(int danoProjetil)
    {
        return danoProjetil; // Causa dano
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            CausarDano(danoProjetil); // Chama o método CausaDano
        }
    }
}
