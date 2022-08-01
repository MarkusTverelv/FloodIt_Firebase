using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Auth;
using UnityEngine;
using TMPro;

public class FirebaseTest : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;

    FirebaseAuth auth;

    void Start()
    {
        //Setup for talking to firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            //Log if we get any errors from the opperation
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            //the database
            auth = FirebaseAuth.DefaultInstance;
        });
    }
}
