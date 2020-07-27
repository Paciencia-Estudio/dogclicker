using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseTestRealtimeDatabse : MonoBehaviour
{
    DatabaseReference reference;
    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://dogvillage-66857.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnviarParaRTD(int pontos)
    {
        reference.SetValueAsync(pontos);
    }
}
