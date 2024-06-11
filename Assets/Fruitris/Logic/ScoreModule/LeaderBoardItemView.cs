using TMPro;
using UnityEngine;

public class LeaderBoardItemView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _playerNameAndScore;

    public void Init(PlayerData player, int place)
    {
        _playerNameAndScore.text = $"{place}. {player.Nickname}:{player.MaxScore}";
    }
}
