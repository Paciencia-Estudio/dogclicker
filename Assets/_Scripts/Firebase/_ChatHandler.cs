using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;
public class _ChatHandler : MonoBehaviour
{
    public _CloudSaveManager cloudSaveManager;
    public TMP_InputField senderIF;
    public TMP_InputField textIF;

    public GameObject messagePrefab;
    public GameObject messagesContainer;

    private void Start()
    {
        cloudSaveManager.ListenForMessages(InstantiateMessage, Debug.Log);
    }
    public void SendMessage()
    {
        cloudSaveManager.PostMessage(new _Message(senderIF.text, textIF.text), () => Debug.Log( message: "Mensagem Enviada."), Debug.Log);
    }

    private void InstantiateMessage(_Message message)
    {
        var newMessage = Instantiate(messagePrefab, transform.position, Quaternion.identity);
        newMessage.transform.SetParent(messagesContainer.transform, false);
        newMessage.GetComponent<TextMeshProUGUI>().text = $"{message.sender}; {message.text}";
    }
}
