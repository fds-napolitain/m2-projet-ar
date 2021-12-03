using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

/// <summary>
/// Adapte la caméra aux mouvements des mains.
/// </summary>
public class SmartCamera : MonoBehaviour
{
    // camera
    public GameObject left; // mains
    public GameObject right;
    private float leftX; // positions initiales
    private float rightX;
    private float cameraX;
    private float cameraY;
    private float currentTranslation; // translation actuel
    private float currentZoom; // zoom actuel

    /// <summary>
    /// Initialisation des positions des mains.
    /// </summary>
    void Start()
    {
        leftX = left.transform.position.x; // constantes
        rightX = right.transform.position.x;
        cameraX = transform.position.x;
        cameraY = transform.position.y;
        currentTranslation = (left.transform.position.x + right.transform.position.x) / 2f; // variables
        currentZoom = (Mathf.Abs(left.transform.position.x) + Mathf.Abs(right.transform.position.x)) / 2f;
    }

    /// <summary>
    /// Appelé une fois par frame.
    /// Bouge la caméra en fonction des valeurs trouvés et calculées au début.
    /// </summary>
    void Update()
    {
        if (Game.frame.Hands.Count == 2)
        {
            float centerX = (left.transform.position.x + right.transform.position.x) / 2f;
            float zoom = (Mathf.Abs(left.transform.position.x) + Mathf.Abs(right.transform.position.x)) / 2f;
            if (currentTranslation != centerX || zoom != currentZoom)
            {
                transform.position += new Vector3(centerX - currentTranslation, zoom - currentZoom, transform.position.z); // se déplace et zoom de la différence
                currentTranslation = centerX; // enregistre le décalage actuel
                currentZoom = zoom; //enregistre le zoom actuel
            }
        }
    }
}
