using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class GameInformation : GameData
{
    public string displayName;
    public List<UserInformation> players;

    public string gameID;
    public int seed;

    public int size;
    public int colors;
    public int turns;
}