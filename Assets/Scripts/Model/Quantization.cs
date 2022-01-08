/// <summary>
/// Valeurs constantes de quantification.
/// </summary>
public static class Quantization
{
	// quantization
	public const float WHOLE = 4f; // ronde
	public const float HALF = 2f; // blanche
	public const float QUARTER = 1f; // noire
	public const float EIGHT = 0.5f; // croche
	public const float QUARTER_TRIPLET = 0.33f; // triolet de noires
	public const float SIXTEEN = 0.25f; // double croche
	public const float TRIPLET = 0.167f; // triolet
	public const float DOUBLE_SIXTEEN = 0.125f; // quadruple croche
	public const float NONE = 0f; // no quantization

    /// <summary>
    /// Set game quantization from "enum"
    /// </summary>
    /// <param name="value"></param>
	public static void SetQuantization(float value)
    {
        switch (value)
        {
            case WHOLE:
                Game.QUANTIZATION = WHOLE;
                break;
            case HALF:
                Game.QUANTIZATION = HALF;
                break;
            case QUARTER:
                Game.QUANTIZATION = QUARTER;
                break;
            case EIGHT:
                Game.QUANTIZATION = EIGHT;
                break;
            case QUARTER_TRIPLET:
                Game.QUANTIZATION = QUARTER_TRIPLET;
                break;
            case SIXTEEN:
                Game.QUANTIZATION = SIXTEEN;
                break;
            case TRIPLET:
                Game.QUANTIZATION = TRIPLET;
                break;
            case DOUBLE_SIXTEEN:
                Game.QUANTIZATION = DOUBLE_SIXTEEN;
                break;
            default:
                Game.QUANTIZATION = NONE;
                break;
        }
    }

    /// <summary>
    /// Set game quantization from string
    /// </summary>
    /// <param name="value"></param>
    public static void SetQuantization(string value)
    {
        switch (value)
        {
            case "WHOLE":
                SetQuantization(WHOLE);
                break;
            case "HALF":
                SetQuantization(HALF);
                break;
            case "QUARTER":
                SetQuantization(QUARTER);
                break;
            case "EIGHT":
                SetQuantization(EIGHT);
                break;
            case "QUARTER_TRIPLET":
                SetQuantization(QUARTER_TRIPLET);
                break;
            case "SIXTEEN":
                SetQuantization(SIXTEEN);
                break;
            case "TRIPLET":
                SetQuantization(TRIPLET);
                break;
            case "DOUBLE_SIXTEEN":
                SetQuantization(DOUBLE_SIXTEEN);
                break;
            default:
                SetQuantization(NONE);
                break;
        }
    }
}
