using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Nickname;
    public int MaxScore;

    public void SavePlayer()
    {
        SaveHandler.SavePlayerData(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveHandler.LoadPlayerData();

        Nickname = data.Nickname;
        MaxScore = data.MaxScore;
    }
}
