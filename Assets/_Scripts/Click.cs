using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Click : MonoBehaviour
{
    private int num = 0;

    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip[] audios;

    [SerializeField]
    TextMeshProUGUI pontos;
    short clipPick;
     
    

    // Start is called before the first frame update
    void Start()
    {
        //PrintaPontuacao();
    }

    //Função básica do click
    public void Clicked()
    {
        clipPick = (short)Random.Range(0, audios.Length); //sorteia um som
    
        num++; 
        pontos.text = num.ToString();
        source.PlayOneShot(audios[clipPick]);
    }

    //Salva a pontuação atual no playerPrefs e fecha o jogo no Android
    public void SaveClose()
    {
        PlayerPrefs.SetInt("pontos", num);
        Application.Quit();
    }

    //Pega os pontos do PlayerPrefs e coloca no Game
    void PrintaPontuacao()
    {
        num = PlayerPrefs.GetInt("pontos", 0);
        pontos.text = num.ToString();
    }

    public int Points {get {return num;}}
}
