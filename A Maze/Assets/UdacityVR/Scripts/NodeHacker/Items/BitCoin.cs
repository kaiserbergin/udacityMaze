using System;
using System.Collections.Generic;
using UnityEngine;

class BitCoin : Item {
    public GameObject CollectCoinEffect;
    public GameObject CoinCollider;

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (CoinCollider != null) {
            if (other.tag == "Player") {
                CollectKey();
            }
        }

    }

    public void CollectKey() {
        GameManager.instance.inventory.AddItem(this);
        CollectCoinEffect.transform.position = gameObject.transform.position;
        Instantiate(CollectCoinEffect);
        gameObject.SetActive(false);
    }
}
