using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BowlingBallValues", menuName = "BowlingBallValues")]

public class BowlingBallValues : ScriptableObject
{
    public int bowlingBallDamage;
    public float bowlingBallSpeed;
    
    public float bonusVerticalDirection = 0.5f;
    //public int ammunition;
}
