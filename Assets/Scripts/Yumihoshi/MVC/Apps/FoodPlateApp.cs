// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 04:22
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.MVC.Models;

namespace Yumihoshi.MVC.Apps
{
    public class FoodPlateApp : Architecture<FoodPlateApp>
    {
        protected override void Init()
        {
            RegisterModel(new FoodModel());
        }
    }
}
