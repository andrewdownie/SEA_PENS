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
		attributes = allocatedAttributes.attributes + baseAttributes.attributes;
	}



	void Start(){
		RecalculateActualAttributes();
	}





}
