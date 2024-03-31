using TMPro;
using UnityEditor;
using UnityEngine;

public class ATM : MonoBehaviour
{

    public ATMBalance aTMBalance;
    public TextMeshProUGUI aTMBalanceGUI;
    public TMP_InputField input;
    public Inventory myInventory;
    int amount;

    private void Update()
    {
        aTMBalanceGUI.text = aTMBalance.atmBalance.ToString();
    }
    private void OnEnable()
    {
        input.text = "";
    }
    public void Withdraw()
    {
        amount = int.Parse(input.text);
        if (amount > aTMBalance.atmBalance)
        {
            //EditorApplication.Beep();
        }
        else
        {
            myInventory.gold += amount;
            aTMBalance.atmBalance -= amount;
        }
    }
    public void Deposit()
    {
        amount = int.Parse(input.text);
        if (amount > myInventory.gold)
        {
            //EditorApplication.Beep();
        }
        else
        {
            myInventory.gold -= amount;
            aTMBalance.atmBalance += amount;
        }
    }
}
