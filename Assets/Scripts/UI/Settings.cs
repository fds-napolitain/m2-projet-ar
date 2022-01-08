using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class Settings : MonoBehaviour
    {
        public InputField settingsTempo;
        public InputField settingsQuantization;
        public InputField settingsScale;

        private void ValueChangeCheck()
        {
            if (settingsTempo.text.Length != 0)
            {
                Game.TEMPO = int.Parse(settingsTempo.text);
                settingsTempo.placeholder.GetComponent<Text>().text = "Tempo: " + settingsTempo.text;
                settingsTempo.text = "";
                Debug.Log(Game.TEMPO);
            }

            if (settingsQuantization.text.Length != 0)
            {
                Quantization.SetQuantization(settingsQuantization.text);
                settingsQuantization.placeholder.GetComponent<Text>().text = "Quantization: " + settingsQuantization.text;
                settingsQuantization.text = "";
                Debug.Log(Game.QUANTIZATION);
            }

            if (settingsScale.text.Length != 0)
            {
                Game.scale.SetScale(settingsScale.text);
                settingsScale.placeholder.GetComponent<Text>().text = "Scale: " + settingsScale.text;
                settingsScale.text = "";
                Debug.Log(Game.scale.ToString());
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ValueChangeCheck();
            }
        }
    }
}