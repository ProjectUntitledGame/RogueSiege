using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    [Header("ComponentRef")]
    private Transform target;
    private NavMeshAgent agent;
    [Header("Params")]
    
    public float speed = 40;
    public float sightRadius = 10;
    [Range(0, 360)]
    public int angle = 5;
    public int maxDistance = 8;
    public bool seen;
    public LayerMask targetMask;
    public float moveToRad = 15f;
    public float timer = 1.5f;

    [Header("Target")]
    private GameObject player;

    private void Start()
    {
        StartCoroutine(Search());

        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        target = player.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= sightRadius)
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                //attack
                FaceTarget();
            }
        }
    }
 
    private IEnumerator Search()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfView();
        }
    }

    private void FieldOfView()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, sightRadius, targetMask);
        if (targets.Length != 0)
        {

            Transform target = targets[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                Debug.Log("Enter");
                float distance = Vector3.Distance(target.position, transform.position);
                if (distance < maxDistance)
                {
                    seen = true;
                    Debug.Log("Seen");
                }
            }
            else
            {
                Debug.Log("CantPass");
                seen = false;
            }
        }
    }



    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 7.5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, sightRadius);
        //Gizmos.DrawWireSphere(transform.position, moveToRad);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightRadius);
        Gizmos.DrawLine(transform.position, Vector3.forward);
    }
}

[CustomEditor(typeof(BaseEnemy))]
public class DrawWireArc : Editor
{
    private void OnSceneGUI()
    {
        Handles.color = Color.blue;
        BaseEnemy myObj = (BaseEnemy)target;
        Handles.DrawWireDisc(myObj.transform.position, new Vector3(0, 1, 0), -myObj.sightRadius * 1);
        myObj.sightRadius = (float)Handles.ScaleValueHandle(myObj.sightRadius, myObj.transform.position + myObj.transform.forward * myObj.sightRadius, myObj.transform.rotation, 5, Handles.ConeHandleCap, 5);
        Handles.DrawWireDisc(myObj.transform.position, new Vector3(0, 1, 0), myObj.moveToRad);
        myObj.moveToRad = (float)Handles.ScaleValueHandle(myObj.moveToRad, myObj.transform.position + myObj.transform.forward * myObj.moveToRad, myObj.transform.rotation, 5, Handles.ConeHandleCap, 5);
    }
}

