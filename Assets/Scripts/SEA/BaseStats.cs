using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BaseStats : SerializedMonoBehaviour {

	//[SerializeField][TabGroup("Stats")]
	//Stats stats;		
	[SerializeField][TabGroup("Stats")]
	protected Dictionary<StatsEnum, float> stats;


	void OnValidate(){
		GetComponent<ActualStats>().RecalculateActualStats();	
		GetComponent<EffectiveStats>().RecalculateEffectiveStats();
	}
	
	public float this[StatsEnum statsEnum]{
		get{
			if(stats.ContainsKey(statsEnum)){
				return stats[statsEnum];
			}
			return 0;
		}
		set{
			if(stats.ContainsKey(statsEnum)){
				stats[statsEnum] = value;
			}
			else{
				stats.Add(statsEnum, value);
			}
		}
	}

	public BaseStats(BaseStats baseStats){
		//DOING: clone baseStats into this, then finish redoing effective stats 
		foreach(StatsEnum se in baseStats.DictKeys){
			stats.Add(se, baseStats[se]);
		}

	}

	public BaseStats(){
		
	}

	public void Add(Dictionary<StatsEnum, float> toAdd){
		if(toAdd == null){
			return;
		}

		foreach(KeyValuePair<StatsEnum, float> kvp in toAdd){
			this[kvp.Key] += kvp.Value;
		}
	}

	public void Subtract(Dictionary<StatsEnum, float> toSub){
		if(toSub == null){
			return;
		}

		foreach(StatsEnum se in toSub.Keys){
			this[se] -= toSub[se];
		}	
	}

	public static Dictionary<StatsEnum, float> CloneStats(BaseStats statsToClone){
		Dictionary<StatsEnum, float> dict = new Dictionary<StatsEnum, float>();

		foreach(StatsEnum se in statsToClone.DictKeys){
			dict.Add(se, statsToClone[se]);
		}

		return dict;
	}

	public bool ContainsKey(StatsEnum key){
		return stats.ContainsKey(key);
	}

	public List<StatsEnum> DictKeys{
		get{return new List<StatsEnum>(stats.Keys);}
	}

}
