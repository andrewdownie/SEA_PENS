using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


//NOTE: percents are in the range [0, 1]
[System.Serializable]
public class Effect {
	[TabGroup("+ Atts")]	
	public Attributes positiveAttribues;
	[TabGroup("- Atts")]	
	public Attributes negativeAttribues;
	[TabGroup("+ Stats")]	
	public Stats positiveStats;
	[TabGroup("- Stats")]	
	public Stats negativeStats;
	[TabGroup("+ %Stats")]	
	public Stats positivePercentStats;
	[TabGroup("- %Stats")]	
	public Stats negativePercentStats;
}
