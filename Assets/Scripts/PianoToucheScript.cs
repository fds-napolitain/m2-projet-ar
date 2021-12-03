/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Script liée à chaque touche
/// </summary>
public class PianoToucheScript : MonoBehaviour
{
    // audio
    private static float RELEASE_TIME = 0.33f;
    private float release_tmp = 0;
    private bool release = false;
    private float playNote = -1f; // -1 = false, float:x = play at x
    private AudioSource audioSource;

    /// <summary>
    /// Appelé au début du script.
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // recupere l'audiosource dans une variable
    }

    /// <summary>
    /// Quand on touche une note avec un doigt.
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        int a = Convert.ToInt32(collider.name);
        if (Game.frame.Hands.Count >= 1 && !Game.frame.Hands[0].IsLeft) // si la main "gauche" est celle de "droite"
        {
            if (a > 4) // inversement
            {
                a -= 5;
            }
            else
            {
                a += 5;
            }
        } 
        if (Game.frame.Hands[a/5].Fingers[a%5].IsExtended) // joue le son
        {
            //Debug.Log("Note détectée: " + Game.currentTime);
            playNote = Game.currentTimeQuantized();
            if (playNote == Game.currentTime)
            {
                PlayNote();
            }
        }
    }

    /// <summary>
    /// Quand on arrête de toucher une note avec le doigt.
    /// </summary>
    void OnTriggerExit()
    {
        //Debug.Log("Note release: " + Game.currentTime);
        release = true;
        //transform.Rotate(new Vector3(1f, 0f, 0f) * -2);
    }

    /// <summary>
    /// Chaque frame, joue les sons ou non.
    /// </summary>
    void Update()
    {
        // quantification de notes
        if (Game.currentTime >= playNote)
        {
            //Debug.Log(playNote + " " + Game.currentTime);
            PlayNote();
        }
        // release de la touche jusqu'a fin de note (release_time)
        if (release) 
        {
            release_tmp += Time.deltaTime;
            audioSource.volume -= Time.deltaTime / RELEASE_TIME;
            if (release_tmp >= RELEASE_TIME)
            {
                //Debug.Log("Note stop: " + Game.currentTime);
                release_tmp = 0;
                release = false;
                audioSource.Stop();
                audioSource.volume = 1f;
            }
        }
    }

    /// <summary>
    /// Joue la note en fonction de la quantification.
    /// </summary>
    void PlayNote()
    {
        if (playNote != -1f) // joue la note, rotate la touche
        {
            //Debug.Log("Note début: " + Game.currentTime);
            audioSource.Play();
            //transform.Rotate(new Vector3(1f, 0f, 0f) * 2);
            playNote = -1f;
        }
    }
}
