using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EffectiveStats : BaseStats {
    
    [SerializeField][TabGroup("References")]
    ActualStats actualStats;
    [SerializeField][TabGroup("References")]
    InstantEffects instantEffects;
    [SerializeField][TabGroup("References")]
    ActiveEffects activeEffects;
    [SerializeField][TabGroup("References")]
    ToggleEffects toggleEffects;
    [SerializeField][TabGroup("References")]
    StaticEffects staticEffects;
    
    

}
