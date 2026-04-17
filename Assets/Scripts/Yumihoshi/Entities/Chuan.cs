// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 15:00
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using UnityEngine;
using Yumihoshi.SO;

namespace Yumihoshi.Entities
{
    public class Chuan : MonoBehaviour
    {
        public List<ChuanSlot> chuanSlots;

        /// <summary>
        /// 获取当前串的食材
        /// </summary>
        /// <returns></returns>
        public List<FoodData> GetChuanFood()
        {
            var data = new List<FoodData>();
            for (int i = 0; i < chuanSlots.Count; i++)
                data.Add(chuanSlots[i].Food);

            return data;
        }

        /// <summary>
        /// 清除串串上的食材
        /// </summary>
        public void ClearChuanFood()
        {
            foreach (ChuanSlot chuanSlot in chuanSlots) chuanSlot.ClearFood();
        }
    }
}
