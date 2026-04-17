// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 05:38
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using Yumihoshi.MVC.Events;
using Yumihoshi.MVC.Models;

namespace Yumihoshi.MVC.Cmds
{
    public class RemoveFoodCmd : AbstractCommand
    {
        private readonly int _index;

        public RemoveFoodCmd(int index)
        {
            _index = index;
        }

        protected override void OnExecute()
        {
            var model = this.GetModel<FoodModel>();
            if (_index < 0 || _index >= model.FoodOnTable.Count)
            {
                Debug.LogWarning("索引超出范围，无法移除食材");
                return;
            }

            model.FoodOnTable.RemoveAt(_index);
            Debug.Log("移除食材成功");
            this.SendEvent(new FoodChangedEvent
                { newFoodList = model.FoodOnTable, isAdded = false });
        }
    }
}
