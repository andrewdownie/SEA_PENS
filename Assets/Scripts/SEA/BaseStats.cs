using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BaseStats : MonoBehaviour {

	[TabGroup("Stats")]
	public Stats stats;		


	void OnValidate(){
		GetComponent<ActualStats>().RecalculateActualStats();	
		GetComponent<EffectiveStats>().RecalculateEffectiveStats();
	}
	
}
