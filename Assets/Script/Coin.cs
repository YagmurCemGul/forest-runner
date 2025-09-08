using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip ClickSound;
    private int count = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log(count);
            count++;
            AudioSource.PlayClipAtPoint(ClickSound, other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
