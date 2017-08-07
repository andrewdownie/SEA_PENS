using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Effects : MonoBehaviour {
    //TODO: turn effects into a dictionary of lists
    //      Dictionary<EffectTypeEnum, Dictionary<(WAT GOES HERE, i want differnt enums to, but), float>>

    [TabGroup("Effects")]
    public List<Effect> effectList;
    [TabGroup("References")]
    public EffectiveAttributes effectiveAtts;


    public void OnValidate(){
        effectiveAtts.RecalculateEffectiveAttributes();
    }
}
