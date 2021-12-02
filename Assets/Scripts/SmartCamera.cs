using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adapte la cam�ra aux mouvements des mains.
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
    /// Appel� une fois par frame.
    /// Bouge la cam�ra en fonction des valeurs trouv�s et calcul�es au d�but.
    /// </summary>
    void Update()
    {
        // translation
        float translation = left.transform.position.x + right.transform.position.x;
        if (currentTranslation != translation)
        {
            transform.position.x += (translation - currentTranslation); // se d�place de la diff�rence
            currentTranslation = translation; // enregistre le d�calage actuel
        }
        // zoom
        float zoom = Math.Abs(left.transform.position.x) + Math.Abs(right.transform.position.x);
        if (zoom != currentZoom)
        {
            transform.position.y += (zoom - currentZoom); // zoom de la diff�rence
            currentZoom = zoom; //enregistre le zoom actuel
        }
    }
}
