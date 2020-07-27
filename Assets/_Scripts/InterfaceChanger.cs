using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro; 

public class InterfaceChanger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp1;
    [SerializeField]
    private TextMeshProUGUI tmp2;
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
        bool verticalOrientation = rectTransform.rect.width < rectTransform.rect.height ? true : false;
        portrait.SetActive(verticalOrientation);
        landscape.SetActive(!verticalOrientation);
    }
    void OnRectTransformDimensionsChange()
    {
        EqualPoints();
        SetOrientation();
    }

    void EqualPoints()
    {
        if (int.Parse(tmp1.text) > int.Parse(tmp2.text))
        tmp2.text = tmp1.text;
        else
        tmp1.text = tmp2.text;
    }
}