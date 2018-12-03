using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableControl : MonoBehaviour {

    public GameObject TableObject;
	public float TableHeight = 0.1f;

    public Transform DebugPoint4;

    // Use this for initialization
    void Start()
    {
        //SetTable();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(TableObject.transform.position, TableObject.transform.forward * 100f, Color.blue);
        Debug.DrawRay(TableObject.transform.position, TableObject.transform.up * 100f, Color.green);
        Debug.DrawRay(TableObject.transform.position, TableObject.transform.right * 100f, Color.red);
        //SetTable();
    }

    public void SetTable(Vector3 point1, Vector3 point2, Vector3 point3)
    {

        float width = Vector3.Distance(point1, point2);
        float length_1 = Vector3.Distance(point1, point3);
        float length_2 = Vector3.Distance(point2, point3);
        float length;

        Vector3 pos;
        Vector3 normalPos;

        if (length_1 < length_2)
        {
            length = length_1;
            // cp1 is right point
            GetTransform(point2, point1, point3, out pos, out normalPos);
        }
        else
        {
            length = length_2;
            // cp2 is right point
            GetTransform(point1, point2, point3, out pos, out normalPos);
        }

        /* Position */
        TableObject.transform.position = pos;

        /* Rotation */
        TableObject.transform.LookAt(normalPos, TableObject.transform.up);

        /*  Scale */
        TableObject.transform.localScale = new Vector3(width, length, TableHeight);

    }

    void GetTransform(Vector3 point1, Vector3 point2, Vector3 point3, out Vector3 pos, out Vector3 normalPos)
    {
        Vector3 AB = point1 - point2;
        Vector3 CB = point3 - point2;

        Vector3 point4 = AB + CB + point2;
        pos = (point1 + point2 + point3 + point4)/4;
        if (DebugPoint4 != null)
        {
            DebugPoint4.transform.position = point4;
        }

        Vector3 normal = Vector3.Cross(CB, AB);
        normalPos = normal + pos;
    }
}
