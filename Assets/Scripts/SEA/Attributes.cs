using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attributes {
	
	public float level, strength, agility;


	public Attributes (Attributes toCopy){
		level = toCopy.level;
		strength = toCopy.strength;
		agility = toCopy.agility;
	}
	public Attributes(){

	}


	
	public static Attributes operator +(Attributes a, Attributes b){
		Attributes newAtt = new Attributes();

		newAtt.level = a.level + b.level;
		newAtt.strength = a.strength + b.strength;
		newAtt.agility = a.agility + b.agility;

		return newAtt;	
	}

	public static Attributes operator -(Attributes a, Attributes b){
		Attributes newAtt = new Attributes();

		newAtt.level = a.level - b.level;
		newAtt.strength = a.strength - b.strength;
		newAtt.agility = a.agility - b.agility;

		return newAtt;	
	}


}
