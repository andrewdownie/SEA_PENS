using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BaseAttributes : MonoBehaviour {
	[SerializeField][TabGroup("Attributes")]
	public float strength, agility;


	void OnValidate(){
		ActualAttributes aa = GetComponent<ActualAttributes>();
		if(aa != null){
			aa.RecalculateActualAttributes();
		}
	}
	

}
