using System;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponents<AudioSource>()[1];
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Finish":
                LoadNextLevel();
                break;
            case "Friendly":
                // Do nothing
                break;
            default:
                if (!audioSource.isPlaying)
                    audioSource.Play();

                Time.timeScale = 0.25f;
                Invoke("ReloadLevel", 0.75f);

                break;
        }
    }

    private void LoadNextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevelIndex % SceneManager.sceneCountInBuildSettings);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
