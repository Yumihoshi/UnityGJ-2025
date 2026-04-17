// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 04:04
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using HoshiVerseFramework.Base;
using Sirenix.OdinInspector;
using UnityEngine;
using Yumihoshi.MVC.VCs;

namespace Yumihoshi.Managers
{
    public class FoodManager : Singleton<FoodManager>
    {
        public FoodPlateVc FoodPlate { get; private set; }

        [Header("配置")] [LabelText("从左到右食材时间消耗列表")]
        public List<int> foodTimeCost;

        public int DraggingFoodIndex { get; set; }

        protected override void Awake()
        {
            base.Awake();
            FoodPlate = GetComponent<FoodPlateVc>();
        }
    }
}
