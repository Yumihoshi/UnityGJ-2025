using DG.Tweening.Core.Easing;
using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using pkq;
using NodeCanvas.DialogueTrees.UI.Examples;
using DG.Tweening;
public class DialogueManager : MonoSingleton<DialogueManager>
{
    public Blackboard Global_bb;
    public Canvas dialogueCanvas;
    private List<GraphicRaycaster> otherRaycasters = new List<GraphicRaycaster>();

    public Sprite Init_sr;

    [Header("BubbleSprite")]
    public Sprite Bubble_sr;


    [Header("DialogueObject")]
    public Image SubtitlesImage;
    public Vector2 DialogueUItargetPosition;

    public RectTransform SpeechRect;
    public Vector2 SpeechSize;

    public bool AutoPlay;

    private Vector2 OriginalPos;
    private Vector2 OriginalSize;

    public DialogueUGUI dialogueUI;

    protected override void OnStart()
    {
        DialogueAutoPlay(AutoPlay);
        OriginalPos = dialogueUI.subtitlesGroup.anchoredPosition;
        OriginalSize=SpeechRect.rect.size;
    }

    //private void Update()
    //{
    //    if(Input.GetKey(KeyCode.R))
    //    {
    //        Start_Dialogue("DialogueStart", false);
    //        ChangeDialogueState();
    //    }
            
    //    if (Input.GetKey(KeyCode.S))
    //        ReturnDialogueState();
 
    //}



    //DialogueTreeController dialogue = DialogueSystem.Instance.GetDialogueTreeController("YourObjectName");
    public DialogueTreeController GetDialogueTreeController(string objectName)
    {
        GameObject targetObject = GameObject.Find(objectName);


        if (targetObject != null)
        {

            DialogueTreeController controller = targetObject.GetComponent<DialogueTreeController>();

            if (controller != null)
            {
                return controller;
            }
            else
            {
                Debug.LogWarning($"No DialogueTreeController found on the object: {objectName}");
            }
            if (controller == null)
            {
                Debug.Log(targetObject.name + " Controller is null");
            }
        }
        else
        {
            Debug.LogWarning($"No GameObject found with the name: {objectName}");
        }

        return null;
    }


    #region Dialogue Func Overloading

    //StartDialogue Func Overloading
    //public void Start_Dialogue(DialogueTreeController dialogue)
    //{
    //    if (dialogue != null)
    //    {
    //        dialogue.StartDialogue();
    //    }
    //    else
    //    {
    //        Debug.LogWarning($"Can't find this obj: {dialogue}");
    //    }
    //}

    //callback
    public void Start_Dialogue(DialogueTreeController dialogue, bool raycast_enable, Action<bool> callback = null)
    {
        //DialogueTreeController dialogue=GetComponent<DialogueTreeController>

        if (callback == null)
        {
            callback = Dialogue_CallBack();
        }
        if (!raycast_enable)
            Dialogue_Enable();
        if (dialogue != null)
        {
            dialogue.StartDialogue(callback);
        }
        else
        {
            Debug.LogWarning($"Can't find this obj: {dialogue}");
        }
    }

    

    //
    //public void Start_Dialogue(string dialogueName)
    //{
    //    Dialogue_Enable();
    //    //dialogueName = dialogueName + "_";
    //    DialogueTreeController dialogue = GetDialogueTreeController(dialogueName);
    //    if (dialogue != null)
    //    {
    //        dialogue.StartDialogue();
    //    }
    //    else
    //    {
    //        Debug.LogWarning($"Can't find this obj: {dialogue}");
    //    }
    //}


    //callback
    public void Start_Dialogue(string dialogueName, bool raycast_enable,Action<bool> callback = null)
    {

        if (callback == null)
        {
            callback = Dialogue_CallBack();
        }

        DialogueTreeController dialogue = GetDialogueTreeController(dialogueName);
        if (!raycast_enable) 
            Dialogue_Enable();
        if (dialogue != null)
        {
            dialogue.StartDialogue(callback);
        }
        else
        {
            Debug.LogWarning($"Can't find this obj: {dialogue}");
        }
    }

    #endregion

