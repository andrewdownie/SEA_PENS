using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;


//NOTE: percents are in the range [0, 1]
[System.Serializable]
public class Effect {
	[TabGroup("M")]
	public EffectMetaInfo metaInfo;

	[TabGroup("A")]
	Dictionary<EffectModifierEnum, Dictionary<AttributesEnum, float>> attributes;

	[TabGroup("S")]
	public Dictionary<EffectModifierEnum, Dictionary<StatsEnum, float>> stats;

	[TabGroup("D")]
	public Dictionary<EffectModifierEnum, Dictionary<DamageEnum, float>> damage;


	public Effect(){
		//NOTE: the only time the constructor is used, is during stack resolution, otherwise unity handles it through the inspector
		//TODO: create meta info... how? => since this constructor is used for a particular character, and for resovling effects, this is what the meta info should reflect
		attributes = new Dictionary<EffectModifierEnum, Dictionary<AttributesEnum, float>>();
		stats = new Dictionary<EffectModifierEnum, Dictionary<StatsEnum, float>>();
		damage = new Dictionary<EffectModifierEnum, Dictionary<DamageEnum, float>>();


		//TODO: do I need attributes for when resolving effects?
		foreach(EffectModifierEnum eme in Enum.GetValues(typeof(EffectModifierEnum))){
			stats.Add(eme, new Dictionary<StatsEnum, float>());	
			damage.Add(eme, new Dictionary<DamageEnum, float>());	
		}

	}


	public Dictionary<AttributesEnum, float> GetAttributesOfModifier(EffectModifierEnum modifierEnum){
		if(attributes != null && attributes.ContainsKey(modifierEnum)){
			return attributes[modifierEnum];
		}

		return new Dictionary<AttributesEnum, float>();
	}


	public Dictionary<StatsEnum, float> GetStatsOfModifier(EffectModifierEnum modifierEnum){

		if(stats != null && stats.ContainsKey(modifierEnum)){
			return stats[modifierEnum];
		}

		return new Dictionary<StatsEnum, float>();
	}


	//_Stack resolves effects for a single effect type and effect modifier combo
	//	four effect-types and four effect-modifiers, for 16 combos that this function will need to be called for... 
	public static List<Effect> StackResolveEffects(List<Effect> effectList, EffectModifierEnum effectModifier){
		Debug.Log("Stack Resolve Effects");
		if(effectList == null){
			Debug.Log("effect list was null");
		}

		//TODO: the goal of "StackResolveEffects" is to have a single effect of each ID 
		List<Effect> resolvedEffects = new List<Effect>();

        foreach(EffectIDEnum effectID in Enum.GetValues(typeof(EffectIDEnum))){
            List<Effect> sub = EffectsOfID(effectList, effectID);

            Effect appliedEffect = new Effect();

            foreach(Effect e in sub){
				Debug.Log("stack resolve effects inner loop");
				//appliedEffect = StackResolveDamage(appliedEffect, e, effectModifier);
				appliedEffect = StackResolveStats(appliedEffect, e, effectModifier);
            }

            resolvedEffects.Add(appliedEffect);
        }

		return resolvedEffects;
	}

    private static List<Effect> EffectsOfID(List<Effect> parentList, EffectIDEnum effectID){
        List<Effect> subList = new List<Effect>();

        foreach(Effect e in parentList){
            if(e.metaInfo.EffectID == effectID){
                subList.Add(e);
            }
        }

        return subList;
    }

	private static Effect StackResolveDamage(Effect effectToAddTo, Effect effectToAddFrom, EffectModifierEnum effectModifier){
		if(effectToAddTo.damage.ContainsKey(effectModifier) == false){
			Debug.Log("List does not contain key: " + effectModifier);
			return effectToAddTo;
		}


		Debug.Log("Length of list is: " + effectToAddTo.damage[effectModifier].Count);

		foreach(KeyValuePair<DamageEnum, float> kvp in effectToAddTo.damage[effectModifier]){
			effectToAddTo.damage[effectModifier][kvp.Key] += kvp.Value;
			Debug.Log(kvp.Key + ": was the key modified");
		}


		//linerally add values
		return effectToAddTo;
	}

	private static Effect StackResolveStats(Effect effectToApplyMaxTo, Effect effectToAddFrom, EffectModifierEnum effectModifier){//TODO: the actual list of stats needs to be passed in as well...
		Debug.Log("StackResolveStats");
		if(effectToAddFrom.damage.ContainsKey(effectModifier) == false){
			return effectToApplyMaxTo;
		}

		Debug.Log("StackResolveStats after precondition check, list length: " + effectToAddFrom.stats[effectModifier].Count);//TODO: this shows as having a count of 3, yet the loop below doesn't run a single time

		foreach(KeyValuePair<StatsEnum, float> kvp in effectToAddFrom.stats[effectModifier]){
			Debug.Log("StackResolveStats inner loop");

			float current = 0;
			if(effectToApplyMaxTo.stats[effectModifier].ContainsKey(kvp.Key)){
				current = effectToApplyMaxTo.stats[effectModifier][kvp.Key];
			}

			if(current < kvp.Value){
				effectToApplyMaxTo.stats[effectModifier][kvp.Key] = kvp.Value;

				Debug.Log("StackResolveStats inner if");
			}
		}

		//only keep the largest values
		return effectToApplyMaxTo;
	}


}


public enum EffectModifierEnum{
	positive,
	negative,
	positivePercent,
	negativePercent,
}


public enum EffectPieceEnum{
	meta,
	attributes,
	stats,
	damage
}