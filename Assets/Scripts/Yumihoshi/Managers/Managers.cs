// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 03:45
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;

namespace Yumihoshi.Managers
{
    public class Managers : Singleton<Managers>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
