using UnityEngine;

public class DemandManager : MonoBehaviour
{
    public GameObject SettlePanel;
    [Header("顾客数据")]
    public CustomerData customerData;

    [Header("输出设置")]
    public bool logToConsole = true;
    public bool displayInUI = true;

    public UnityEngine.UI.Text demandText;
    int i = 0;
    private bool isSettlementShown = false;

    private string originalOrdersText = "";

    void Start()
    {

        if (SettlePanel != null)
            SettlePanel.SetActive(false);

        if (customerData != null)
            ProcessCustomerDemands();
    }

    public void ProcessCustomerDemands()
    {

        if (isSettlementShown)
            return;

        if (i >= customerData.demands.Count)
        {
            ShowSettlement();
            return;
        }

        string demandInfo = customerData.GetDemandDescription(i);

        if (!logToConsole)
        {
            Debug.Log(demandInfo);
        }

        if (displayInUI && demandText != null)
        {
            if (i == 0)
            {
                demandText.text = demandInfo;
                originalOrdersText = demandInfo;
            }
            else
            {
                demandText.text += "\n" + demandInfo;
                originalOrdersText += "\n" + demandInfo;
            }
        }
    }

    public void UpdateOrder()
    {
        i++;

        if (i >= customerData.demands.Count)
        {
            ShowSettlement();
            return;
        }

        ProcessCustomerDemands();
    }

    private void ShowSettlement()
    {
        if (SettlePanel != null && !isSettlementShown)
        {
            //清除订单信息
            if (demandText != null)
            {
                demandText.text = "";//清空文本
            }

            //显示结算面板
            SettlePanel.SetActive(true);
            isSettlementShown = true;

            Debug.Log("所有订单已展示，切换到结算画面");
        }
    }

    public void ResetOrders()
    {
        i = 0;
        isSettlementShown = false;

        if (SettlePanel != null)
            SettlePanel.SetActive(false);

        if(demandText!=null)
        {
            demandText.text = originalOrdersText;
        }

        if (customerData != null)
            ProcessCustomerDemands();
    }

    public void UpdateCustomerData(CustomerData newData)
    {
        customerData = newData;
        ResetOrders();
    }
}