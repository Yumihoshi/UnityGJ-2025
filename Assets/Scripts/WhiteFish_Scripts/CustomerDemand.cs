using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CustomerDemand
{
    public int meatAmount;
    public int vegetableAmount;
    public int beanProductAmount;
    public int mushroomAmount;
    public bool isCompleted;
    
    public CustomerDemand(int meat, int vegetable, int beanProduct, int mushroom)
    {
        meatAmount = meat;
        vegetableAmount = vegetable;
        beanProductAmount = beanProduct;
        mushroomAmount = mushroom;
        isCompleted = false;
    }

    public CustomerDemand()
    {
        meatAmount = 0;
        vegetableAmount = 0;
        beanProductAmount = 0;
        mushroomAmount = 0;
        isCompleted = false;
    }

    public override string ToString()
    {
        string status = isCompleted ? "[已完成]" : "[未完成]";
        return $"肉: {meatAmount}, 蔬菜: {vegetableAmount}, 豆制品: {beanProductAmount}, 菌类: {mushroomAmount}";
    }
}

