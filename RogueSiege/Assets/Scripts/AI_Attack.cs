using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Attack : MonoBehaviour
{
    public List<PlayerController> playerInRange;
    [SerializeField] Collider hitBox;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseEnemy>() != null)
        {
            playerInRange.Add(other.gameObject.GetComponent<PlayerController>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BaseEnemy>() != null)
        {
            playerInRange.Remove(other.gameObject.GetComponent<PlayerController>());
        }
    }
}
