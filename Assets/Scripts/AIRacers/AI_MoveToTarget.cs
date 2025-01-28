using UnityEngine;

public class AI_MoveToTarget : MonoBehaviour
{
    [SerializeField] public float speed = 45f;
    [SerializeField] public Transform[] targetPoints;

    [SerializeField] private float targetPositionRadius = 1f;

    private Transform curTarget;
    private int curPointIndex;

    private bool canDrive;

    private void Start()
    {
        curPointIndex = 0;
        curTarget = targetPoints[curPointIndex];
    }

    private void Update()
    {
        MoveToTarget();

        CheckCurrentTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, curTarget.position, speed * Time.deltaTime);
        transform.LookAt(curTarget.position);
    }

    private void CheckCurrentTarget()
    {
        if (Vector3.Distance(transform.position, curTarget.position) <= targetPositionRadius)
        {
            if (curPointIndex > targetPoints.Length - 1)
            {
                //curPointIndex = 0;//for looping
                //we want to stop

            }

            curPointIndex++;
            curTarget = targetPoints[curPointIndex];
        }
    }
}
