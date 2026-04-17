// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 05:25
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Yumihoshi.SO;

namespace Yumihoshi.Managers
{
    public class ResManager : HoshiVerseFramework.Base.Singleton<ResManager>
    {
        private readonly ResLoader _resLoader = ResLoader.Allocate();
        public FoodData TudouData { get; private set; }
        public FoodData DouPiData { get; private set; }
        public FoodData JiaoZiData { get; private set; }
        public FoodData JiRouData { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            ResKit.Init();
            TudouData = _resLoader.LoadSync<FoodData>("土豆配置");
            DouPiData = _resLoader.LoadSync<FoodData>("豆皮配置");
            JiaoZiData = _resLoader.LoadSync<FoodData>("饺子配置");
            JiRouData = _resLoader.LoadSync<FoodData>("鸡肉配置");
        }
    }
}
