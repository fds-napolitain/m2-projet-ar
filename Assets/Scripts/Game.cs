using UnityEngine;

/// <summary>
/// Script principal du jeu. Pour le moment, rien.
/// </summary>
public class Game : MonoBehaviour
{
    private static float QUANTIZATION = Quantization.SIXTEEN;
    private static int TEMPO = 60;
    private static float currentTime = 0f;

    void Start()
    {

    }

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