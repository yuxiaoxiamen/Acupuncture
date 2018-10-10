using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GetNormalVector : MonoBehaviour
{
    private Vector3 direction = new Vector3(0, 0, 0);
    private float distance;
    private RaycastHit hit;
    private float theta = 0;
    private float phi = 0;
    private List<Vector3> vectors = new List<Vector3>();
    private static Dictionary<string, Vector3Serializer> normalVectors = new Dictionary<string, Vector3Serializer>();
    private static bool onceWrite = true;
    private Vector3 normalVector = Vector3.zero;
    public float diff = 0.1f;
    public float distanceCoefficient = 2.0f;
    public float enlargeMultiple = 10000;
    public bool isTest = false;
    private List<Transform> subTransform = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        distance = transform.GetComponent<SphereCollider>().radius * distanceCoefficient;
        if(transform.childCount == 2)
        {
            subTransform.Add(transform.GetChild(0));
            subTransform.Add(transform.GetChild(1));
            transform.GetComponent<SphereCollider>().enabled = false;
        }
    }

    private void Update()
    {
        if(subTransform.Count > 0)
        {
            normalVector = -ObtainNormalVector(transform.position * enlargeMultiple, 
                subTransform[0].position*enlargeMultiple, 
                subTransform[1].position * enlargeMultiple);
            if (isTest)
            {
                Debug.Log(normalVector + " " + gameObject.name);
            }
            else
            {
                normalVectors.Add(gameObject.name, new Vector3Serializer(normalVector));
            }
            subTransform.Clear();
        }
        else
        {
            direction = Radium(theta, phi, distance);
            Ray ray = new Ray(transform.position, direction);
            if (vectors.Count < 3 && Physics.Raycast(ray, out hit, distance))
            {
                if (!hit.collider.gameObject.tag.Equals("Acupoint"))
                {
                    //Debug.Log(hit.point);
                    int count = vectors.Count;
                    vectors.Add(hit.point * enlargeMultiple);
                    if (vectors.Count == 3)
                    {
                        normalVector = ObtainNormalVector(vectors[0], vectors[1], vectors[2]);
                        if (normalVector.Equals(Vector3.zero))
                        {
                            vectors.Clear();
                        }
                        else
                        {
                            if (isTest)
                            {
                                Debug.Log(vectors[0] + " " + vectors[1] + " " + vectors[2] + "  " + normalVector + " " + gameObject.name);
                            }
                            else
                            {
                                normalVectors.Add(gameObject.name, new Vector3Serializer(normalVector));
                            }
                            //Debug.DrawLine(transform.position, transform.position + normalVector, Color.blue);
                        }
                    }
                    //Debug.DrawLine(ray.origin, hit.point, Color.blue);
                }
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
        if (isTest)
        {
            Debug.DrawRay(transform.position, normalVector, Color.blue);
        }
    }

    private void OnDisable()
    {
        if(!isTest && onceWrite)
        {
            Tool.GetInstance().SerializeObject("Assets/Game/Resources/normalVectors.bin", normalVectors);
            onceWrite = false;
            Debug.Log(normalVectors.Count);
        }
    }


    Vector3 Radium(float theta, float phi, float r = 1.0f)
    {
        return new Vector3(r * Mathf.Sin(phi)*Mathf.Cos(theta), r * Mathf.Sin(phi) * Mathf.Sin(theta), r * Mathf.Cos(phi));
    }

    Vector3 ObtainNormalVector(Vector3 a, Vector3 b, Vector3 o)
    {
        Vector3 oa = a - o;
        Vector3 ob = b - o;
        Vector3 normalVector = Vector3.Cross(oa, ob);
        return normalVector;
    }
}