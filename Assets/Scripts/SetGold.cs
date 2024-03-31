using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetGold : MonoBehaviour
{
    TextMeshProUGUI gold;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        gold = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = playerInventory.gold.ToString();
    }
}
