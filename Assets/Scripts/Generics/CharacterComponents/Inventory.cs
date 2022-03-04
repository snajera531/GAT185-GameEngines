using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item[] items;

    List<Item> inventory = new List<Item>();
    public Item ActiveItem { get; set; }

    void Start()
    {
        inventory.AddRange(items);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ActivateItem(null);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ActivateItem(inventory[0]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ActivateItem(inventory[1]);

        ActiveItem?.UpdateItem();
    }

    void ActivateItem(Item item)
    {
        ActiveItem?.Deactivate();
        ActiveItem = item;
        ActiveItem?.Activate();
    }

    public void StartItem()
    {
        if (ActiveItem is Weapon weapon)
        {
            weapon.Fire();
        }
    }
}
