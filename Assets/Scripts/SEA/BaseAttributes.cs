using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BaseAttributes : MonoBehaviour {
	[TabGroup("Attributes")]
	public Attributes attributes;
	[SerializeField][TabGroup("References")]
	ActualStats actualStats;


	void OnValidate(){
		GetComponent<ActualAttributes>().RecalculateActualAttributes();
		GetComponent<EffectiveAttributes>().RecalculateEffectiveAttributes();
		actualStats.RecalculateActualStats();
	}
	

}
