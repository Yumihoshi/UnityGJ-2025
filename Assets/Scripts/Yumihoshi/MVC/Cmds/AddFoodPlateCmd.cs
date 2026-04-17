// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 04:27
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using Yumihoshi.MVC.Events;
using Yumihoshi.MVC.Models;

namespace Yumihoshi.MVC.Cmds
{
    public class AddFoodPlateCmd : AbstractCommand
    {
        private readonly int _amount;

        public AddFoodPlateCmd(int amount = 1)
        {
            _amount = amount;
        }

        protected override void OnExecute()
        {
            var model = this.GetModel<FoodModel>();
            if (model.CurFoodPlateCount >= 5)
            {
                Debug.LogWarning("食材盘子数量已达上限");
                return;
            }

            model.CurFoodPlateCount += _amount;
            Debug.Log("当前食材盘子数量：" + model.CurFoodPlateCount);
            this.SendEvent(new FoodPlateCountChangedEvent
                { newCount = model.CurFoodPlateCount });
        }
    }
}
