using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class ActualAttributes : BaseAttributes {
	[TabGroup("References")]
	public AllocatedAttributes allocatedAttributes;
	[TabGroup("References")]
	public BaseAttributes baseAttributes;



	public void RecalculateActualAttributes(){
		this.strength = allocatedAttributes.strength + baseAttributes.strength;
		this.agility = allocatedAttributes.agility + baseAttributes.agility;
	}

	void Start(){
		RecalculateActualAttributes();
	}





}
