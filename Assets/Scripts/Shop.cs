using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Inventory buyer { get; set; }
    public Inventory seller { get; set; }
    public GameObject inventoryItem, playerList, shopList;

    private void OnEnable()
    {
        setItems(buyer, playerList);
        setItems(seller, shopList);
    }


    public void CloseShop()
    {
        DestroyItems();
        gameObject.SetActive(false);
    }
    private void setItems(Inventory inv, GameObject spawnList)
    {
        int x = 150;
        int y = 300;
        spawnList.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (inv.inventory.Count / 2) * 500);
        int count = 0;
        foreach (var item in inv.inventory)
        {
            var invItem = Instantiate(inventoryItem, spawnList.transform);
            if (count % 2 == 0)
                invItem.GetComponent<RectTransform>().localPosition = new Vector3(x, y * (int)((-count / 2) - 1) + 150, 0);
            else
                invItem.GetComponent<RectTransform>().localPosition = new Vector3(3 * x, y * (int)((-count / 2) - 1) + 150, 0);
            var texts = invItem.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = item.Key;
            texts[1].text = item.Value.Item1.ToString();
            texts[2].text = item.Value.Item2.ToString();
            var itemScript = invItem.GetComponent<InventoryItem>();
            itemScript.shop = this;
            if (inv.gameObject.name == "Player Inventory")
            {
                invItem.GetComponentInChildren<Text>().text = "SELL";
                
                itemScript.buyer = seller;
                itemScript.seller = inv;
            }
            else
            {
                itemScript.buyer = buyer;
                itemScript.seller = inv;
            }
            count++;
        }
    }
    private void DestroyItems()
    {
        var list = GameObject.FindGameObjectsWithTag("ShopItem");
        foreach (var item in list)
        {
            Destroy(item);
        }
    }
    public void RefereshItems()
    {
        DestroyItems();
        setItems(buyer, playerList);
        setItems(seller, shopList);
    }
}
