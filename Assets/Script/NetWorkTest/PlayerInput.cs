using Mirror;
using UnityEngine;

public class PlayerInput : NetworkBehaviour
{
    // 每帧检测输入（只在本地玩家运行）
    void Update()
    {
        if (!isLocalPlayer) return;   // 保证只有本地玩家检测键盘

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // 本地玩家按了小键盘上键 → 发送给服务器
            CmdReportKeyPress("UP");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 本地玩家按了小键盘下键
            CmdReportKeyPress("DOWN");
        }

        
    }

    // 客户端 → 服务器
    [Command]
    void CmdReportKeyPress(string direction)
    {
        Debug.Log($"服务器接收到按键: {direction}, 来自玩家 {connectionToClient.connectionId}");

        // 服务器广播给所有客户端（包括发送者）
        RpcBroadcastKeyPress(direction, connectionToClient.connectionId);
    }

    [Command]
    public void CmdReportWordWave(string word)
    {
        RpcBroadcastWordWave(word,connectionToClient.connectionId);
    }

    // 服务器 → 所有客户端
    [ClientRpc]
    void RpcBroadcastKeyPress(string direction, int playerId)
    {
        if(direction == "UP")
        {
            
            MovementManager.Instance.MoveUp(playerId);
            
        }
        if(direction == "DOWN")
        {
            
            MovementManager.Instance.MoveDown(playerId);
            
        }
        
        Debug.Log($"客户端收到广播: 玩家 {playerId} 按了 {direction}");
    }

    // 服务器 → 所有客户端
    [ClientRpc]
    void RpcBroadcastWordWave(string word, int playerId)
    {
        WaveGernerator.Instance.GenerateWave(word,playerId);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Debug.Log("本地玩家已生成：" + netId);

        TypingManager.Instance.RegisterPlayer(this);
    }
}
