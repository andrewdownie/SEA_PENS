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
           
       stats = BaseStats.Clone(actualStats);

        //TODO: positive items should be added in the first round, and then negative items should be added (Should negative items use EffectiveStats for calculations instead of ActualStats like positive items do?)

        //TODO: for some reason, percentage modifiers aren't being added to effective stats---------------------------
		foreach(Effect e in staticEffects.effectList){
                  Add(e.GetStatsOfModifier(EffectModifierEnum.positive));
                  Subtract(e.GetStatsOfModifier(EffectModifierEnum.negative));
                  AddPostivePercentage(actualStats, e.GetStatsOfModifier(EffectModifierEnum.positivePercent)); 
                  AddNegativePercentage(actualStats, e.GetStatsOfModifier(EffectModifierEnum.negativePercent)); 
		}	


		foreach(Effect e in toggleEffects.effectList){
                  Add(e.GetStatsOfModifier(EffectModifierEnum.positive));
                  Subtract(e.GetStatsOfModifier(EffectModifierEnum.negative));
                  AddPostivePercentage(actualStats, e.GetStatsOfModifier(EffectModifierEnum.positivePercent)); 
                  AddNegativePercentage(actualStats, e.GetStatsOfModifier(EffectModifierEnum.negativePercent)); 
		}	

		foreach(Effect e in activeEffects.effectList){
                  Add(e.GetStatsOfModifier(EffectModifierEnum.positive));
                  Subtract(e.GetStatsOfModifier(EffectModifierEnum.negative));
                  AddPostivePercentage(actualStats, e.GetStatsOfModifier(EffectModifierEnum.positivePercent)); 
                  AddNegativePercentage(actualStats, e.GetStatsOfModifier(EffectModifierEnum.negativePercent)); 
		}	

		foreach(Effect e in instantEffects.effectList){
                  Add(e.GetStatsOfModifier(EffectModifierEnum.positive));
                  Subtract(e.GetStatsOfModifier(EffectModifierEnum.negative));
                  AddPostivePercentage(actualStats, e.GetStatsOfModifier(EffectModifierEnum.positivePercent)); 
                  AddNegativePercentage(actualStats, e.GetStatsOfModifier(EffectModifierEnum.negativePercent)); 
		}	
          
    }

    void Start(){
        RecalculateEffectiveStats();
    }

    void Update(){

    }

	private static Dictionary<StatsEnum, float> CalculatePercentage(ActualStats baseAmount, Dictionary<StatsEnum, float> percentageModifier01){
            Dictionary<StatsEnum, float> dict = new Dictionary<StatsEnum, float>();

            foreach(KeyValuePair<StatsEnum, float> kvp in dict){
                 if(baseAmount.ContainsKey(kvp.Key)){
                        if(percentageModifier01.ContainsKey(kvp.Key)){
                              dict[kvp.Key] = baseAmount[kvp.Key] + percentageModifier01[kvp.Key];
                        }
                        else{
                              dict.Add(kvp.Key, baseAmount[kvp.Key] + percentageModifier01[kvp.Key]);
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
