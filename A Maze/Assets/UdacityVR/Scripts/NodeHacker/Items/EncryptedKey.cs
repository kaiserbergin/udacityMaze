using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncryptedKey : Item {
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject CollectKeyEffect;
    public GameObject Door;

    public bool IsDecrypted;

    void Update() {
        //Not required, but for fun why not try adding a Key Floating Animation here :)
    }

    public void OnKeyClicked() {
        GameManager.instance.inventory.AddItem(this);
        Instantiate(CollectKeyEffect);
        CollectKeyEffect.transform.position = gameObject.transform.position;
        gameObject.SetActive(false);
    }

}
