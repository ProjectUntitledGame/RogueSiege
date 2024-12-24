using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "NewAI", menuName = "AI")]
    public class AICreation : ScriptableObject
    {
        [Header("Initialise")]
        [SerializeField] private Mesh model;
        [SerializeField] private string enemyName;
        [Header("MovementParams")]
        [SerializeField] private float speed;
        [Header("AttackParams")]
        [SerializeField] private bool melee;
        
        public void CreateEnemy(Transform spawnPoint)
        {
            GameObject enemy = new GameObject(enemyName)
            {
                transform =
                {
                    position = spawnPoint.position
                }
            };
            MeshRenderer tempMeshRenderer = enemy.AddComponent<MeshRenderer>();
            MeshFilter tempMeshFilter = enemy.AddComponent<MeshFilter>();
            tempMeshFilter.mesh = model;
            CapsuleCollider collider = enemy.AddComponent<CapsuleCollider>();
            collider.height = 2;
            AIController tempController = enemy.AddComponent<AIController>();
            tempController.aiSO = this;
        }
    }
}
