using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: when a player levels up, they have to press a button labeled "level up". Pressing this button could auto
//		allocate atts for the player(based on their class / race / w/e), as well as make available unspent atts for them to allocate 
//		(their race auto allocates one att every level, their class auto allocates one att every level, and then they are given 3 atts to allocate?)
public class Experience : MonoBehaviour {
	//The amount of experience required to go from level one to level two
	private static readonly int BASE_EXPERIENCE_REQUIRED = 1000;
	private static readonly float LEVEL_EXPERIENCE_INCREASE_MULTIPLIER = 1.35f;

	[SerializeField]
	private float experienceRequired;	
	[SerializeField]
	private float currentExperience;
	[SerializeField]
	private int unallocatedAttributePoints;
	[SerializeField]
	private int level = 1;


	public bool TryLevelUp(){
		if(currentExperience >= experienceRequired){
			currentExperience -= experienceRequired;
			level++;
			CalcExperienceRequired();
			unallocatedAttributePoints += 3;
			//TODO: how will auto allocated points be decided on what they should auto allocate on?
			//TODO: do I need a class script and a race script for this script to reference?
			//TODO: maybe the class / race could be passed as parameters to the level up function?

			return true;
		}
		return false;
	}

	public void AddExperience(float amount){
		currentExperience += amount;

		TryLevelUp();
	}


	private void CalcExperienceRequired(){
		experienceRequired = Mathf.Pow(LEVEL_EXPERIENCE_INCREASE_MULTIPLIER, level);
	}



	void Start(){
		CalcExperienceRequired();
	}

}