    #region BlackBoard


    //change global black bool value
    public void ModifieValue(string str, bool value)
    {
        Global_bb.SetVariableValue(str, value);

    }

    //Get value in global black
    public bool GetValue(string str)
    {
        var variable = Global_bb.GetVariable(str);

        if (variable is Variable<bool> boolVariable)
        {
            return boolVariable.value;
        }

        Debug.LogWarning($"Variable '{str}' is not of type bool.");
        return false; 
    }

    // Get int in global black ֵ
    public int GetGlobalIntValue(string variableName)
    {
       
        var variable = Global_bb.GetVariable(variableName);

        
        if (variable is Variable<int> intVariable)
        {
            return intVariable.value;
        }

        
        Debug.LogWarning($"Variable '{variableName}' is not of type int or does not exist.");
        return 0;
    }

    #endregion


    #region Graphic Raycater enable
    // when dialogue show
    public void ShowDialogue()
    {
        Physics2DRaycaster pr = Camera.main.GetComponent<Physics2DRaycaster>();
        if (pr != null)
        {
            pr.enabled = false;
        }
        //GameManager.Instance.canClick = false;

        //disable other raycaster
        GraphicRaycaster dialogueRaycaster = dialogueCanvas.GetComponent<GraphicRaycaster>();
        if (dialogueRaycaster != null)
        {
            dialogueRaycaster.enabled = true;
        }

        
        GraphicRaycaster[] raycasters = FindObjectsOfType<GraphicRaycaster>();
        foreach (var raycaster in raycasters)
        {
            if (raycaster.gameObject != dialogueCanvas.gameObject)
            {
                raycaster.enabled = false;
                otherRaycasters.Add(raycaster);
            }
        }
    }

    //when dialogue hide
    public void HideDialogue()
    {


        Physics2DRaycaster pr = Camera.main.GetComponent<Physics2DRaycaster>();
        if (pr != null)
        {
            pr.enabled = true;
        }

        //GameManager.Instance.canClick = true;

        
        GraphicRaycaster dialogueRaycaster = dialogueCanvas.GetComponent<GraphicRaycaster>();
        if (dialogueRaycaster != null)
        {
            dialogueRaycaster.enabled = false;
        }

        
        foreach (var raycaster in otherRaycasters)
        {
            if (raycaster != null)
            {
                raycaster.enabled = true;
            }
        }

        
        otherRaycasters.Clear();
    }

    
    public void Dialogue_Enable()
    {

        ShowDialogue();
    }

    #endregion

    //callback Example
    public Action<bool> Dialogue_CallBack()
    {
        return (success) =>
        {
            if (success)
            {
               
                HideDialogue();
            }
            else
            {
                
                HideDialogue();
            }
        };
    }


    public void ChangeDialogueState()
    {
        SubtitlesImage.sprite = Bubble_sr;
        SubtitlesImage.SetNativeSize();
        SetDialoguePosition();
        DialogueAutoPlay(true);
        SetUIAfterDialogueEnd();
    }

    

    public void SetDialoguePosition()
    {
        
        dialogueUI.subtitlesGroup.anchoredPosition = DialogueUItargetPosition;
        dialogueUI.SetOriginalPosition(DialogueUItargetPosition);
        SpeechRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SpeechSize.y);
        SpeechRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, SpeechSize.x);
        
    }

    public void SetUIAfterDialogueEnd(bool value=true)
    {

        dialogueUI.keepUIAfterDialogueEnd = value;
    }

    public void DialogueAutoPlay(bool auto)
    {
        AutoPlay = auto;
        dialogueUI.waitForInput=!AutoPlay;
    }

    public void ReturnDialogueState()
    {
        SubtitlesImage.sprite = Init_sr;
        SubtitlesImage.SetNativeSize();
        dialogueUI.subtitlesGroup.anchoredPosition = OriginalPos;
        dialogueUI.SetOriginalPosition(OriginalPos);
        SpeechRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, OriginalSize.y);
        SpeechRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, OriginalSize.x);
        DialogueAutoPlay(false);
        SetUIAfterDialogueEnd(false);
    }

    

}
