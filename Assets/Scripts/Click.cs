using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Click : MonoBehaviour
{
    private int num = 0;

    private static float count = 0.8f;

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
        num++;
        pontos.fontSize = 45;
        pontos.text = num.ToString();
        count-= Time.deltaTime;
        if (count <= 0)
        {
            pontos.fontSize = 36;
            count = 0.8f;
        }
    }
}
