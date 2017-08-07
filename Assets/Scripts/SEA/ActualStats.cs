using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ActualStats : BaseStats {
	[SerializeField][TabGroup("References")]
	BaseStats baseStats;
	
	[SerializeField][TabGroup("References")]
	EffectiveAttributes effectiveAttributes;
	[SerializeField][TabGroup("References")]
	EffectiveStats effectiveStats;


	public void RecalculateActualStats(){
		this[StatsEnum.movement_speed] = baseStats[StatsEnum.movement_speed] + effectiveAttributes.attributes.agility * 3f + effectiveAttributes.attributes.strength;	
		this[StatsEnum.weight_capacity] = baseStats[StatsEnum.weight_capacity] + effectiveAttributes.attributes.agility + effectiveAttributes.attributes.strength * 4f;


		effectiveStats.RecalculateEffectiveStats();	
	}

}
