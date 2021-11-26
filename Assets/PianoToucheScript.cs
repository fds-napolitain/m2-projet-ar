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
        /*
        _intObj = GetComponent<InteractionBehaviour>();
        _intObj.OnContactBegin += () =>
        {

            foreach (var contactingHand in _intObj.contactingControllers
                                                 .Query()
                                                 .Select(controller => controller.intHand)
                                                 .Where(intHand => intHand != null)
                                                 .Select(intHand => intHand.leapHand))
            {
                foreach (var finger in contactingHand.Fingers)
                {
                    var fingertipPosition = finger.TipPosition.ToVector3();

                    // If the distance from the fingertip and the object is less
                    // than the 'fingertip radius', the fingertip is touching the object.
                    if (_intObj.GetHoverDistance(fingertipPosition) < _fingertipRadius)
                    {
                       // Debug.Log("Found collision for fingertip: " + finger..bones[0].Type);
                    }
                }
            }
            //Debug.Log("Play sound" + keySuspended.ToString());

            if (keySuspended) transform.Rotate(Vector3.right * -2);
            GetComponent<AudioSource>().Play();
        };
        _intObj.OnContactEnd += () =>
        {
            //Debug.Log("Stop" + keySuspended.ToString());
            keySuspended = true;
            transform.Rotate(Vector3.right * 2);
        };



        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            renderer = GetComponentInChildren<Renderer>();
        }
        if (renderer != null)
        {
            _material = renderer.material;
        }*/

    }

    void OnTriggerEnter(Collider collider )
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
        }
    }

    void OnTriggerExit()
    {
        release = true;
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
