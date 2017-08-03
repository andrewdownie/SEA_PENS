using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BaseStats : MonoBehaviour {

	[SerializeField][TabGroup("Stats")]
	public float movement_speed, weight_capacity;
	
}
