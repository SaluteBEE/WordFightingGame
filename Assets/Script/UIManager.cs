using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;
using System.Net.Sockets;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Components")]
    public Button hostButton;
    public Button joinButton;
    public Button localIPButton;
    public Button restartClientButton;   // NEW
    public Button quitButton;            // NEW

    public TMP_InputField ipInputField;
    public TMP_InputField ipShowField;
    public TMP_Text statusText;

    public GameObject StartPanel;

    private MyNetworkManager networkManager;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        networkManager = NetworkManager.singleton as MyNetworkManager;

        if (networkManager == null)
        {
            Debug.LogError("NetworkManager in this scene is not MyNetworkManager!");
        }

        hostButton.onClick.AddListener(OnClickHost);
        joinButton.onClick.AddListener(OnClickJoin);
        localIPButton.onClick.AddListener(OnClickLocalIP);

        // NEW BINDINGS
        restartClientButton.onClick.AddListener(OnClickRestartClient);
        quitButton.onClick.AddListener(OnClickQuit);

        SetStatus("Ready");
    }

    void OnClickHost()
    {
        SetStatus("Starting host...");
        networkManager.StartHost();
        SetStatus("Host started. Waiting for clients...");
    }

    void OnClickJoin()
    {
        string ip = ipInputField.text.Trim();

        if (string.IsNullOrEmpty(ip))
        {
            SetStatus("Please enter a valid IP address.");
            return;
        }

        SetStatus($"Connecting to: {ip} ...");

        networkManager.networkAddress = ip;
        networkManager.StartClient();
    }

    void OnClickLocalIP()
    {
        string localIP = GetLocalIPAddress();
        ipShowField.text = localIP;
        SetStatus($"Local IP filled: {localIP}");
    }

    // ============================
    // NEW: Restart Client
    // ============================

    void OnClickRestartClient()
    {
        SetStatus("Restarting client...");

        // Stop client if connected or connecting
        if (NetworkClient.isConnected || NetworkClient.active)
        {
            networkManager.StopClient();
        }

        // Restart client using same IP
        string ip = ipInputField.text.Trim();
        if (!string.IsNullOrEmpty(ip))
        {
            networkManager.networkAddress = ip;
        }

        networkManager.StartClient();
        SetStatus("Client restarted.");
    }

    // ============================
    // NEW: Quit Game
    // ============================

    void OnClickQuit()
    {
        SetStatus("Quitting...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // ============================

    string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "127.0.0.1"; // fallback
    }

    public void SetStatus(string msg)
    {
        statusText.text = msg;
    }
}
