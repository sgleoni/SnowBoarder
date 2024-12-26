using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float InvokeDelay = 2f;
    [SerializeField] ParticleSystem finishEffect;
    private bool hasFinished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasFinished)
        {
            hasFinished = true;
            FindObjectOfType<PlayerController>().DisableControls();
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", InvokeDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
