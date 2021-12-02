using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adapte la caméra aux mouvements des mains.
/// </summary>
public class SmartCamera : MonoBehaviour
{
    public GameObject left; // mains
    public GameObject right;
    private const float leftX; // positions initiales
    private const float rightX;
    private const float cameraX;
    private const float cameraY;
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
        currentTranslation = left.transform.position.x + right.transform.position.x; // variables
        currentZoom = Math.Abs(left.transform.position.x) + Math.Abs(right.transform.position.x);
    }

    /// <summary>
    /// Appelé une fois par frame.
    /// Bouge la caméra en fonction des valeurs trouvés et calculées au début.
    /// </summary>
    void Update()
    {
        // translation
        float translation = left.transform.position.x + right.transform.position.x;
        if (currentTranslation != translation)
        {
            transform.position.x += (translation - currentTranslation); // se déplace de la différence
            currentTranslation = translation; // enregistre le décalage actuel
        }
        // zoom
        float zoom = Math.Abs(left.transform.position.x) + Math.Abs(right.transform.position.x);
        if (zoom != currentZoom)
        {
            transform.position.y += (zoom - currentZoom); // zoom de la différence
            currentZoom = zoom; //enregistre le zoom actuel
        }
    }
}
