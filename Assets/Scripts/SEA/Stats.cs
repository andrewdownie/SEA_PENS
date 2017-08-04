using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats {
	[SerializeField]
	public float movement_speed, weight_capacity;


	public Stats(Stats toCopy){
		movement_speed = toCopy.movement_speed;
		weight_capacity = toCopy.weight_capacity;
	}
	public Stats(){

	}


	public static Stats operator +(Stats a, Stats b){
		Stats newStats = new Stats();

		newStats.movement_speed = a.movement_speed + b.movement_speed;
		newStats.weight_capacity = a.weight_capacity + b.weight_capacity;

		return newStats;
	}	

	public static Stats operator -(Stats a, Stats b){
		Stats newStats = new Stats();

		newStats.movement_speed = a.movement_speed - b.movement_speed;
		newStats.weight_capacity = a.weight_capacity - b.weight_capacity;

		return newStats;
	}	


}
