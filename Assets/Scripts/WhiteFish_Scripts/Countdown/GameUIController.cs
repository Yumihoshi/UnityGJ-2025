using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [Header("倒计时引用")]
    public CountdownTimer countdownTimer;

    [Header("其他UI元素")]
    public GameObject timeUpPanel;//时间结束提示面板

    private void Start()
    {
        //确保时间结束面板初始隐藏
        if (timeUpPanel != null)
            timeUpPanel.SetActive(false);

        //注册倒计时结束事件
        if (countdownTimer != null)
        {
            countdownTimer.onCountdownFinished.AddListener(OnTimeUp);
        }
    }

    //时间结束时的处理
    private void OnTimeUp()
    {
        Debug.Log("时间到了！");

        //显示时间结束提示
        if (timeUpPanel != null)
            timeUpPanel.SetActive(true);

        //这里可以添加其他逻辑，如暂停游戏、显示分数等
    }

    //重新开始倒计时（如果需要）
    public void RestartCountdown()
    {
        if (countdownTimer != null)
        {
            countdownTimer.ResetCountdown();
            countdownTimer.StartCountdown();

            // 隐藏时间结束提示
            if (timeUpPanel != null)
                timeUpPanel.SetActive(false);
        }
    }
}