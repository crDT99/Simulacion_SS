using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPla : MonoBehaviour
{
    public float Vz, Vx, Ax, Az,Ms,t;
    public Vector3 posicion;
    public const float G = 6.67e-21f;
   // public GameObject Planeta_2;
    // Start is called before the first frame update
    void Start()
    {
        Vz = -0f;
        Vx = 0.8f;
        Ms = 1.989e20f;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        posicion = gameObject.GetComponent<Transform>().position;
        Ax = -G * ((Ms * posicion.x) / Mathf.Pow((Mathf.Sqrt(Mathf.Pow(posicion.x, 2f) + Mathf.Pow(posicion.z, 2f))), 3));
        Az = -G * ((Ms * posicion.z) / Mathf.Pow((Mathf.Sqrt(Mathf.Pow(posicion.x, 2f) + Mathf.Pow(posicion.z, 2f))), 3));
        Vz = Vz + Time.fixedDeltaTime * Az;
        Vx = Vx + Time.fixedDeltaTime * Ax;
        posicion.z = posicion.z +   Time.fixedDeltaTime * Vz;
        posicion.x = posicion.x +   Time.fixedDeltaTime * Vx;
           gameObject.GetComponent<Transform>().position = posicion;

    }
}
