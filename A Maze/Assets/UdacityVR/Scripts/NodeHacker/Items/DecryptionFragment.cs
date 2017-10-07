using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecryptionFragment : Item {
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject CollectDecryptionEffect;

    void Update() {
        //Not required, but for fun why not try adding a Key Floating Animation here :)
    }

    public void OnClick() {
        GameManager.instance.inventory.AddItem(this);
        Instantiate(CollectDecryptionEffect);
        CollectDecryptionEffect.transform.position = gameObject.transform.position;
        gameObject.SetActive(false);
    }

}
