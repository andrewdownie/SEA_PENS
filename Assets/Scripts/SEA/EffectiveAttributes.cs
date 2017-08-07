using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EffectiveAttributes : BaseAttributes {
	[SerializeField][TabGroup("References")]
	StaticEffects staticEffects;	

	[SerializeField][TabGroup("References")]
	ActiveEffects activeEffects;	

	[SerializeField][TabGroup("References")]
	InstantEffects instantEffects;	

	[SerializeField][TabGroup("References")]
	ToggleEffects toggleEffects;	
	

	public void RecalculateEffectiveAttributes(){


		attributes = new Attributes(GetComponent<ActualAttributes>().attributes);
		
		foreach(Effect e in staticEffects.effectList){
			attributes += e.positiveAttribues;
			attributes -= e.negativeAttribues;	
		}	
		foreach(Effect e in toggleEffects.effectList){
			attributes += e.positiveAttribues;
			attributes -= e.negativeAttribues;	
		}	
		foreach(Effect e in activeEffects.effectList){
			attributes += e.positiveAttribues;
			attributes -= e.negativeAttribues;	
		}	
		foreach(Effect e in instantEffects.effectList){
			attributes += e.positiveAttribues;
			attributes -= e.negativeAttribues;	
		}	



		actualStats.RecalculateActualStats();

	}


	void Start(){
		RecalculateEffectiveAttributes();
	}

}
