using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class UserStatsManager : MonoBehaviour
{
    public GameObject userStatsHolder;
    public GameObject userStats;
    public List<Transform> transforms = new List<Transform>();

    FirebaseDatabase db;

    private void Start()
    {
        db = FirebaseDatabase.DefaultInstance;
        StartCoroutine(LoadUserStats());
    }

    private IEnumerator LoadUserStats()
    {
        yield return new WaitForSeconds(.5f);

        var task = db.RootReference.Child("games").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                DataSnapshot snapshot = task.Result;

                int index = 0;
                foreach (DataSnapshot item in snapshot.Children.Reverse())
                {
                    if (index < transforms.Count)
                    {
                        string name = item.Child("displayName").Value.ToString();
                        int playedGames = int.Parse(item.Child("size").Value.ToString());

                        GameObject newUserStats = Instantiate(userStats, transforms[index]);
                        newUserStats.GetComponent<PlayerStats>().DisplayStats(name, playedGames);
                    }

                    index++;
                }
            }
        });
    }
}