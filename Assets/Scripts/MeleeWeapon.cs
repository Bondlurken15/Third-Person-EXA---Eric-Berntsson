using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleeWeapon : WeaponBase
{
    [SerializeField] DifferentMeleeAttacks differentMeleeAttacksObj;
    [SerializeField] Transform playerTransform;

    [SerializeField] float timerAtStart = 1;
    [SerializeField] float offsetDistance = 2;

    float timer;
    int numberOfHits = 0;
    bool comboStarted = false;

    public override void Start()
    {
        base.Start();
        timer = timerAtStart;
    }

    public override bool Fire()
    {
        if (!base.Fire())
        {
            return false;
        }

        if (numberOfHits <= 0)
        {
            FirstHit();
        }
        else if (numberOfHits == 1)
        {
            SecondHit();
        }
        else if (numberOfHits == 2)
        {
            ThirdHit();
        }

        return true;
    }

    private void Update()
    {
        if (comboStarted)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = timerAtStart;
                comboStarted = false;
                numberOfHits = 0;
            }
        }
    }

    void FirstHit()
    {
        Vector3 spawnPosition = transform.position + new Vector3(transform.forward.normalized.x, transform.forward.normalized.y, transform.forward.normalized.z * offsetDistance);

        var go = Instantiate(differentMeleeAttacksObj.meleeAttack1, spawnPosition, differentMeleeAttacksObj.meleeAttack1.transform.rotation);

        var transformFromStart = go.transform.rotation;
        var rotationEulerFromStart = transformFromStart.eulerAngles;

        go.transform.LookAt(playerTransform.position + playerTransform.forward * 1000);
        var rotationEuler = go.transform.rotation.eulerAngles;

        go.transform.rotation = Quaternion.Euler(rotationEulerFromStart.x, rotationEuler.y, rotationEulerFromStart.z);
        
        comboStarted = true;
        numberOfHits++;
        Debug.Log("First hit");
    }

    void SecondHit()
    {
        Vector3 spawnPosition = transform.position + new Vector3(transform.forward.normalized.x, transform.forward.normalized.y, transform.forward.normalized.z * offsetDistance);

        var go = Instantiate(differentMeleeAttacksObj.meleeAttack2, spawnPosition, differentMeleeAttacksObj.meleeAttack2.transform.rotation);
        
        var transformFromStart = go.transform.rotation;
        var rotationEulerFromStart = transformFromStart.eulerAngles;
        
        go.transform.LookAt(playerTransform.position + playerTransform.forward * 1000);
        var rotationEuler = go.transform.rotation.eulerAngles;

        go.transform.rotation = Quaternion.Euler(rotationEulerFromStart.x, rotationEuler.y, rotationEulerFromStart.z);
        
        numberOfHits++;
        timer = timerAtStart;
        Debug.Log("Second hit");
    }

    void ThirdHit()
    {
        Vector3 spawnPosition = transform.position + new Vector3(transform.forward.normalized.x, transform.forward.normalized.y, transform.forward.normalized.z * offsetDistance);

        var go = Instantiate(differentMeleeAttacksObj.meleeAttack3, spawnPosition, differentMeleeAttacksObj.meleeAttack3.transform.rotation);

        var transformFromStart = go.transform.rotation;
        var rotationEulerFromStart = transformFromStart.eulerAngles;

        go.transform.LookAt(playerTransform.position + playerTransform.forward * 1000);
        var rotationEuler = go.transform.rotation.eulerAngles;

        go.transform.rotation = Quaternion.Euler(rotationEulerFromStart.x, rotationEuler.y, rotationEulerFromStart.z);

        comboStarted = false;
        numberOfHits = 0;
        timer = timerAtStart;
        Debug.Log("Third hit");
    }
}
