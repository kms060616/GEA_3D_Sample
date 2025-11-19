using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class InventoryUI : MonoBehaviour
{
    public Sprite Dirt;
    public Sprite Grass;
    public Sprite Water;
    public List<Transform> Slot = new List<Transform>();
    public GameObject SlotItem;
    List<GameObject> items = new List<GameObject>();

    public void UpdateInventory(Inventory myInven)
    {
        foreach(var slotItems in items)
        {
            Destroy(slotItems);
        }
        items.Clear();

        int idx = 0;
        foreach (var item in myInven.items)
        {

            if (idx >= Slot.Count)
                break;

            var go = Instantiate(SlotItem, Slot[idx].transform);
            go.transform.localPosition = Vector3.zero;
            SlotItemPrefab sltem = go.GetComponent<SlotItemPrefab>();
            items.Add(go);

            switch (item.Key)
            {
                case BlockType.Dirt:
                    sltem.itemImage.sprite = Dirt;
                    break;

                case BlockType.Water:
                    sltem.itemImage.sprite = Water;
                    break;
                case BlockType.Grass:
                    sltem.itemImage.sprite = Grass;
                    break;


            }

            if (sltem.itemText != null)
            {
                sltem.itemText.text = item.Value.ToString();
            }
            idx++;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
