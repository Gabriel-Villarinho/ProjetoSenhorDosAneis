using UnityEngine;
using UnityEngine.SceneManagement;
public class bossScript : MonoBehaviour
{
    public Personagem boss = new Personagem(1000, 30, 0f, 0f, "Balrog");
    public BarradeVida barraBoss;
    Jogador player;
    Rigidbody2D rb;
    public GameObject magiaBalrog;
    private float quantMagias = 0;
    private float quantMagias2 = 0;
    private void Awake()
    {
        //Barra de vida
        barraBoss.VidaMaxina(boss.vida);
        barraBoss.nomeChefe.text = boss.nome;
        //Player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Entrada do chefe, congela rotações
        if (transform.position.y <= 3.6f)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            barraBoss.gameObject.SetActive(true);
        }

        //Ataque do chefe
        Atacar();

        //Morte chefe
        if (boss.vida <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadSceneAsync("Ganhou");
        }
    }

    public void Atacar()
    {
        float delayMagia = 2f;
        float delayMagia2 = 1f;
        quantMagias += Time.deltaTime;
        quantMagias2 += Time.deltaTime;
        if (quantMagias >= delayMagia)
        {
            quantMagias = 0; 
            Instantiate(magiaBalrog, new Vector2(transform.position.x - 5f, Random.Range(5.63f, -2.511733f)), Quaternion.identity);
            Instantiate(magiaBalrog, new Vector2(transform.position.x - 5f, Random.Range(5.63f, -2.511733f)), Quaternion.identity);
            Instantiate(magiaBalrog, new Vector2(transform.position.x - 5f, Random.Range(5.63f, -2.511733f)), Quaternion.identity);
            Instantiate(magiaBalrog, new Vector2(transform.position.x - 5f, Random.Range(5.63f, -2.511733f)), Quaternion.identity);
        }
        
        if (quantMagias2 >= delayMagia2)
        {
            quantMagias2 = 0;
            Instantiate(magiaBalrog, new Vector2(Random.Range(-23.83f, 15.07f), 15f), Quaternion.Euler(0, 0, 90f));
            Instantiate(magiaBalrog, new Vector2(Random.Range(-23.83f, 15.07f), 15f), Quaternion.Euler(0, 0, 90f));
            Instantiate(magiaBalrog, new Vector2(Random.Range(-23.83f, 15.07f), 15f), Quaternion.Euler(0, 0, 90f));
            Instantiate(magiaBalrog, new Vector2(Random.Range(-23.83f, 15.07f), 15f), Quaternion.Euler(0, 0, 90f));
            Instantiate(magiaBalrog, new Vector2(Random.Range(-23.83f, 15.07f), 15f), Quaternion.Euler(0, 0, 90f));
            Instantiate(magiaBalrog, new Vector2(Random.Range(-23.83f, 15.07f), 15f), Quaternion.Euler(0, 0, 90f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Magia"))
        {
            boss.PerderVida(player.personage.ataque);
            barraBoss.SetarVida(boss.vida);
        }
    }
}
