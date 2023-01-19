using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int coinValue = 100;
    [SerializeField] AudioClip coinPickupSFX;

    bool hasBeenCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasBeenCollected)
        {
            hasBeenCollected = true;
            FindObjectOfType<GameSession>().AddToScore(coinValue);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
