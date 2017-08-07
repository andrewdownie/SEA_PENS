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
	[TabGroup("+A")]	
	public Attributes positiveAttribues;
	[TabGroup("-A")]	
	public Attributes negativeAttribues;

	[OdinSerialize][TabGroup("+S")]	
	public Dictionary<StatsEnum, float> positiveStats;
	[TabGroup("-S")]	
	public Dictionary<StatsEnum, float> negativeStats;
	[TabGroup("+%S")]	
	public Dictionary<StatsEnum, float> positivePercentStats;
	[TabGroup("-%S")]	
	public Dictionary<StatsEnum, float> negativePercentStats;

	[TabGroup("+D")]
	public Dictionary<DamageEnum, float> positiveDamage;
	[TabGroup("-D")]
	public Dictionary<DamageEnum, float> negativeDamage;
	[TabGroup("+%D")]
	public Dictionary<DamageEnum, float> positivePercentDamage;
	[TabGroup("-%D")]
	public Dictionary<DamageEnum, float> negativePercentDamage;

}
