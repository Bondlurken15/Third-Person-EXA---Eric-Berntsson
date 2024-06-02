using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileValues", menuName = "ProjectileValues")]

public class ProjectileValues : ScriptableObject
{
    public ParticleSystem projectileExplosion;
    public ParticleSystem projectileTravelEffect;
    public int projectileDamage;
    public float projectileSpeed;
    
    public float bonusVerticalDirection = 0.5f;
    //public int ammunition;
}
