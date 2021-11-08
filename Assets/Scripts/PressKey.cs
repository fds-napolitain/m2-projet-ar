using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKey : MonoBehaviour
{
    private static float QUANTIZATION = 0.25f;
    private static float RELEASE_TIME = 0.33f;
    private float release_tmp = 0;
    private bool release = false;
    private AudioSource audio = GetComponent<AudioSource>();

    /// <summary>
    /// Initialise sounds of each keys
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Fixed update time for constant time quantization
    /// Used for real time playing.
    /// </summary>
    void Update()
    {
        // Start sound: attack, sustain then decay while pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Play sound");
            audio.Play(0);
        }

        // Stop sound (either attack or decay) and start release
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("Release");
            release = true;
        }
        if (release) // release: sound disappear overtime
        {
            release_tmp += Time.deltaTime;
            audio.volume -= Time.deltaTime / RELEASE_TIME;
            if (release_tmp >= RELEASE_TIME)
            {
                release_tmp = 0;
                release = false;
                audio.Stop();
                audio.volume = 1f;
            }
        }

        // Change songs (tied with difficulty)

    }
}
