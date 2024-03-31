using TMPro;
using UnityEditor;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Inventory seller, buyer;
    public GameObject N, G;             // Name, Gold
    public Shop shop;
    string itemName;
    int gold;

    private void Start()
    {
        itemName = N.GetComponent<TextMeshProUGUI>().text;
        gold = int.Parse(G.GetComponent<TextMeshProUGUI>().text.ToString());
    }


    public void BuyItem()
    {
        if(buyer.gold < gold)
        {
            //EditorApplication.Beep();
            shop.RefereshItems();
            return;
        }
        GameObject.Find("Buy Audio").GetComponent<AudioSource>().Play();
        seller.gold += gold;
        buyer.gold -= gold;
        if (buyer.inventory.ContainsKey(itemName))
            buyer.inventory[itemName] = (buyer.inventory[itemName].Item1 + 1, buyer.inventory[itemName].Item2);
        else
            buyer.inventory[itemName] = (1, gold);
        seller.inventory[itemName] = (seller.inventory[itemName].Item1 - 1, seller.inventory[itemName].Item2);
        if (seller.inventory[itemName].Item1 == 0)
            seller.inventory.Remove(itemName);
        shop.RefereshItems();
    }

}
