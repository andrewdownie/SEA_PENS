using System.Collections.Generic;
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

		//TODO: the goal of "StackResolveEffects" is to have a single effect of each ID 
		List<Effect> resolvedEffects = new List<Effect>();

        foreach(EffectIDEnum effectID in Enum.GetValues(typeof(EffectIDEnum))){
            List<Effect> sub = EffectsOfID(effectList, effectID);

            Effect appliedEffect = new Effect();

            foreach(Effect e in sub){
				appliedEffect = StackResolveDamage(appliedEffect, effectModifier);
				appliedEffect = StackResolveStats(appliedEffect, effectModifier);
            }

            resolvedEffects.Add(appliedEffect);
        }

		return resolvedEffects;
	}

    private static List<Effect> EffectsOfID(List<Effect> parentList, EffectIDEnum effectID){
        List<Effect> sub = new List<Effect>();

        foreach(Effect e in parentList){
            if(e.metaInfo.EffectID == effectID){
                sub.Add(e);
            }
        }

        return sub;
    }

	private static Effect StackResolveDamage(Effect effectToAddTo, EffectModifierEnum effectModifier){
		foreach(KeyValuePair<DamageEnum, float> kvp in effectToAddTo.damage[effectModifier]){
			effectToAddTo.damage[effectModifier][kvp.Key] += kvp.Value;
		}


		//linerally add values
		return effectToAddTo;
	}

	private static Effect StackResolveStats(Effect effectToApplyMaxTo, EffectModifierEnum effectModifier){
		foreach(KeyValuePair<StatsEnum, float> kvp in effectToApplyMaxTo.stats[effectModifier]){
			float current = effectToApplyMaxTo.stats[effectModifier][kvp.Key];
			if(current < kvp.Value){
				effectToApplyMaxTo.stats[effectModifier][kvp.Key] = kvp.Value;
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