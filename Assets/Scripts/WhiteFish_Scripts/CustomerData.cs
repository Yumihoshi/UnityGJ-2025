using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewCustomer", menuName = "Game/Customer Data")]
public class CustomerData : ScriptableObject
{
    public string customerName;
    public Sprite customerIcon;
    public List<CustomerDemand> demands = new List<CustomerDemand>();

    private void OnEnable()
    {
        if (demands == null)
        {
            demands = new List<CustomerDemand>();
        }

        if (demands.Count == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                demands.Add(new CustomerDemand(
                    Random.Range(1, 5),
                    Random.Range(1, 5),
                    Random.Range(1, 5),
                    Random.Range(1, 5)
                ));
            }
        }
    }

    public string GetDemandDescription(int index)
    {
        if (index < 0 || index >= demands.Count)
        {
            return "无效的需求索引";
        }

        CustomerDemand demand = demands[index];
        string status = demand.isCompleted ? "[已完成]" : "[未完成]";
        return $"需求 {index + 1}: 肉 x{demand.meatAmount}, 蔬菜 x{demand.vegetableAmount}, " +
               $"豆制品 x{demand.beanProductAmount}, 菌类 x{demand.mushroomAmount}";
    }

    public bool AreAllDemandsCompleted()
    {
        foreach (CustomerDemand demand in demands)
        {
            if (!demand.isCompleted)
                return false;
        }
        return true;
    }

    public void MarkDemandCompleted(int index)
    {
        if (index >= 0 && index < demands.Count)
        {
            demands[index].isCompleted = true;
        }
    }
    public void ResetAllDemands()
    {
        foreach (CustomerDemand demand in demands)
        {
            demand.isCompleted = false;
        }
    }
}