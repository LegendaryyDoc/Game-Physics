using UnityEngine;

/*  Get a RayCast(Light) to bounce off of a Mirror and keep doing that until the light doesn't hit a Mirror  */

public class RaycastBounceOffMirror : MonoBehaviour
{
    public LayerMask mask;
    public float maxLength = 100f;

    [HideInInspector] public bool levelPass;

    private LineRenderer lr;
    public int maxReflections;
    private RaycastHit hit;
    private Ray ray;
    private Vector3 direction;

    private void Start()
    {
        levelPass = false;
        maxReflections = 1;
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);

        for (int i = 0; i < maxReflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, maxLength))
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if(hit.collider.gameObject.tag == "Mirror")
                {
                    maxReflections++;
                    continue;
                }
                else if(hit.collider.gameObject.tag == "FinalMirror")
                {
                    //Debug.Log("Mirror Level Pass");
                    levelPass = true;
                    break;
                }
                else
                {
                    //Debug.Log("Mirror Level Fail");
                    levelPass = false;
                    break;
                }
            }
        }
    }
}