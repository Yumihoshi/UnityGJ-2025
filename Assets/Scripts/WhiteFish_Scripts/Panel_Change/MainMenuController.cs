using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("��ť����")]
    public Button startButton;
    public Button settingsButton;
    public Button exitButton;

    private Vector3 ButtonOriginalScale;
    //��ť��ԭ����С

    private void Start()
    {
        ButtonOriginalScale = startButton.transform.localScale;

        startButton.onClick.AddListener(OnStartButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    public void OnStartButtonClick()
    {
        //Debug.Log("��ʼ��Ϸ��ť�����");
        startButton.transform.localScale = ButtonOriginalScale;
    }

    public void OnSettingsButtonClick()
    {
        //Debug.Log("���ð�ť�����");
        settingsButton.transform.localScale = ButtonOriginalScale;
    }

    public void OnExitButtonClick()
    {
        //Debug.Log("�˳���Ϸ��ť�����");
        exitButton.transform.localScale = ButtonOriginalScale;
        QuitGame();
    }

    public void OnButtonEnter(Button button)
    {
        button.transform.localScale = ButtonOriginalScale * 1.2f;
    }

    public void OnButtonExit(Button button)
    {
        button.transform.localScale = ButtonOriginalScale;
    }

    public void QuitGame()
    {
        Application.Quit();

        //��Unity�༭�����˳�����ģʽ
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
