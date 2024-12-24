using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "enemyTypeContainer", menuName = "AiContainer" )]
public class AIContainer : ScriptableObject
{
    public ScriptableObject[] aiTypes;
}
