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

        public void Start()
        {
            //Begin the GameLoop Coroutine on start
            StartCoroutine(GameLoop());
        }
         
        //This is used to represent the Update() of the game. 
        //Using a Coroutine in Unity is useful for GameLoops as it gives you more agency over the Game. 
        //You can Start and Stop it as needed, and when the Coroutine Exits and Starts again, it begins from where it left off.
        //Rather than starting all over from the beginning. I frequently use nested Coroutines for game Update States.
        //i.e. RoundStarting(), RoundRunning(), RoundEnding()
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