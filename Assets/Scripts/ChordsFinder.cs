using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChordsFinder : MonoBehaviour
    {
        private const float INTERVAL_CHORDS = 0.1f;
        private UnityEngine.UI.Text overlay;
        private float interval = 0f;

        // Use this for initialization
        void Start()
        {
            overlay = GetComponent<UnityEngine.UI.Text>();
        }

        // Update is called once per frame
        void Update()
        {
            interval += Time.deltaTime;
            if (interval >= INTERVAL_CHORDS)
            {
                Chords chords = Chords.Recognize(Chords.currentChords);
                overlay.text = chords.ToString();
                string tmp = "";
                for (int i = 0; i < Chords.currentChords.Count; i++)
                {
                    tmp += Chords.currentChords[i].ToString();
                }
                Debug.Log(tmp);
                interval = 0f;
            }
        }
    }
}