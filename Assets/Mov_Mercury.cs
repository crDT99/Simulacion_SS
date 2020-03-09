using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Mercury : MonoBehaviour
{
    private GameObject sol, Planeta_1, Planeta_2, Planeta_3, Planeta_4, Planeta_5, Planeta_6, Planeta_7, Planeta_8;
    private float addx, addz;
    public float Vz, Vx, Ax, Az;
    // public Vector3 posicion;
    private const float G = 6.67e-21f;
    private float[] R = new float[9];
    private float[] M = new float[9];
    public Vector3[] P = new Vector3[9];
    public int plnum;

    // Use this for initialization
    void Start()
    {
        
        addx = 0; addz = 0;
        M[0] = 1.989e20f;
        M[1] = 3.285e13f; M[2] = 4.867e14f; M[3] = 5.972e14f; M[4] = 6.39e13f; M[5] = 1.9e17f; M[6] = 5.68e16f; M[7] = 8.681e15f; M[8] = 1e16f;
        sol = GameObject.Find("Sun");
        Planeta_1 = GameObject.Find("Planeta_1");
        Planeta_2 = GameObject.Find("Planeta_2");
        Planeta_3 = GameObject.Find("Planeta_3");
        Planeta_4 = GameObject.Find("Planeta_4");
        Planeta_5 = GameObject.Find("Planeta_5");
        Planeta_6 = GameObject.Find("Planeta_6");
        Planeta_7 = GameObject.Find("Planeta_7");
        Planeta_8 = GameObject.Find("Planeta_8");
      

    }

    // Update is called once per frame
    void Update()
    {
        addx = 0; addz = 0;
        P[plnum] = gameObject.GetComponent<Transform>().position;
        P[0] = sol.GetComponent<Transform>().position;
        P[1] = Planeta_1.GetComponent<Transform>().position;
        P[2] = Planeta_2.GetComponent<Transform>().position;
        P[3] = Planeta_3.GetComponent<Transform>().position;
        P[4] = Planeta_4.GetComponent<Transform>().position;
        P[5] =  Planeta_5.GetComponent<Transform>().position;
        P[6] = Planeta_6.GetComponent<Transform>().position;
        P[7] = Planeta_7.GetComponent<Transform>().position;
        P[8] = Planeta_8.GetComponent<Transform>().position;

        for (int i = 1; i < 9; i++)
        {
            R[i] = Mathf.Sqrt(Mathf.Pow(P[i].x, 2f) + Mathf.Pow(P[i].z, 2f));
            if (i != plnum)
            {
                addx = addx + ((M[i] * (P[plnum].x - P[i].x)) / Mathf.Abs(Mathf.Pow(R[plnum] - R[i], 3f)));
                addz = addz + ((M[i] * (P[plnum].z - P[i].z)) / Mathf.Abs(Mathf.Pow(R[plnum] - R[i], 3f)));
            }
        }



        Ax = -G * (((M[0] * P[plnum].x) / Mathf.Abs(Mathf.Pow(R[plnum], 3f))) + addx);
        Az = -G * ((M[0] * P[plnum].z) / Mathf.Abs(Mathf.Pow(R[plnum], 3f)) + addz);
        Vz = Vz + Time.fixedDeltaTime * Az;
        Vx = Vx + Time.fixedDeltaTime * Ax;
        P[plnum].z = P[plnum].z + Time.fixedDeltaTime * Vz;
        P[plnum].x = P[plnum].x + Time.fixedDeltaTime * Vx;
        gameObject.GetComponent<Transform>().position = P[plnum];
    }
}
