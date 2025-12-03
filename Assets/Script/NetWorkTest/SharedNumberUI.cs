using TMPro;
using UnityEngine;

public class SharedNumberUI : MonoBehaviour
{
    public TMP_Text sharedNumberText;
    public TMP_InputField inputField;

    private PlayerInput localPlayer;

    // 由 PlayerInput 调用，把自己传进来
    public void RegisterPlayer(PlayerInput player)
    {
        localPlayer = player;
    }

    // 按钮点击调用这个方法
    public void OnClickSubmitNumber()
    {
        if (localPlayer == null)
        {
            Debug.LogWarning("本地玩家尚未生成，无法提交数字！");
            return;
        }

        //localPlayer.SubmitNumberFromUI(inputField.text);
    }

    public void UpdateNumber(int number)
    {
        sharedNumberText.text = "共享数字：" + number;
    }
}
