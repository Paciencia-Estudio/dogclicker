using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase.Analytics;

public class FirebaseTestRealtimeDatabse : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( continuationAction: task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
        // Set this before calling into the realtime database.
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://dogvillage-66857.firebaseio.com/");

        // Get the root reference location of the database.
        //DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnviarParaRTD(int pontos)
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("Leaders").SetValueAsync(pontos);
    }

    public void PegarRTD()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("Leaders")
        .GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted) {
            // Handle the error...
            Debug.Log("Deu erro aqui hein");
        }
        else if (task.IsCompleted) {
            DataSnapshot snapshot = task.Result;
            Debug.Log("É isso que resultou: " + snapshot);
        }
    });
    }
}
