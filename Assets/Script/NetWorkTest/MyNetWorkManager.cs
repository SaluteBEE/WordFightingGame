using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    // 客户端成功连接到服务器时会自动调用
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("客户端成功连接到服务器！！！");
    }
}