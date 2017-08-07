using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage {
	//TODO: add a new kind of stat called: current stat,
	//		the only way current stats can be affected by effects is through damage
	//TODO: make damage dictionary based, like stats
	[SerializeField]
	float sharpDamage, fireDamage, iceDamage, poisonDamage, arcaneDamage;
}
