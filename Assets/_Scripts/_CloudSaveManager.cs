using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using Firebase.Analytics;

public class _CloudSaveManager : MonoBehaviour
{
    private DatabaseReference reference;
    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( continuationAction: task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
        
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://dogvillage-66857.firebaseio.com/");
        // reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    

    public void PostMessage(_Message message, Action callback, Action<AggregateException> fallback)
    {
        reference.Child("messages").Push().SetValueAsync(message).ContinueWith(task => 
        {
            if(task.IsCanceled || task.IsFaulted) 
            {
                fallback(task.Exception);
            }
            else
            {
                callback();
            }
        });
    }

    public void ListenForMessages(Action<_Message> callback, Action<AggregateException> fallback)
    {
        void CurrentListener(object o, ChildChangedEventArgs args)
        {
            if(args.DatabaseError != null)
            {
                fallback(new AggregateException(new Exception(args.DatabaseError.Message)));
                Debug.LogError(args.DatabaseError.Message);
                return;
            }
            else
            {
                callback(args.Snapshot.Value as _Message);
            }
            
        }
        reference.Child("messages").ChildAdded += CurrentListener;
    }

    public void StopListener()
    {

    }
}
