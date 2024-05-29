using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifferentMeleeAttacks", menuName = "DifferentMeleeAttacks")]

public class DifferentMeleeAttacks : ScriptableObject
{
    public GameObject meleeAttack1;
    public GameObject meleeAttack2;
    public GameObject meleeAttack3;

    public int damageForAttack1;
    public int damageForAttack2;
    public int damageForAttack3;
}
