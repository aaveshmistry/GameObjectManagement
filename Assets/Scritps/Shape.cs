using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    MeshRenderer meshRenderer;
    public int MaterialId { get; private set; }

    public void SetMaterial(Material material, int materialId)
    {
        GetComponent<MeshRenderer>().material = material;
        MaterialId = materialId;
    }

    static int colorPropertyId = Shader.PropertyToID("_Color");
    static MaterialPropertyBlock sharedPropertyBlock;

    Color color;

    public void SetColor(Color color)
    {
        this.color = color;
        if (sharedPropertyBlock == null)
        {
            sharedPropertyBlock = new MaterialPropertyBlock();
            GetComponent<MeshRenderer>().material.color = color;
        }
        sharedPropertyBlock.SetColor(colorPropertyId, color);
        meshRenderer.SetPropertyBlock(sharedPropertyBlock);
    }

    public override void Save(GameDataWriter writer)
    {
        base.Save(writer);
        writer.Write(color);
    }

    public override void Load(GameDataReader reader)
    {
        base.Load(reader);
        SetColor(reader.ReadColor());
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
