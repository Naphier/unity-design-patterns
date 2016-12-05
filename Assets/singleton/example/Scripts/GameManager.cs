using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NG.Patterns.Structure.Singleton
{
    //GameManagers, InputManagers and anything else you want to only exist once make great Singletons.
    public class GameManager : Singleton<GameManager>
    {
        public Text DebugText;

        private string _debugMessage = "GameManager Is Running";

        private int _numElipses = 0;
        private string _elipses = ".";

        // Use this for initialization
        public override void Start()
        {
            base.Start();
            StartCoroutine(GameLoop());
        }

        //This is used to represent the Update() of the game.
        IEnumerator GameLoop()
        {
            while(true)
            {
                
                DebugText.text = _debugMessage + GetElipses();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private string GetElipses()
        {
            string text = "";
            for (int i = 0; i < _numElipses; i++)
            {
                text += _elipses;
            }
            _numElipses++;
            if (_numElipses > 3)
                _numElipses = 0;
            return text;
        }
    }
}