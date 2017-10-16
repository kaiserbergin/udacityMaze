using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncryptedKey : Item {
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject CollectKeyEffect;
    public GameObject Door;
    public float spinSpeedMultiplier = 10f;

    public bool IsDecrypted;

    void Update() {
        transform.Rotate(Vector3.up, spinSpeedMultiplier * Time.deltaTime);
    }

    public void OnKeyClicked() {
        GameManager.instance.inventory.AddItem(this);
        CollectKeyEffect.transform.position = gameObject.transform.position;
        Instantiate(CollectKeyEffect);
        gameObject.SetActive(false);
    }

}
