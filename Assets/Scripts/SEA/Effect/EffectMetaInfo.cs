using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EffectMetaInfo {
	[SerializeField]
	string castorID;//TODO: Change this to the network ID of the player???

	EffectIDEnum effectID;


	public string CastorID{
		get{return castorID;}
	}

	public EffectIDEnum EffectID{
		get{return effectID;}
	}
}



//The unique "ID" for each effect
public enum EffectIDEnum{
	haste,
	strong_back,

}