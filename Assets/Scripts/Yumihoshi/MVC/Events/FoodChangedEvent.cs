// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 05:01
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Yumihoshi.SO;

namespace Yumihoshi.MVC.Events
{
    public struct FoodChangedEvent
    {
        public List<FoodData> newFoodList;
        public bool isAdded;
    }
}
