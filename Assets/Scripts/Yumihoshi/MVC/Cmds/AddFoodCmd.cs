// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 04:57
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using Yumihoshi.MVC.Events;
using Yumihoshi.MVC.Models;
using Yumihoshi.SO;

namespace Yumihoshi.MVC.Cmds
{
    public class AddFoodCmd : AbstractCommand
    {
        private readonly FoodData _foodData;

        public AddFoodCmd(FoodData newFood)
        {
            _foodData = newFood;
        }

        protected override void OnExecute()
        {
            var model = this.GetModel<FoodModel>();
            if (model.CurFoodCount >= model.CurFoodPlateCount)
            {
                Debug.LogWarning("食材数量已达盘子上限，无法添加更多食材");
                return;
            }

            model.FoodOnTable.Insert(0, _foodData);
            this.SendEvent(new FoodChangedEvent
                { newFoodList = model.FoodOnTable, isAdded = true });
        }
    }
}
