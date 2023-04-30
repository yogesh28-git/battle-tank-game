using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/New ScriptableObject") ]
public class TankScriptableObject : ScriptableObject
{
    public TankView TankPrefab;
    public int Health;
    public float MoveSpeed;

    public BulletView BulletPrefab;
}
