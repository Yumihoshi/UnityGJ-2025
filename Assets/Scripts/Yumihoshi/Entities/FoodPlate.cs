// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 04:10
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Cmds;
using Yumihoshi.SO;

namespace Yumihoshi.Entities
{
    public class FoodPlate : MonoBehaviour
    {
        [Header("组件引用")] [LabelText("食材图片")] public Image foodImg;

        [LabelText("食材时间文本")] public Text timeText;

        [Header("配置")] [LabelText("索引")] public int index;

        public FoodData Food { get; set; }

        private Vector3 _startPos;
        private bool _isDragging;
        private Vector3 _downPos;
        private Vector3 _offset;

        private void Start()
        {
            _startPos = foodImg.transform.localPosition;
        }

        private void Update()
        {
            if (!_isDragging) return;
            foodImg.transform.localPosition = Input.mousePosition + _offset;
        }

        public void OnPointerDown(BaseEventData data)
        {
            _downPos = Input.mousePosition;
            _offset = _startPos - _downPos;
            _isDragging = true;
            FoodManager.Instance.DraggingFoodIndex = index;
        }

        public void OnPointerUp(BaseEventData data)
        {
            _isDragging = false;

            // 发射射线检测下方的槽位
            RaycastHit2D hit =
                Physics2D.Raycast(
                    Camera.main.ScreenToWorldPoint(Input.mousePosition),
                    Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("ChuanSlot"))
            {
                var slot = hit.collider.GetComponent<ChuanSlot>();
                if (slot != null && slot.IsEmpty())
                {
                    // 放置食材到槽位
                    slot.PlaceIngredient(
                        FoodManager.Instance.FoodPlate.Model.FoodOnTable[
                            FoodManager.Instance.DraggingFoodIndex]);
                    // 可以在这里销毁或禁用当前食材对象
                    // gameObject.SetActive(false);
                    FoodManager.Instance.FoodPlate.SendCommand(
                        new RemoveFoodCmd(
                            FoodManager.Instance.DraggingFoodIndex));
                }
            }

            foodImg.transform.localPosition = _startPos;
        }

        public void SetFoodData(FoodData data)
        {
            Food = data;
        }

        /// <summary>
        /// 设置食材UI图片
        /// </summary>
        /// <param name="sprite"></param>
        public void SetFoodSprite(Sprite sprite)
        {
            foodImg.color = Color.white;
            foodImg.sprite = sprite;
        }

        /// <summary>
        /// 设置食材花费时间文本
        /// </summary>
        /// <param name="text"></param>
        public void SetTimeText(string text)
        {
            timeText.text = text + "秒";
        }

        /// <summary>
        /// 隐藏食材UI
        /// </summary>
        public void HideFood()
        {
            foodImg.color = Color.clear;
            foodImg.sprite = null;
            timeText.text = string.Empty;
            Food = null;
        }
    }
}
