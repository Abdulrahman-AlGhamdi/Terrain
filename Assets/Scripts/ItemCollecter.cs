using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour {

    private int melonCounter = 0;

    [SerializeField] private Text melonText;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Melon")) {
            Destroy(collision.gameObject);
            melonCounter++;
            melonText.text = "Melons: " + melonCounter;
        }
    }
}
