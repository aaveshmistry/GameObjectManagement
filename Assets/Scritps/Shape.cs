using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    public int MaterialId { get; private set; }

    public void SetMaterial(Material material, int materialId)
    {
        GetComponent<MeshRenderer>().material = material;
        MaterialId = materialId;
    }

    public int ShapeId
{
    get
    {
        return ShapeId;
    }

    set
    {
        if (shapeId == int.MinValue && value != int.MinValue)
        {
            shapeId = value;
        }
        else
        {
            Debug.LogError("Not allowed to change shapeId.");
        }
     }
    }

    int shapeId = int.MinValue;

}
