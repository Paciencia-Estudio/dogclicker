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
    private AudioClip audioc;

    public AudioClip[] audios;
    short clipPick;
     
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked(TextMeshProUGUI pontos)
    {
        clipPick = (short)Random.Range(0, audios.Length);
    
        num++;
        pontos.text = num.ToString();
        source.PlayOneShot(audios[clipPick]);
    }
}
