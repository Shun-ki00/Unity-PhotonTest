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
        // ���O�C���̏�Ԃ���ʏ�ɏo��
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    // ���[���ɓ����O�ɌĂяo�����
    public override void OnConnectedToMaster()
    {
        // "room"�Ƃ������O�̃��[���ɎQ������i���[����������΍쐬���Ă���Q������j
        if(PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default))
        {
            // GameObject wall = PhotonNetwork.InstantiateRoomObject("Walls", Vector3.zero, Quaternion.identity);
        }
    }

    // ���[���ɓ�����ɌĂяo�����
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Walls", Vector3.zero, Quaternion.identity);
        }

        // �L�����N�^�[�̍쐬
        GameObject player = PhotonNetwork.Instantiate("Player",new Vector3(0.0f,3.2f,0.0f) , Quaternion.identity);

        // ��������������ł���悤�ɃX�N���v�g��L���ɂ���
        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        playerControl.enabled = true;
    }


}
