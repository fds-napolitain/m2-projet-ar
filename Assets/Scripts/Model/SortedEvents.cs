using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cr�ation de 0 d'une sorted list.
/// </summary>
public class SortedEvents
{
    private List<Event> events;
    private int fastIndex = 0;

    /// <summary>
    /// Initialise une sorted list d'events custom.
    /// </summary>
    public SortedEvents()
    {
        events = new List<Event>();
    }

    /// <summary>
    /// Ajoute un event dans la liste de mani�re tri�e par ordre de attack+id
    /// </summary>
    /// <param name="item"></param>
    public void AddEvent(Event item)
    {
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].GetCurrentTime() > item.GetCurrentTime()) // ne peut �tre �gal
            {
                events.Insert(i, item); // ins�re l'item � sa place
                return;
            }
        }
        events.Add(item); // ajoute l'item si la liste est vide
    }

    /// <summary>
    /// Supprime un �l�ment de liste.
    /// </summary>
    /// <param name="item"></param>
    public void RemoveEvent(Event item)
    {
        events.Remove(item);
    }

    /// <summary>
    /// Iteration rapide par index en cache de la liste des �v�nements.
    /// </summary>
    /// <returns></returns>
    public List<Event> GetEvents()
    {
        List<Event> result = new List<Event>();
        while (fastIndex < events.Count && events[fastIndex].GetCurrentTime() < Game.CurrentTime) // tant que l'�v�nement est inf�rieur au temps 
        {
            if (events[fastIndex].GetCurrentTime() > Game.CurrentTime - Game.DeltaTime) // si l'�v�nement est sup�rieur au temps - interval frame
            {
                result.Add(events[fastIndex]); // ajoute �v�nement
            }
            fastIndex++;
        }
        return result;
    }

    /// <summary>
    /// Comparaison entre deux events :
    /// - 1 si x > y
    /// - -1 si x < y
    /// - 0 sinon
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int Compare(Event x, Event y)
    {
        if (x.GetCurrentTime() < y.GetCurrentTime())
        {
            return -1;
        }
        else if (x.GetCurrentTime() > y.GetCurrentTime())
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
