using System;
using UnityEngine;

// InspectorOrder
//  InspectorSort.ByValue/ByName
//  InspectorSortDirection.Ascending/Descending

public enum WeaponType
{
    Knife,
    Pistol,
    Chainsaw
}

[Serializable]
public struct SpawnInfo
{
    public Vector3 position;
    public WeaponType weapon;
    public float interval;
}

public sealed class Spawner : MonoBehaviour
{
    public float[] values;
    public SpawnInfo[] slots;
}
