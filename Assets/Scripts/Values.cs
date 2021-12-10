/// <summary>
/// Valeurs constantes utiles pour le jeu.
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
}

/// <summary>
/// Gamme.
/// </summary>
public static class Scale
{
	/// <summary>
    /// Liste des notes.
    /// </summary>
	public enum Note
    {
		C,
		D,
		E,
		F,
		G,
		A,
		B,
    }

	/// <summary>
    /// Note majeures (blanche) ou mineures (noires)
    /// </summary>
	public enum NoteType
    {
		MAJOR,
		MINOR,
    }

	/// <summary>
    /// Gamme majeure.
    /// </summary>
	public enum Major
    {
		NOTE1 = NoteType.MAJOR,
		NOTE2 = NoteType.MAJOR,
		NOTE3 = NoteType.MAJOR,
		NOTE4 = NoteType.MAJOR,
		NOTE5 = NoteType.MAJOR,
		NOTE6 = NoteType.MAJOR,
		NOTE7 = NoteType.MAJOR,
	}
	
	/// <summary>
    /// Gamme mineure.
    /// </summary>
	public enum Minor
	{
		NOTE1 = NoteType.MAJOR,
		NOTE2 = NoteType.MAJOR,
		NOTE3 = NoteType.MINOR,
		NOTE4 = NoteType.MAJOR,
		NOTE5 = NoteType.MAJOR,
		NOTE6 = NoteType.MINOR,
		NOTE7 = NoteType.MINOR,
	}
}