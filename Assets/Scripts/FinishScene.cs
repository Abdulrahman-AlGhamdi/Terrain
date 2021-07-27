using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScene : MonoBehaviour {

    private AudioSource finishSoundEffect;
    private bool isLevelCompleted = false;

    private void Start() {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player" && !isLevelCompleted) {
            isLevelCompleted = true;
            finishSoundEffect.Play();
            Invoke("CompleteLevel1", 1.5f);
        }
    }

    private void CompleteLevel1() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
