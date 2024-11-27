using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BarradeVida : MonoBehaviour
{
    public Slider slider; // O preenchimento da barra de vida
    public TextMeshProUGUI nomeChefe; // O nome que aparecerá debaixo da barra de vida
    public void VidaMaxina(int vida) // Define a vida máxima
    {
        slider.maxValue = vida; 
        slider.value = vida;
    }

    public void SetarVida(int vida) //Atualiza o tamanho da barra de acordo com a vida
    {
        slider.value = vida;
    }
}
