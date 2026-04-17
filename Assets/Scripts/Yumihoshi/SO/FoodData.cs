// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 04:53
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Yumihoshi.MVC.Models;

namespace Yumihoshi.SO
{
    [CreateAssetMenu(fileName = "食材", menuName = "食材/新建食材配置", order = 0)]
    public class FoodData : ScriptableObject
    {
        [Header("配置")]
        [LabelText("食材名称")] public string foodName;
        [LabelText("食材类型")] public FoodType foodType;
        [LabelText("食材图片")] public Sprite foodSprite;

        [Header("数值")] [LabelText("肉类好评")] public List<int> goodCmt;
        [LabelText("蔬菜增加时间")] public List<float> timeAdded;
        [LabelText("面食类其他增加倍率")] public float otherAddRate;
    }
}
