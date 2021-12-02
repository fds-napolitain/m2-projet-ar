using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script principal du jeu. Pour le moment, rien.
/// </summary>
public class Game : MonoBehaviour
{
    public static float QUANTIZATION = Quantization.SIXTEEN;
    public static int TEMPO = 60;
    public static float currentTime = 0f;

    /// <summary>
    /// Initialisations au d�but.
    /// </summary>
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Une fois par frame.
    /// </summary>
    void Update()
    {
        currentTime += Time.deltaTime;
    }

    /// <summary>
    /// Quantification de notes
    /// </summary>
    /// <returns></returns>
    public static float currentTimeQuantized()
    {
        return Mathf.Round(currentTime / Game.QUANTIZATION) * Game.QUANTIZATION + Game.QUANTIZATION / 2;
    }
}