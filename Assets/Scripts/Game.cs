using UnityEngine;
using UnityEngine.SceneManagement;
using Leap;

/// <summary>
/// Script principal du jeu. Pour le moment, rien.
/// </summary>
public class Game : MonoBehaviour
{
    // audio
    public static float QUANTIZATION = Quantization.SIXTEEN;
    public static int TEMPO = 60;
    public static float currentTime = 0f;
    public static Scale.Note baseNote = Scale.Note.C;

    // interactions
    public static Controller controller;
    public static Frame frame;

    /// <summary>
    /// Initialisations au début.
    /// </summary>
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        controller = new Controller();
    }

    /// <summary>
    /// Une fois par frame.
    /// </summary>
    void Update()
    {
        currentTime += Time.deltaTime;
        frame = controller.Frame();
    }

    /// <summary>
    /// Quantification de notes
    /// 
    /// Exemple en python
    /// >>> q
    /// 0.5
    /// >>> times
    /// [0.99, 1.02, 1.49, 1.51, 1.99]
    /// >>> [round(x / q) * q for x in times]
    /// [1.0, 1.0, 1.5, 1.5, 2.0]
    /// >>> [round(x / q) * q + q/2 for x in times]
    /// [1.25, 1.25, 1.75, 1.75, 2.25]
    /// 
    /// </summary>
    /// <returns></returns>
    public static float currentTimeQuantized()
    {
        if (QUANTIZATION == Quantization.NONE)
        {
            return currentTime;
        }
        else
        {
            return Mathf.Round(currentTime / QUANTIZATION) * QUANTIZATION + QUANTIZATION / 2;
        }
    }
}