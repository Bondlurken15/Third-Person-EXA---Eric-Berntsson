using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifferentMeleeAttacks", menuName = "DifferentMeleeAttacks")]

public class DifferentMeleeAttacks : ScriptableObject
{
    public GameObject meleeAttack;
    public ParticleSystem meleeAttackEffect;

    public int damage;
}
