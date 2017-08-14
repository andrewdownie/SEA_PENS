using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BaseAttributes : MonoBehaviour {
	[SerializeField][TabGroup("Attributes")]
	protected Dictionary<AttributesEnum, float> attributes;
	[SerializeField][TabGroup("References")]
	protected ActualStats actualStats;


	void OnValidate(){
		GetComponent<ActualAttributes>().RecalculateActualAttributes();
		GetComponent<EffectiveAttributes>().RecalculateEffectiveAttributes();
		actualStats.RecalculateActualStats();
	}
	
	public float this[AttributesEnum attEnum]{
		get{
			if(attributes.ContainsKey(attEnum)){
				return attributes[attEnum];
			}
			return 0;
		}

		set{
			if(attributes.ContainsKey(attEnum)){
				attributes[attEnum] = value;
			}
			else{
				attributes.Add(attEnum, value);
			}
		}
	}
	public void Add(BaseAttributes toAdd){
		if(toAdd == null){
			return;
		}

		foreach(AttributesEnum ae in toAdd.DictKeys){
			this[ae] += toAdd[ae];
		}
	}
	public void Add(Dictionary<AttributesEnum, float> toAdd){
		if(toAdd == null){
			return;
		}

		foreach(KeyValuePair<AttributesEnum, float> kvp in toAdd){
			this[kvp.Key] += kvp.Value;
		}
	}

	public void Subtract(BaseAttributes toSub){
		if(toSub == null){
			return;
		}

		foreach(AttributesEnum ae in toSub.DictKeys){
			this[ae] -= toSub[ae];
		}
	}
	public void Subtract(Dictionary<AttributesEnum, float> toAdd){
		if(toAdd == null){
			return;
		}

		foreach(KeyValuePair<AttributesEnum, float> kvp in toAdd){
			this[kvp.Key] -= kvp.Value;
		}
	}


	public static Dictionary<AttributesEnum, float> CloneDict(BaseAttributes attsToClone){
		Dictionary<AttributesEnum, float> dict = new Dictionary<AttributesEnum, float>();

		if(attsToClone == null){
			return dict;
		}

		foreach(AttributesEnum se in attsToClone.DictKeys){
			dict.Add(se, attsToClone[se]);
		}

		return dict;
	}

	public bool ContainsKey(AttributesEnum key){
		return attributes.ContainsKey(key);
	}

	public List<AttributesEnum> DictKeys{
		get{
			if(attributes == null){
				return new List<AttributesEnum>();
			}

			return new List<AttributesEnum>(attributes.Keys);
		}
	}
}
