using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
 
public class InterfaceChangerTwo : MonoBehaviour
{
    RectTransform rectTransform;
    GameObject landscape;
    GameObject portrait;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        landscape = transform.Find("Landscape").gameObject;
        portrait = transform.Find("Portrait").gameObject;
        SetOrientation();
    }
    void SetOrientation()
    {
        if(rectTransform == null) return;
        bool verticalOrientation = rectTransform.rect.width > rectTransform.rect.height ? false : true;
        portrait.SetActive(verticalOrientation);
        landscape.SetActive(!verticalOrientation);
    }
    void OnRectTransformDimensionsChange()
    {
        SetOrientation();
    }
}