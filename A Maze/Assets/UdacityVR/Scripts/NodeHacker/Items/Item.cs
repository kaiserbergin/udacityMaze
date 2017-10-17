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

    public AudioClip ItemCollectedAudioClip;
    public GameObject ItemCollectedEffect;


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

    public void CollectItem() {
        GameManager.instance.inventory.AddItem(this);
        ItemCollectedEffect.transform.position = gameObject.transform.position;
        Instantiate(ItemCollectedEffect);
        GameObject child = transform.GetChild(0).gameObject;
        child.SetActive(false);
        if (ItemCollectedAudioClip != null) {
            AudioManager.instance.PlaySingle(ItemCollectedAudioClip);
        }
    }
}
