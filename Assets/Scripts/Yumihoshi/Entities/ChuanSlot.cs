// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/09/20 09:48
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;
using Yumihoshi.SO;

namespace Yumihoshi.Entities
{
    public class ChuanSlot : MonoBehaviour
    {
        public FoodData Food { get; set; }

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public bool IsEmpty()
        {
            return Food == null;
        }

        public void PlaceIngredient(FoodData data)
        {
            Food = data;
            _spriteRenderer.sprite = data.foodSprite;
        }

        public void ClearFood()
        {
            Food = null;
            _spriteRenderer.sprite = null;
        }
    }
}
