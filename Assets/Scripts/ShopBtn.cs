using UnityEngine;

public class ShopBtn : MonoBehaviour
{
    public Inventory buyer;
    public Inventory seller;
    public Shop shop;

    public void EnterShop()
    {
        shop.buyer = buyer;
        shop.seller = seller;
        shop.gameObject.SetActive(true);
    }
}
