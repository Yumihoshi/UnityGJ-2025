// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 05:06
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections;
using QFramework;
using UnityEngine;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Cmds;

namespace Yumihoshi
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(TTest());
        }

        private IEnumerator TTest()
        {
            yield return new WaitForSeconds(1f);
            FoodManager.Instance.FoodPlate.SendCommand(new AddFoodPlateCmd(2));
            FoodManager.Instance.FoodPlate.SendCommand(
                new AddFoodCmd(ResManager.Instance.DouPiData));
            FoodManager.Instance.FoodPlate.SendCommand(
                new AddFoodCmd(ResManager.Instance.JiaoZiData));
            FoodManager.Instance.FoodPlate.SendCommand(
                new AddFoodCmd(ResManager.Instance.JiRouData));
            FoodManager.Instance.FoodPlate.SendCommand(
                new AddFoodCmd(ResManager.Instance.TudouData));
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(1f);
                GameManager.Instance.ReduceRestTime(2);
            }
        }
    }
}
