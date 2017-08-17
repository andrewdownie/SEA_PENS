using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

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


    //TODO: this is for testing
    [SerializeField][TabGroup("Resolved Effects")]
    List<Effect> displayResolvedEffects;
    
    
    public void RecalculateEffectiveStats(){
        Debug.Log("Recalculate Effective Stats");
           
       stats = BaseStats.Clone(actualStats);



        //TODO: positive items should be added in the first round, and then negative items should be added (Should negative items use EffectiveStats for calculations instead of ActualStats like positive items do?)

        //TODO: for some reason, percentage modifiers aren't being added to effective stats---------------------------
		/*foreach(Effect e in staticEffects.effectList){
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
		}	*/


        //SOFAR: each type and modifier is gone through
       List<Effect> resolvedEffects = new List<Effect>();//maybe a seperate list for each effect type, that way stats first, then damage?

//            Debug.Log("inner most loop");
        resolvedEffects.AddRange(Effect.StackResolveEffects(staticEffects.effectList));
        //Debug.Log("current count is: " + resolvedEffects.Count);
        //TODO: how to view resolved effects easily in unity?
        displayResolvedEffects = resolvedEffects;
        ApplyEffectiveStats(resolvedEffects);



        return;// //////////////////////////////////////////////////////////////////////////////////////


        resolvedEffects = new List<Effect>();
        resolvedEffects.AddRange(Effect.StackResolveEffects(toggleEffects.effectList));
        //TODO: need to actually apply the effects after each group, how?


        resolvedEffects = new List<Effect>();
        resolvedEffects.AddRange(Effect.StackResolveEffects(activeEffects.effectList));
        //TODO: need to actually apply the effects after each group, how?


        resolvedEffects = new List<Effect>();
        resolvedEffects.AddRange(Effect.StackResolveEffects(instantEffects.effectList));
        //TODO: need to actually apply the effects after each group, how?
          

    }


    void Start(){
        RecalculateEffectiveStats();
    }

    void Update(){

    }

    void ApplyEffectiveStats(List<Effect> appliedEffects){
        //what the fuck needs to happen here
        //  go through damage, "apply" it
        //  go through stats, "apply" them

        // /////////////////////////////////////////////////////////////////////// how tho
        // would damage apply to current stats? ... yes
        //  so that would mean that I need a ref to current stats... oh boi
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
