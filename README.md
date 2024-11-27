# Senhor dos Anéis: "You Shall Not Pass" - Documentação  

<br>  
<table>  
  <tr>  
    <td>  
      <p>Projeto desenvolvido por Igor Michelini e Gabriel Lima. Este jogo recria a cena de *Senhor dos Anéis* onde Gandalf enfrenta o Balrog na ponte de Khazad-dûm. O objetivo é trazer mecânicas inspiradas na magia e na ação da cena original.</p>  
    </td>  
  </tr>  
</table>  
<br>  

## Link para o Projeto
https://drive.google.com/drive/folders/1d8thGHD-2p16Pm9SXCERs-vuivXDWYjG?usp=sharing

## Descrição do jogo  

<p>O jogo se passa na famosa cena "You Shall Not Pass", onde Gandalf enfrenta inimigos e o chefe final, Balrog, em uma batalha épica na ponte. O jogador utiliza magias de ataque e defesa para superar os desafios enquanto enfrenta ondas de esqueletos e o Balrog. A jogabilidade combina ação e estratégia, exigindo habilidade para atacar e se defender no momento certo.</p>  
<br>  

## Cena Original: "You Shall Not Pass"  
<p>O jogo é inspirado na cena de O Senhor dos Anéis: A Sociedade do Anel, onde Gandalf enfrenta o Balrog na ponte de Khazad-dûm. Neste momento, Gandalf utiliza sua magia para proteger a Sociedade do Anel, bloqueando o avanço do Balrog com a frase "You shall not pass!" e destruindo a ponte para impedir o inimigo.</p>  
<br>  

Essa cena é marcada pela coragem de Gandalf, que sacrifica sua segurança para garantir a sobrevivência do grupo. O jogo recria os desafios deste confronto épico, permitindo que o jogador controle Gandalf em sua luta contra o Balrog e outros inimigos.  

## Menus  

### Menu Principal  

O menu principal do jogo apresenta uma imagem de Gandalf e os anões caminhando pelas montanhas. Ele possui dois botões: "Jogar" para iniciar o jogo e "Sair" para fechar o jogo.

- **Botões**: "Jogar" (inicia o jogo) e "Sair" (fecha o jogo).  
- **Imagem de fundo**: Gandalf e os anões caminhando pelas montanhas, remetendo a sensação de aventura do filme.

