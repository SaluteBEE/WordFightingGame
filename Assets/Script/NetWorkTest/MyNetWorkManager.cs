using kcp2k;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        
        UIManager.Instance.SetStatus("Connected to server.");

        if (UIManager.Instance.StartPanel != null)
        {
            UIManager.Instance.StartPanel.SetActive(false);
        }
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();
        UIManager.Instance.SetStatus("Disconnected from server.");

        if (UIManager.Instance.StartPanel != null)
        {
            UIManager.Instance.StartPanel.SetActive(true);
        }
    }
    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log($"[KCP] Server started on port {GetComponent<KcpTransport>().Port}");
    }
}
