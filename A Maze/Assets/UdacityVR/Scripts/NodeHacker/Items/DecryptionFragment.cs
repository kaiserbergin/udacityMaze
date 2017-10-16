using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecryptionFragment : Item {
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject CollectDecryptionEffect;
    public float spinSpeedMultiplier = 10f;

    void Update() {
        transform.Rotate(Vector3.up, spinSpeedMultiplier * Time.deltaTime * -1);
    }

    public void OnClick() {
        GameManager.instance.inventory.AddItem(this);        
        CollectDecryptionEffect.transform.position = gameObject.transform.position;
        Instantiate(CollectDecryptionEffect);
        gameObject.SetActive(false);
    }

}
