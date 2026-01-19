using System.Collections.Generic;
using UnityEngine;
using System;
public class ComboSystem : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();   //lijst met geraakte tags
    private int scoreMultiplier = 1;

      public static event Action<int, int> OnScoreChange;
    private void Start()
    {
        BumperHit.onBumperHit += CheckForCombo;             //luisteren naar action event onBumperHit als game start
    }

        private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;             //stop met luisteren naar action event onBumperHit als scene herstart of game stopt
    }

     private void CheckForCombo(string tag, int bumperValue) {
        
        bumperTags.Add(tag);
        if (bumperTags.Count > 1) {
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;
            }
            else
            {
                scoreMultiplier = 0;
            }
        }
        ScoreManager.Instance.AddScore(bumperValue * scoreMultiplier);
        //in plaats van de score en de multiplier naar de console te sturen met debug.Log gaan we vanaf hier een Action Event Versturen en geven we de score em de multiplier mee als argument.
        OnScoreChange?.Invoke(ScoreManager.Instance.score, scoreMultiplier);
        //Verwijder de Debug.Log regel!
        //Debug.Log($"Score: {ScoreManager.Instance.score} || Multiplier: {scoreMultiplier}X");
    }
}
