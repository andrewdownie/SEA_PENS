using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EffectMetaInfo {
	[SerializeField]
	string castorID;//TODO: Change this to the network ID of the player???

	EffectIDEnum effectID;

	//TODO: what exactly does this variable need to hold?
	//		info that would uniquely identify this effect instance to prevent stacking
}



//The unique "ID" for each effect
public enum EffectIDEnum{
	haste,
	strong_back,

}