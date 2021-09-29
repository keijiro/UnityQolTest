using UnityEngine;

public enum WeaponType
{
    Knife,
    Pistol,
    Chainsaw
}

[System.Serializable]
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
