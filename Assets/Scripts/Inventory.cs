using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold;
    public Dictionary<string, (int, int)> inventory;      // ItemName : (Amount, Cost)

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player Inventory")
        {
            inventory = new Dictionary<string, (int, int)>
            {
                 {"Cheese",(3,400)},
                 {"Meat",(2,600)},
                 {"Water",(3,100)},
                 {"Apple",(4,150)},
                 {"Orange",(4,50)}
            };
        }
        else if (gameObject.name == "Shop Inventory 1")
        {
            inventory = new Dictionary<string, (int, int)>
            {
                 {"Cheese",(5,400)},
                 {"Meat",(7,600)}
            };
        }
        else
        {
            inventory = new Dictionary<string, (int, int)>
            {
                 {"Pineapple",(5,400)},
                 {"Fish",(6,500)}
            };
        }
    }
}
