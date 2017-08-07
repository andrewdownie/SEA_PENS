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
           
       stats = BaseStats.CloneStats(actualStats);

        //TODO: positive items should be added in the first round, and then negative items should be added (Should negative items use EffectiveStats for calculations instead of ActualStats like positive items do?)

        //TODO: for some reason, effects aren't being applied to effective stats---------------------------
		foreach(Effect e in staticEffects.effectList){
                  Add(e.positiveStats);
                  Subtract(e.negativeStats);
                  AddPostivePercentage(actualStats, e.positivePercentStats); 
                  AddNegativePercentage(actualStats, e.negativePercentStats); 
		}	


		foreach(Effect e in toggleEffects.effectList){
                  Add(e.positiveStats);
                  Subtract(e.negativeStats);
                  AddPostivePercentage(actualStats, e.positivePercentStats); 
                  AddNegativePercentage(actualStats, e.negativePercentStats); 
		}	

		foreach(Effect e in activeEffects.effectList){
                  Add(e.positiveStats);
                  Subtract(e.negativeStats);
                  AddPostivePercentage(actualStats, e.positivePercentStats); 
                  AddNegativePercentage(actualStats, e.negativePercentStats); 
		}	

		foreach(Effect e in instantEffects.effectList){
                  Add(e.positiveStats);
                  Subtract(e.negativeStats);
                  AddPostivePercentage(actualStats, e.positivePercentStats); 
                  AddNegativePercentage(actualStats, e.negativePercentStats); 
		}	
            
    }

    void Start(){
        RecalculateEffectiveStats();
    }

    void Update(){

    }

	private static Dictionary<StatsEnum, float> CalculatePercentage(ActualStats percentageBase, Dictionary<StatsEnum, float> percentageModifier){
            Dictionary<StatsEnum, float> dict = new Dictionary<StatsEnum, float>();

            foreach(KeyValuePair<StatsEnum, float> kvp in dict){
                 if(percentageBase.ContainsKey(kvp.Key)){
                        if(percentageModifier.ContainsKey(kvp.Key)){
                              dict.Add(kvp.Key, percentageBase[kvp.Key] + percentageModifier[kvp.Key]);
                        }
                        else{
                              dict.Add(kvp.Key, percentageBase[kvp.Key] + percentageModifier[kvp.Key]);
                        }
                 } 
            }

		return dict;
	}

	public void AddPostivePercentage(ActualStats percentageBase, Dictionary<StatsEnum, float> percentageModifier){
        Add(CalculatePercentage(percentageBase, percentageModifier));
	}

	public void AddNegativePercentage(ActualStats percentageBase, Dictionary<StatsEnum, float> percentageModifier){
        Subtract(CalculatePercentage(percentageBase, percentageModifier));
	}

}
