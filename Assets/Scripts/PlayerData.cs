using Firebase.Auth;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static UserInformation data;
	static string userPath;

	private void Start()
	{
		FindObjectOfType<FirebaseLogin>().OnSignIn += OnSignIn;
	}

	void OnSignIn()
	{
		userPath = "users/" + FirebaseAuth.DefaultInstance.CurrentUser.UserId;
		SaveManager.Instance.LoadData(userPath, OnLoadData);
	}

	void OnLoadData(string json)
	{
		if (json != null)
		{
			data = JsonUtility.FromJson<UserInformation>(json);
		}
		else
		{
			data = new UserInformation();

			data.myName = string.Empty;
			data.tries = 0;
			data.activeGames = null;

			SaveData();
		}

		FindObjectOfType<FirebaseLogin>()?.PlayerDataLoaded();
	}

	public static void SaveData()
	{
		SaveManager.Instance.SaveData(userPath, JsonUtility.ToJson(data));
	}
}