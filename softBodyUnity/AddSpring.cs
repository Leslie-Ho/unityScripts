using System.Collections.Generic;
using UnityEngine;

public class AddSpring : MonoBehaviour
{
    public GameObject[] colliders;
    public Dictionary<GameObject, GameObject[]> colliders2 = new Dictionary<GameObject, GameObject[]>();

    public float Spring = 100f;
    public float Damper = 0.2f;
    public Softbody.ColliderShape Shape = Softbody.ColliderShape.Sphere;
    public float ColliderSize = 0.02f;
    public float RigidbodyMass = 1f;
    public LineRenderer PrefabLine = null;
    public bool ViewLines = true;


    void Start()
    {
        Softbody.Init(Shape, ColliderSize, RigidbodyMass, Spring, Damper, RigidbodyConstraints.None, PrefabLine, ViewLines);

        if (colliders == null || colliders.Length < 2)
            Debug.Log("Need bones");

        //add colliders
        for (int i = 0; i < colliders.Length; i++)
        {
            Softbody.AddCollider(ref colliders[i]);
        }

        //add springs
        for (int i=0; i < colliders.Length - 1; i++)
        {
            for (int j = i+1; j < colliders.Length; j++)
            {
                Softbody.AddSpring(ref colliders[i], ref colliders[j]);
            }
        }

    }
}
