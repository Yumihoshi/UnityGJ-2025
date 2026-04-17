// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 17:37
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Yumihoshi.Managers;

namespace Yumihoshi.UI
{
    public class SandClock : MonoBehaviour
    {
        [Header("组件")] [LabelText("沙漏图片")] [SerializeField]
        private List<Image> sandClockImgs;

        private void Start()
        {
            GameManager.Instance.RestTime
                .RegisterWithInitValue(DisplaySandClockByTime)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void DisplaySandClockByTime(float time)
        {
            for (var i = 0; i < sandClockImgs.Count; i++)
                sandClockImgs[i].gameObject.SetActive(i < (int)(time / 5));
        }
    }
}
