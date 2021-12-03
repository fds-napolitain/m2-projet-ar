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

    /// <summary>
    /// Initialisation des positions des mains.
    /// </summary>
    void Start()
    {
        leftX = left.transform.position.x; // constantes
        rightX = right.transform.position.x;
        cameraX = transform.position.x;
        cameraY = transform.position.y;
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
            float zoom = Mathf.Sqrt(Mathf.Pow(left.transform.position.x, 2) - Mathf.Pow(right.transform.position.x, 2));
            if (Mathf.Abs(transform.position.x - centerX) >= 0.001 || zoom > 2)
            {
                transform.position = new Vector3(centerX, cameraY + (zoom-2)/30f, transform.position.z); // se déplace et zoom de la différence
            }
        }
    }
}
