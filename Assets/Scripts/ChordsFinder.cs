using System.Collections.Generic;
using System.Linq;
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
            if (interval >= INTERVAL_CHORDS && Chords.currentChords.Any())
            {
                Chords chords = Chords.Recognize(Chords.currentChords);
                overlay.text = chords.ToString();
                interval = 0f;
            }
        }
    }
}