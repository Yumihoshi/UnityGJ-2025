// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 17:39
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;

namespace Yumihoshi.Managers
{
    public class GameManager : HoshiVerseFramework.Base.Singleton<GameManager>
    {
        public BindableProperty<float> RestTime { get; } =
            new(15f);

        /// <summary>
        /// 减少剩余时间
        /// </summary>
        /// <param name="amount"></param>
        public void ReduceRestTime(float amount)
        {
            RestTime.Value =
                Mathf.Clamp(RestTime.Value - amount, 0f, float.MaxValue);
        }
    }
}
