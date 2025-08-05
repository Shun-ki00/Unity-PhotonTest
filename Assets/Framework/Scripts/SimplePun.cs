using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;

public class SimplePun : MonoBehaviourPunCallbacks
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        
    }

    private void OnGUI()
    {
        // ログインの状態を画面上に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    // ルームに入室前に呼び出される
    public override void OnConnectedToMaster()
    {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        if(PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default))
        {
            // GameObject wall = PhotonNetwork.InstantiateRoomObject("Walls", Vector3.zero, Quaternion.identity);
        }
    }

    // ルームに入室後に呼び出される
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Walls", Vector3.zero, Quaternion.identity);
        }

        // キャラクターの作成
        GameObject player = PhotonNetwork.Instantiate("Player",new Vector3(0.0f,3.2f,0.0f) , Quaternion.identity);

        // 自分だけが操作できるようにスクリプトを有効にする
        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        playerControl.enabled = true;
    }


}
