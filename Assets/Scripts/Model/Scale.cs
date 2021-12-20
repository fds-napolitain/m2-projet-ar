using System.Collections.Generic;

/// <summary>
/// Gamme : note de base + gamme associ?e
/// </summary>
public class Scale
{
	private const int SEMITONES_NUMBER = 12;
	public NoteName note;
	public ScaleType scale;
	public bool[] types = new bool[SEMITONES_NUMBER]; // note activée ou non

	/// <summary>
	/// Default constructeur
	/// </summary>
	public Scale()
	{
		SetScale(NoteName.C, ScaleType.NONE);
    }

	/// <summary>
    /// Parametized constructor : base note and its scale.
    /// </summary>
    /// <param name="note"></param>
    /// <param name="scale"></param>
	public Scale(NoteName note, ScaleType scale)
	{
		SetScale(note, scale);
	}

	/// <summary>
    /// Called everytime to change a scale.
    /// </summary>
    /// <param name="scale"></param>
	public void SetScale(NoteName name, ScaleType scale)
    {
		this.note = name;
		this.scale = scale;
		for (int i = 0; i < types.Length; i++)
        {
			types[i] = false;
        }
		switch (scale)
		{
			case ScaleType.NONE: // toutes les notes
				for (int i = 0; i < types.Length; i++)
				{
					types[i] = true;
				}
				break;
			case ScaleType.MAJOR: // gamme majeure
				types[(0 + (int)note) % SEMITONES_NUMBER] = true;
				types[(2 + (int)note) % SEMITONES_NUMBER] = true;
				types[(4 + (int)note) % SEMITONES_NUMBER] = true;
				types[(5 + (int)note) % SEMITONES_NUMBER] = true;
				types[(7 + (int)note) % SEMITONES_NUMBER] = true;
				types[(9 + (int)note) % SEMITONES_NUMBER] = true;
				types[(11 + (int)note) % SEMITONES_NUMBER] = true;
				break;
			case ScaleType.MINOR: // gamme mineure
				types[(0 + (int)note) % SEMITONES_NUMBER] = true;
				types[(2 + (int)note) % SEMITONES_NUMBER] = true;
				types[(3 + (int)note) % SEMITONES_NUMBER] = true;
				types[(5 + (int)note) % SEMITONES_NUMBER] = true;
				types[(6 + (int)note) % SEMITONES_NUMBER] = true;
				types[(8 + (int)note) % SEMITONES_NUMBER] = true;
				types[(10 + (int)note) % SEMITONES_NUMBER] = true;
				break;
		}
	}
}

/// <summary>
/// Gammes th?orique.
/// </summary>
public enum ScaleType
{
	NONE,
	MAJOR,
	MINOR,
}
