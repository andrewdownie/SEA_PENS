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
		attributes = CloneDict(allocatedAttributes);
		Add(baseAttributes);
	}



	void Start(){
		RecalculateActualAttributes();
	}





}
