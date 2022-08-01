using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData instance;
    public static GameData Instance { get { return instance; } }

    [HideInInspector]
    public GameInformation gameData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameData = new GameInformation();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
