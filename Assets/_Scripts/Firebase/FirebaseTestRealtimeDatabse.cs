using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase.Analytics;

public class FirebaseTestRealtimeDatabse : MonoBehaviour
{
    FirebaseApp app;
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

        // FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( continuationAction: task =>
        // {
        //     FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        // });
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
