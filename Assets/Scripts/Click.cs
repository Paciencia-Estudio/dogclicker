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
        PrintaPontuacao();
    }

    public void Clicked()
    {
        clipPick = (short)Random.Range(0, audios.Length);
    
        num++;
        pontos.text = num.ToString();
        source.PlayOneShot(audios[clipPick]);
    }

    public void SaveClose()
    {
        PlayerPrefs.SetInt("pontos", num);
        Application.Quit();
    }

    void PrintaPontuacao()
    {
        num = PlayerPrefs.GetInt("pontos", 0);
        pontos.text = num.ToString();
    }
}
