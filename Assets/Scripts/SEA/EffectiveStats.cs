using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EffectiveStats : BaseStats {

    [SerializeField][TabGroup("References")]
    ActualStats actualStats;
    
    [SerializeField][TabGroup("References")]
    InstantEffects instantEffects;
    [SerializeField][TabGroup("References")]
    ActiveEffects activeEffects;
    [SerializeField][TabGroup("References")]
    ToggleEffects toggleEffects;
    [SerializeField][TabGroup("References")]
    StaticEffects staticEffects;
    
    
    public void RecalculateEffectiveStats(){
       stats = new Stats(actualStats.stats); 

        //TODO: positive items should be added in the first round, and then negative items should be added (Should negative items use EffectiveStats for calculations instead of ActualStats like positive items do?)

		foreach(Effect e in staticEffects.effectList){
            stats = stats + e.positiveStats;
            stats = stats - e.negativeStats;
            AddPostivePercentage(actualStats, e.positivePercentStats); 
            AddNegativePercentage(actualStats, e.negativePercentStats); 
		}	


		foreach(Effect e in toggleEffects.effectList){
            stats = stats + e.positiveStats;
            stats = stats - e.negativeStats;
            AddPostivePercentage(actualStats, e.positivePercentStats); 
            AddNegativePercentage(actualStats, e.negativePercentStats); 
		}	

		foreach(Effect e in activeEffects.effectList){
            stats = stats + e.positiveStats;
            stats = stats - e.negativeStats;
            AddPostivePercentage(actualStats, e.positivePercentStats); 
            AddNegativePercentage(actualStats, e.negativePercentStats); 
		}	

		foreach(Effect e in instantEffects.effectList){
            stats = stats + e.positiveStats;
            stats = stats - e.negativeStats;
            AddPostivePercentage(actualStats, e.positivePercentStats); 
            AddNegativePercentage(actualStats, e.negativePercentStats); 
		}	
    }

    void Start(){
        RecalculateEffectiveStats();
    }

    void Update(){
        Debug.Log(stats.movement_speed);
    }

	private static Stats CalculatePercentage(ActualStats percentageBase, Stats percentageModifier){
		Stats newStats = new Stats();	

		newStats.movement_speed = percentageBase.stats.movement_speed * percentageModifier.movement_speed;
		newStats.weight_capacity = percentageBase.stats.weight_capacity * percentageModifier.weight_capacity;


		return newStats;
	}

	public void AddPostivePercentage(ActualStats percentageBase, Stats percentageModifier){
        stats = stats + CalculatePercentage(percentageBase, percentageModifier);
	}

	public void AddNegativePercentage(ActualStats percentageBase, Stats percentageModifier){
        stats = stats - CalculatePercentage(percentageBase, percentageModifier);
	}

}
