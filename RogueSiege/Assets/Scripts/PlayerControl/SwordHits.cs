using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHits : MonoBehaviour
{
    public List<BaseEnemy> enemiesInRange;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BaseEnemy>() != null)
        {
            enemiesInRange.Add(other.gameObject.GetComponent<BaseEnemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BaseEnemy>() != null)
        {
            enemiesInRange.Remove(other.gameObject.GetComponent<BaseEnemy>());
        }
    }
}
