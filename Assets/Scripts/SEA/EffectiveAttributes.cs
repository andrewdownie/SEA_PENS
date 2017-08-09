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


		attributes = CloneDict(GetComponent<ActualAttributes>());
		
		foreach(Effect e in staticEffects.effectList){
			Add(e.GetAttributesOfModifier(EffectModifierEnum.positive));
			Subtract(e.GetAttributesOfModifier(EffectModifierEnum.negative));
		}	

		foreach(Effect e in toggleEffects.effectList){
			Add(e.GetAttributesOfModifier(EffectModifierEnum.positive));
			Subtract(e.GetAttributesOfModifier(EffectModifierEnum.negative));
		}	

		foreach(Effect e in activeEffects.effectList){
			Add(e.GetAttributesOfModifier(EffectModifierEnum.positive));
			Subtract(e.GetAttributesOfModifier(EffectModifierEnum.negative));
		}	

		foreach(Effect e in instantEffects.effectList){
			Add(e.GetAttributesOfModifier(EffectModifierEnum.positive));
			Subtract(e.GetAttributesOfModifier(EffectModifierEnum.negative));
		}	



		actualStats.RecalculateActualStats();

	}


	void Start(){
		RecalculateEffectiveAttributes();
	}

}
