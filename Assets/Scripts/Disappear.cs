using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && count == 0)
        {
            count++;
            other.gameObject.GetComponentInParent<Coins>().AddCoin();
            Destroy(gameObject);
        }
    }
}
