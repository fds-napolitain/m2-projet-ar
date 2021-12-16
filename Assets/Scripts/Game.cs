using UnityEngine;
using UnityEngine.SceneManagement;
using Leap;

/// <summary>
/// Script principal du jeu.
/// Attaché à la caméra (donc DontDestroyOnLoad garde la SmartCamera aussi).
/// </summary>
public class Game : MonoBehaviour
{
    // audio
    public static float QUANTIZATION = Quantization.NONE;
    public static int TEMPO = 76;
    private static float currentTime = 0f; // temps absolu (tempo = 60)
    public static float CurrentTime { get => currentTime / (TEMPO / 60); } // temps relatif (tempo pris en compte)
    public static Scale scale;

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
        frame = controller.Frame();
        scale = new Scale(NoteName.E, ScaleType.NONE);
        PianoToucheScript.updateScale = PianoToucheScript.KEYS_NUMBER;
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
    /// >>> [(round(x / q) * q + q/2) / (tempo/60) for x in times]
    /// [0.9868, 0.9868, 1.3815, 1.3815, 1.7763]
    /// 
    /// </summary>
    /// <returns></returns>
    public static float CurrentTimeQuantized
    {
        get {
            if (QUANTIZATION == Quantization.NONE)
            {
                return CurrentTime;
            }
            else
            {
                return (Mathf.Round(currentTime / QUANTIZATION) * QUANTIZATION + QUANTIZATION / 2) / (TEMPO / 60);
            }
        }
    }

    /// <summary>
    /// TBC...
    /// </summary>
    public static void SetGame()
    {

    }
}