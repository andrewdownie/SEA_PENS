using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public abstract class Effects : SerializedMonoBehaviour {

    [OdinSerialize][TabGroup("Effects")]
    public List<Effect> effectList;
    [TabGroup("References")]
    public EffectiveAttributes effectiveAtts;


    public void OnValidate(){
        effectiveAtts.RecalculateEffectiveAttributes();
    }
}
