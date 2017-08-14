using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;


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