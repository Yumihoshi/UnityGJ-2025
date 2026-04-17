using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    [Header("倒计时设置")]
    public float totalTime = 180f;//总倒计时时间（秒）
    public bool startOnEnable = true;//是否在启用时自动开始

    [Header("UI引用")]
    public Text countdownText;//显示倒计时的文本
    public Slider progressSlider;//可选：进度条

    [Header("完成事件")]
    public UnityEngine.Events.UnityEvent onCountdownFinished;//倒计时结束时的回调

    private float currentTime;
    private bool isCounting = false;

    private void OnEnable()
    {
        if (startOnEnable)
        {
            StartCountdown();
        }
    }

    private void OnDisable()
    {
        StopCountdown();
    }

    // 开始倒计时
    public void StartCountdown()
    {
        currentTime = totalTime;
        isCounting = true;
        StartCoroutine(CountdownRoutine());
    }

    // 停止倒计时
    public void StopCountdown()
    {
        isCounting = false;
        StopAllCoroutines();
    }

    // 重置倒计时
    public void ResetCountdown()
    {
        currentTime = totalTime;
        UpdateUI();
    }

    // 倒计时协程
    private IEnumerator CountdownRoutine()
    {
        while (isCounting && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();

            if (currentTime <= 0)
            {
                currentTime = 0;
                isCounting = false;
                onCountdownFinished.Invoke();
            }

            yield return null;
        }
    }

    // 更新UI显示
    private void UpdateUI()
    {
        if (countdownText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (progressSlider != null)
        {
            progressSlider.value = currentTime / totalTime;
        }
    }

    // 获取剩余时间
    public float GetRemainingTime()
    {
        return currentTime;
    }

    // 获取是否正在倒计时
    public bool IsCounting()
    {
        return isCounting;
    }
}