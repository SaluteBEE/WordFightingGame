using Mirror;
using UnityEngine;

public class JoinServerButton : MonoBehaviour
{
    // 在 Inspector 的 Button 的 OnClick 中调用这个函数
    public void OnClickJoin()
    {
        // 拿到当前的 NetworkManager（单例）
        var nm = NetworkManager.singleton;
        if (nm == null)
        {
            Debug.LogError("没有找到 NetworkManager！");
            return;
        }

        // 服务器地址：先用本机测试，就用 localhost
        nm.networkAddress = "localhost";

        Debug.Log("尝试连接到服务器 " + nm.networkAddress + " ...");
        nm.StartClient();   // 启动客户端去连服务器
    }
}
