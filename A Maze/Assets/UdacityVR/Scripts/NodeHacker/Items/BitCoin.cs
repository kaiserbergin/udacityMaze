using System;
using System.Collections.Generic;
using UnityEngine;

public class BitCoin : Item {
    public GameObject CollectCoinEffect;
    public GameObject CoinCollider;
    public float spinSpeedMultiplier = 10f;

    void Update() {
        transform.Rotate(Vector3.up, spinSpeedMultiplier * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (CoinCollider != null) {
            if (other.tag == "Player") {
                CollectCoin();
            }
        }

    }

    public void CollectCoin() {
        GameManager.instance.inventory.AddItem(this);
        CollectCoinEffect.transform.position = gameObject.transform.position;
        Instantiate(CollectCoinEffect);
        gameObject.SetActive(false);
    }
}
