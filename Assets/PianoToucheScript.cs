/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using Leap.Unity;
using Leap.Unity.Query;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PianoToucheScript : MonoBehaviour
{

    private Material _material;

    private InteractionBehaviour _intObj;
    private bool keySuspended = true;
    private float _fingertipRadius = 0.01f; // 1 cm

    void Start()
    {
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
        }
    }

    void Update()
    {

    }

}
