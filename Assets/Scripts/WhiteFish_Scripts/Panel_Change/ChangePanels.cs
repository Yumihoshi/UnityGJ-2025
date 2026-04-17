using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePanels : MonoBehaviour
{
    public GameObject ButtonPanel;
    public GameObject StrengthPanel;
    
    void Start()
    {
        
    }

    public void ButtonPanel_Method()
    {
        ButtonPanel.SetActive(!ButtonPanel.activeSelf);
        StrengthPanel.SetActive(false);
    }

    public void GamePanel_Method()
    {
        ActionKit.ScreenTransition.FadeInOut()
            .OnInFinish(() => SceneManager.LoadScene("Chuanchuan")).Start(this);
    }

    public void Return_MainPanel()
    {
        if (SceneManager.GetActiveScene().name == "Panels")
        {
            ButtonPanel.SetActive(true);
            StrengthPanel.SetActive(false);
        }
        else
        {
            
        }
    }

    public void StrengthPanel_Method()
    {
        StrengthPanel.SetActive(!StrengthPanel.activeSelf);
        ButtonPanel.SetActive(false);
    }

    public void SettlePanel_Method()
    {
        ButtonPanel.SetActive(false);
        StrengthPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
