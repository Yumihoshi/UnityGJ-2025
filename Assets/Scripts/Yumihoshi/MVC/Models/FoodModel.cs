// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 04:23
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using Yumihoshi.SO;

namespace Yumihoshi.MVC.Models
{
    public class FoodModel : AbstractModel
    {
        /// <summary>
        /// 当前食材盘子数量
        /// </summary>
        public int CurFoodPlateCount { get; set; } = 3;

        /// <summary>
        /// 当前食材数量
        /// </summary>
        public int CurFoodCount { get; set; }

        public List<FoodData> FoodOnTable { get; private set; } = new();
        public List<FoodData> FoodConfig { get; set; } = new();

        protected override void OnInit()
        {
            FoodConfig = ES3.Load("FoodConfig", new List<FoodData>());
        }
    }

    public enum FoodType
    {
        Meat,
        Vegetable,
        BeanProduct,
        Pasta
    }
}
