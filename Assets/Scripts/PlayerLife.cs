using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

    private Animator animator;
    private new Rigidbody2D rigidbody2D;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap")) {
            Die();
        }
    }

    private void Die() {
        deathSoundEffect.Play();
        animator.SetTrigger("death");
        rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
