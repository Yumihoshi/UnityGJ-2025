// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 04:26
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using Yumihoshi.Entities;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Apps;
using Yumihoshi.MVC.Events;
using Yumihoshi.MVC.Models;

namespace Yumihoshi.MVC.VCs
{
    public class FoodPlateVc : MonoBehaviour, IController
    {
        [Header("组件引用")] [LabelText("食材面板预制体列表")] [SerializeField]
        private List<FoodPlate> foodPanelPrefabs;

        public FoodModel Model { get; private set; }

        private void Awake()
        {
            Model = this.GetModel<FoodModel>();
            // 注册事件
            this.RegisterEvent<FoodPlateCountChangedEvent>(
                    HandleFoodPlateCountChangedEvent)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<FoodChangedEvent>(HandleFoodChangedEvent)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Start()
        {
            DisplayFoodPanel(Model.CurFoodPlateCount);
            HandleFoodChangedEvent(new FoodChangedEvent { newFoodList = null });
        }

        public IArchitecture GetArchitecture()
        {
            return FoodPlateApp.Interface;
        }

        private void HandleFoodPlateCountChangedEvent(
            FoodPlateCountChangedEvent evt)
        {
            DisplayFoodPanel(evt.newCount);
        }

        private void HandleFoodChangedEvent(FoodChangedEvent evt)
        {
            // 处理食材变化的逻辑
            for (int i = 0; i < Model.FoodOnTable.Count; i++)
            {
                foodPanelPrefabs[i]
                    .SetFoodSprite(Model.FoodOnTable[i].foodSprite);
                foodPanelPrefabs[i]
                    .SetTimeText(
                        FoodManager.Instance.foodTimeCost[i].ToString());
                if (evt.isAdded)
                    foodPanelPrefabs[i].SetFoodData(evt.newFoodList[0]);
            }

            for (int i = Model.FoodOnTable.Count;
                 i < foodPanelPrefabs.Count;
                 i++) foodPanelPrefabs[i].HideFood();
        }

        /// <summary>
        /// 显示对应数量的食材盘
        /// </summary>
        /// <param name="amount">要显示的食材盘数量</param>
        public void DisplayFoodPanel(int amount)
        {
            int count = Mathf.Clamp(amount, 0, foodPanelPrefabs.Count);
            for (int i = 0; i < foodPanelPrefabs.Count; i++)
                foodPanelPrefabs[i].gameObject.SetActive(i < count);
        }
    }
}
