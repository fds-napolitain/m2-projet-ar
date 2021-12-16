/// <summary>
/// Gamme : note de base + gamme associée
/// </summary>
public class Scale
{
	public NoteName note;
	private ScaleType scale;
	private NoteType note1;
	private NoteType note2;
	private NoteType note3;
	private NoteType note4;
	private NoteType note5;
	private NoteType note6;
	private NoteType note7;

	/// <summary>
    /// Default constructeur
    /// </summary>
	public Scale()
    {
		this.note = NoteName.C;
		SetScale(ScaleType.None);
    }

	/// <summary>
    /// Parametized constructor : base note and its scale.
    /// </summary>
    /// <param name="note"></param>
    /// <param name="scale"></param>
	public Scale(NoteName note, ScaleType scale)
	{
		this.note = note;
		SetScale(scale);
	}

	/// <summary>
    /// Called everytime to change a scale.
    /// </summary>
    /// <param name="scale"></param>
	public void SetScale(ScaleType scale)
    {
		this.scale = scale;
		switch (scale)
		{
			case ScaleType.None: // toutes les notes
				note1 = NoteType.ANY;
				note2 = NoteType.ANY;
				note3 = NoteType.ANY;
				note4 = NoteType.ANY;
				note5 = NoteType.ANY;
				note6 = NoteType.ANY;
				note7 = NoteType.ANY;
				break;
			case ScaleType.Major: // gamme majeure
				note1 = NoteType.MAJOR;
				note2 = NoteType.MAJOR;
				note3 = NoteType.MAJOR;
				note4 = NoteType.MAJOR;
				note5 = NoteType.MAJOR;
				note6 = NoteType.MAJOR;
				note7 = NoteType.MAJOR;
				break;
			case ScaleType.Minor: // gamme mineure
				note1 = NoteType.MAJOR;
				note2 = NoteType.MAJOR;
				note3 = NoteType.MINOR;
				note4 = NoteType.MAJOR;
				note5 = NoteType.MAJOR;
				note6 = NoteType.MINOR;
				note7 = NoteType.MINOR;
				break;
		}
	}
}

/// <summary>
/// Gammes théorique.
/// </summary>
public enum ScaleType
{
	None,
	Major,
	Minor,
}
