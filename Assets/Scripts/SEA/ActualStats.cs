using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ActualStats : BaseStats {
	[SerializeField][TabGroup("References")]
	BaseStats baseStats;
	
	[SerializeField][TabGroup("References")]
	EffectiveAttributes effectiveAttributes;


	public void RecalculateActualStats(){
		this.stats.movement_speed = baseStats.stats.movement_speed + effectiveAttributes.attributes.agility * 3f + effectiveAttributes.attributes.strength;	
		this.stats.weight_capacity = baseStats.stats.weight_capacity + effectiveAttributes.attributes.agility + effectiveAttributes.attributes.strength * 4f;
	}

}
