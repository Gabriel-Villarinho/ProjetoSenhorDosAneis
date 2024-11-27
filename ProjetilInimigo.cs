using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class ProjetilInimigo : MonoBehaviour
{
    public Projetil projetil = new Projetil(10, 10f);
    private float distanciaPercorrida = 0f;
    private Inimigo inimigo;
    private Jogador jogador;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
        inimigo = GameObject.FindGameObjectWithTag("Inimigo").GetComponent<Inimigo>();
        
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcao = jogador.transform.position - transform.position;
        rb.velocity = new Vector2(direcao.x, direcao.y);    
    }

    // Update is called once per frame
    void Update()
    {
        distanciaPercorrida += Time.deltaTime;
        if (distanciaPercorrida >= 2f)
        {
            Destroy(this.gameObject);
            inimigo.quantProjeteis = 0;
        }
    }

    public void Defendido()
    {
        Destroy(this.gameObject);
        Debug.Log("Projétil defendido");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
