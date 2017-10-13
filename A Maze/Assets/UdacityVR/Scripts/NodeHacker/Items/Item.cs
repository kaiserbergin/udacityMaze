using System;
using UnityEngine;
public class Item : MonoBehaviour {
    public enum ItemTypes {
        EscapeKey,
        DecryptionFragment,
        HealtPack,
        BitCoin
    }
    private Guid ID;
    public string Name;
    public ItemTypes ItemType;
    public GameObject ItemIcon;
    
    public Item() {
        ID = Guid.NewGuid();
    }

    public Item(string name, ItemTypes itemType) {
        ID = Guid.NewGuid();
        Name = name;
        ItemType = itemType;
    } 

    public Guid GetID() {
        return ID;
    }
}