<table>  
<thead>  
  <th>  
    
  ![a94e8bae-aaf9-4eb6-8910-abc372ddb33c](https://github.com/user-attachments/assets/19d81329-45bd-47bc-85ce-2f660cbd6473)
  </th>  
</thead>  
</table>  

### Menu de Vitória  

Quando o jogador completa a fase e vence, o menu de vitória aparece com uma imagem de Gandalf, destacando sua conquista. A mensagem "Você Ganhou" é exibida, e o botão "Voltar" permite que o jogador retorne ao menu principal.

- **Mensagem**: "Você Ganhou"  
- **Botão**: "Voltar" (retorna ao menu principal).  
- **Imagem de fundo**: Uma imagem de Gandalf, simbolizando sua vitória após derrotar o Balrog.

<table>  
<thead>  
  <th>  
    
  ![f241ac58-c269-44b5-b960-9d95c4265dc5](https://github.com/user-attachments/assets/70bfc3c4-e261-41be-9027-a163a4087105)
  </th>  
</thead>  
</table>  

## Músicas:
 - Menu Principal: Great Grey Wolf Sif, Dark Souls 1.
 - Jogo: Unstoppable Force - Ultrakill.
 - Vitória: Soul of Cinder - Dark Souls 3.
### Sons:
 - Parry: Efeito de parry do jogo Nine Sols.

## Mecânicas  

- **Magia de Ataque**: Gandalf pode lançar bolas de fogo que causam dano aos inimigos.  
- **Escudo de Magia**: Uma magia defensiva que reflete projéteis na direção oposta.  

## Inimigos  

- **Esqueleto Arqueiro**: Atira flechas na direção de Gandalf, exigindo que o jogador use o escudo para refletir ou desvie.  
- **Esqueleto Guerreiro**: Corre na direção de Gandalf para atacá-lo, exigindo atenção e reação rápida.  

## Chefe Final  

- **Balrog**: O chefe da fase lança bolas de fogo como ataque principal. O jogador precisa combinar o uso do escudo e de saltos precisos para desviar dos projéteis e atacar nos momentos de oportunidade.  

## Programação  

### Classes Criadas  

#### **Personagem**  
Gerencia os atributos do personagem, incluindo:  
- **Atributos**: Dano, vida, velocidade, entre outros.  
- **Métodos**:  
  - **Construtor**: Define os valores iniciais do personagem.  
  - **PerderVida**: Reduz a vida do personagem com base no dano recebido.  

##### **Print da Classe Personagem**  
<table>  
<thead>  
  <th>  
    *Print da classe Personagem será inserido aqui*  
  </th>  
</thead>  
</table>  

#### **Projétil**  
Controla as características dos projéteis, incluindo:  
- **Atributos**: Dano e velocidade de movimento.  
- **Métodos**:  
  - **OnTriggerEnter2D**: Detecta colisões e chama o método CausarDano.  
  - **Defendido**: Reverte a velocidade do projétil, fazendo-o voltar na direção oposta.  
  - **CausarDano**: Aplica dano ao personagem atingido.  

##### **Print da Classe Projétil**  
<table>  
<thead>  
  <th>  
    *Print da classe Projétil será inserido aqui*  
  </th>  
</thead>  
</table>  

## Outros Scripts  

### Script do Chefe (Balrog)  
Controla o comportamento e os ataques do Balrog, incluindo os projéteis e a movimentação durante o combate.  

### Gerenciador do Jogo  
Script responsável pela transição de cenas, gerenciamento de pontuação e controle do fluxo do jogo.  

### Projétil Inimigo  
Controla a trajetória e o comportamento dos projéteis disparados pelos esqueletos.  

### Script do Player  
Gerencia os movimentos e ações de Gandalf, incluindo ataques e uso do escudo.  

### Barra de Vida  
Script responsável por atualizar e controlar a barra de vida do personagem.  

### Script do Inimigo  
Gerencia o comportamento dos esqueletos, incluindo sua movimentação e ataques. 

## Elementos Gráficos e Visuais  

### Cenário (Caverna)  

O cenário do jogo é ambientado em uma caverna subterrânea, inspirada nas Minas de Moria, com paredes rochosas e iluminação suave que evoca o clima de claustrofobia e tensão. O fundo apresenta detalhes como estalactites, pedras e um ambiente sombrio, perfeito para a batalha épica entre Gandalf e o Balrog.  

<table>  
<thead>  
  <th>
    
  ![b37d6e32-9480-498b-b282-684c89b08158](https://github.com/user-attachments/assets/6b27be4f-3922-4185-aaa9-25da289f587a)
  </th>  
</thead>  
</table>  

### Sprites em Pixel Art  

- **Gandalf**: O personagem principal, Gandalf, é representado por um sprite pixel art, com seu manto e bastão, fiel à sua aparência nos filmes.  
- **Escudo de Gandalf**: O escudo de Gandalf é um item visualmente simplificado, que reflete os projéteis inimigos, com uma textura brilhante.
- **Esqueleto Arqueiro**: O esqueleto arqueiro é retratado com um arco, atirando flechas de forma contínua até que Gandalf o derrote.
- **Flechas dos Esqueletos**: As flechas disparadas pelos esqueletos arqueiros têm um design simples ara facilitar a identificação.  
- **Projétil de Magia Azul**: A bola de fogo de Gandalf, usada para ataque, é desenhada em pixel art com um tom azul vívido para indicar seu poder mágico.  
- **Esqueletos Guerreiros**: O esqueleto guerreiro é representado com espadas, em um estilo pixel art, avançando em direção a Gandalf para combate corpo a corpo.  
- **Balrog (Chefe Final)**: O Balrog, o chefe final, é o d maior em estatura e desafio, representado em pixel art, com suas quentes e asas demoníacas.  

<table>  
<thead>  
  <th>  
    *Espaço reservado para as imagens*  
  </th>  
</thead>  
</table>  

### Barra de Vida  

A barra de vida do personagem aparece na parte superior da tela, representando a saúde de Gandalf durante a batalha. Quando ele é atingido, a barra diminui gradualmente.  

<table>  
<thead>  
  <th>  
    
   ![03cb75de-842f-40ca-8a8e-5d900f8330c0](https://github.com/user-attachments/assets/59759568-c0e6-4eb5-9d9f-bd009f6a9d82)
  </th>  
</thead>  
</table>  

### Chão  

O chão da caverna é composto por rochas e uma textura simples, mas funcional, para garantir que o jogador tenha uma boa percepção do movimento de Gandalf durante a luta.  

<table>  
<thead>  
  <th>  
    
   ![17cf6990-7a36-4985-b16a-7db9a1fc744a](https://github.com/user-attachments/assets/af10de67-2ece-4c0b-b3ed-6d16a6b11b8c)
  </th>  
</thead>  
</table>  

---

## Ambientação e Paleta de Cores  

A paleta de cores do jogo foi escolhida para manter a sensação de um ambiente medieval, com tons escuros e quentes, como o vermelho e  laranja, e o cinza das pedras. A iluminação suave e as sombras criam uma atmosfera sombria, com toques de luz azul que representam o poder mágico de Gandalf. A estética do jogo é simples, com um visual pixel art que remete aos jogos clássicos, mantendo o clima medieval.  


## Gameplay do jogo (vídeo)

<table>  
<thead>  
  <th>  
    



[Gameplay](https://github.com/user-attachments/assets/d3db5cc6-e715-4a40-8125-c9159edc3ffd)


</th>  
</thead>  
</table>  

> ## Referências

### Músicas utilizadas:

[Música jogo](https://www.youtube.com/watch?v=tkLVbp0IH_E)

[Menu principal](https://youtu.be/BjEYqqjw5fM?si=w2tUWpTmk_4N_lIB)

[Música vitória](https://youtu.be/dXcwGZV5Or4?si=P6MkQdf4agqFJsfz)
