using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDirectionVector : MonoBehaviour
{

    Vector3 direction = new Vector3(0, 0, 0);
    float distance;
    RaycastHit hit;
    float theta = 0;
    float phi = 0;
    float diff = 0.1f;
    float offset = 0.05f;
    List<Vector3> vectors = new List<Vector3>();

    // Use this for initialization
    void Start()
    {
        distance = transform.GetComponent<SphereCollider>().radius;
        Debug.Log(GetNormalVector(new Vector3(1.4f, 1.0f, 0.0f),
                new Vector3(1.4f, 1.1f, 0.1f), new Vector3(1.4f, 1.0f, 0.1f)));
    }

    private void Update()
    {
        direction = Radium(theta, phi, distance);
        Ray ray = new Ray(transform.position, direction);
        if(/*vectors.Count < 3 && */Physics.Raycast(ray, out hit, distance))
        {
            //int count = vectors.Count;
            //if(count >= 2)
            //{
            //    if(hit.point.x - vectors[count - 1].y > offset && 
            //        hit.point.x - vectors[count - 1].x > offset && 
            //        hit.point.x - vectors[count - 1].z > offset)
            //    {
            //        vectors.Add(hit.point);
            //    }
            //}
            //if(vectors.Count == 3)
            //{
            //    Vector3 normalVector = GetNormalVector(vectors[0], vectors[1], vectors[2]);
            //    Debug.Log(vectors[0]+" "+vectors[1]+" "+vectors[2]+"  "+normalVector);
            //    Debug.DrawLine(transform.position, transform.position + normalVector, Color.red);
            //}
            //Debug.Log(hit.point + " "+hit.transform.name);
            //Debug.DrawLine(ray.origin, hit.point, Color.blue);
        }
        //else
        //{
        //    Debug.DrawRay(ray.origin, direction, Color.red);
        //}

        if (phi >= 2 * Mathf.PI)
        {
            theta += diff;
            phi = 0;
        }
        else if (phi <= 2 * Mathf.PI)
        {
            phi += diff;
        }
    }

    List<Vector3> RemoveDuplicate(List<Vector3> vectors)
    {
        HashSet<Vector3> set = new HashSet<Vector3>(vectors);
        return new List<Vector3>(set);
    }

    Vector3 Radium(float theta, float phi, float r = 1.0f)
    {
        return new Vector3(r * Mathf.Sin(phi)*Mathf.Cos(theta), r * Mathf.Sin(phi) * Mathf.Sin(theta), r * Mathf.Cos(phi));
    }

    Vector3 GetNormalVector(Vector3 a, Vector3 b, Vector3 o)
    {
        Vector3 oa = a - o;
        Vector3 ob = b - o;
        Vector3 normalVector = Vector3.Cross(oa, ob);
        return normalVector;
    }
}