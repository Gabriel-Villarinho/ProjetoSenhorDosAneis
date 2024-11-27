using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalrogMagiaScript : MonoBehaviour
{
    Projetil projetil = new Projetil(10, 20f);
    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector2.left * projetil.velocidadeMovimento) * Time.deltaTime);
    }

    public void Defendido()
    {
        Destroy(this.gameObject);
        Debug.Log("Projétil defendido");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
