using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public AIContainer container;
    public int enemiesInLevel;
    public int[] aiTypeCounts;

    private void OnValidate()
    {
        if(container != null && container.aiTypes.Length != aiTypeCounts?.Length)
        {
            aiTypeCounts = new int[container.aiTypes.Length];
        }
    }

}
