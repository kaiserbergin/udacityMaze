using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    public List<Item> Items = new List<Item>();
    private int decryptedKeyCount;
    public bool isEscapeKeyCollected;

    public void AddItem(Item newItem) {
        if(Items.FindIndex(item => item.GetID() == newItem.GetID()) == -1) {
            Items.Add(newItem);
            if(newItem.ItemType == Item.ItemTypes.DecryptionFragment || newItem.ItemType == Item.ItemTypes.EscapeKey) {
                OnDecryptionFragmentOrEncryptedKeyCollected(newItem.ItemType);
            } else if(newItem.ItemType == Item.ItemTypes.BitCoin) {
                OnBitCoinCollected();
            }
        }
    }
    public void RemoveItem(Item itemToDelete) {
        int index = Items.FindIndex(item => item.GetID() == itemToDelete.GetID());
        if (index > -1) {
            Items.RemoveAt(index);
        }
    }
    public void AddItems(List<Item> newItems) {
        foreach(Item newItem in newItems) {
            AddItem(newItem);
        }
    }
    public void RemoveItems(List<Item> itemsToDelete) {
        foreach(Item itemToDelete in itemsToDelete) {
            RemoveItem(itemToDelete);
        }
    }
    public void RemoveAllItems() {
        Items = new List<Item>();
    }
    public void OnDecryptionFragmentOrEncryptedKeyCollected(Item.ItemTypes itemType) {
        if(itemType == Item.ItemTypes.DecryptionFragment) {
            decryptedKeyCount++;
        }
        if(itemType == Item.ItemTypes.EscapeKey) {
            isEscapeKeyCollected = true;
        }
        if(decryptedKeyCount >= GameManager.instance.decryptionFragmentsRequired && isEscapeKeyCollected) {
            EncryptedKey key = (EncryptedKey)Items.Find(item => item.ItemType == Item.ItemTypes.EscapeKey);
            key.IsDecrypted = true;
        }
    }

    public bool IsKeyDecrypted() {
        EncryptedKey key = (EncryptedKey)Items.Find(item => item.ItemType == Item.ItemTypes.EscapeKey);
        if(key != null) {
            return key.IsDecrypted;
        }
        return false;
    }

    public void OnBitCoinCollected() {
        if (Items.FindAll(item => item.ItemType == Item.ItemTypes.BitCoin).Count % GameManager.instance.coinsRequiredForHealthBonus == 0) {
            GameManager.instance.MazePlayer.AddHealthPoints(1);
        }
    }
}
