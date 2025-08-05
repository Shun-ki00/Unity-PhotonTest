using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerCallBack : MonoBehaviourPunCallbacks
{
    // 他のプレイヤーがルームへ参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName}が参加しました");
    }

    // 他のプレイヤーがルームから退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"{otherPlayer.NickName}が退出しました");
    }

}
