using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


//NOTE: percents are in the range [0, 1]
[System.Serializable]
public class Effect {
	[TabGroup("+A")]	
	public Attributes positiveAttribues;
	[TabGroup("-A")]	
	public Attributes negativeAttribues;

	[TabGroup("+S")]	
	public Dictionary<StatsEnum, float> positiveStats;
	[TabGroup("-S")]	
	public Dictionary<StatsEnum, float> negativeStats;
	[TabGroup("+%S")]	
	public Dictionary<StatsEnum, float> positivePercentStats;
	[TabGroup("-%S")]	
	public Dictionary<StatsEnum, float> negativePercentStats;

	[TabGroup("+D")]
	public Damage positiveDamage;
	[TabGroup("-D")]
	public Damage negativeDamage;
	[TabGroup("+%D")]
	public Damage positivePercentDamage;
	[TabGroup("-%D")]
	public Damage negativePercentDamage;

}
