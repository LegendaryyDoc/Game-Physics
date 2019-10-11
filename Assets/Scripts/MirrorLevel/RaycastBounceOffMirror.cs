using UnityEngine;

/*  Get a RayCast(Light) to bounce off of a Mirror and keep doing that until the light doesn't hit a Mirror  */

public class RaycastBounceOffMirror : MonoBehaviour
{
    public int maxReflections = 100;

    private LineRenderer lr;
    private int numberOfPositions;
    private bool isActive = true;

    private void Start()
    {
        numberOfPositions = 2;
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        while (isActive)
        {
            numberOfPositions++;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, hit.point);

                if (hit.collider.transform.CompareTag("Mirror"))
                {
                    lr.positionCount = numberOfPositions;

                    Vector3[] arrPos = new Vector3[numberOfPositions];
                    lr.GetPositions(arrPos);

                    Vector3 pos = Vector3.Reflect(hit.point, hit.normal);
                    lr.SetPosition(arrPos.Length - 1, pos);
                }
            }
            else
            {
                isActive = false;
            }

            if(numberOfPositions > maxReflections)
            {
                isActive = false;
            }
        }
    }
}