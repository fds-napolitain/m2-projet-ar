/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using Leap.Unity;
using Leap.Unity.Query;
using Leap;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoToucheScript : MonoBehaviour
{
    private static float QUANTIZATION = 0.25f;
    private static float RELEASE_TIME = 0.33f;
    private float release_tmp = 0;
    private bool release = false;
    private AudioSource audio;

    private static Controller controller;
    private static Frame frame;
    private static bool flag = false;
    private Material _material;
    private InteractionBehaviour _intObj;
    private bool keySuspended = true;
    private float _fingertipRadius = 0.01f; // 1 cm

    void Start()
    {
        audio = GetComponent<AudioSource>(); // recupere l'audiosource dans une variable
        if (!flag)
        {
            controller = new Controller();
            flag = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        frame = controller.Frame();
        int a = Convert.ToInt32(collider.name);
        Debug.Log(frame.Hands.Count);
        if (frame.Hands.Count >= 1 && !frame.Hands[0].IsLeft) // si la main "gauche" est celle de "droite"
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
        if (frame.Hands[a/5].Fingers[a%5].IsExtended) // joue le son
        {
            audio.Play();
            transform.Rotate(Vector3.up * -2);
        }
    }

    void OnTriggerExit()
    {
        release = true;
        transform.Rotate(Vector3.up * 2);
    }

    void Update()
    {
        // release de la touche jusqu'a fin de note (release_time)
        if (release)
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
    }

}
