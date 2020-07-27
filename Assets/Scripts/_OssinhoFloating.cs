using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _OssinhoFloating : MonoBehaviour
{
    public bool test;

    private Vector2 myPos;
    private RectTransform myRectTrans;
    private Image image;
  
    void Start()
    {
        myRectTrans = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    void Update()
    {
        if(test)
        {
            myPos = myRectTrans.anchoredPosition;
            StartCoroutine(FuncFloat());
            test = false;
        }
    }

    IEnumerator FuncFloat()
    {
        Debug.Log("<color=green>FuncFloat: </color> Iniciei");
        
        float timer = 1f;
        do
        {
            timer -= Time.deltaTime;
            
            myPos.y = Mathf.Lerp(15 + myPos.y, myPos.y, timer);

            //myPos.y = myPos.y + 2;

            myRectTrans.anchoredPosition = myPos;
            //transform.localPosition = new Vector3(Mathf.Lerp(1.1f, timer * 10, 1), transform.localPosition.y, transform.localPosition.z);
            image.enabled = true;
            yield return new WaitForEndOfFrame();//colocar a coroutine para "dormir"
            if(timer <= 0.001)
            {
                Debug.Log("<color=green>FuncFloat: </color> Terminei!");
                image.enabled = false;
            }
        } 
        while(timer > 0f);
    }
}
