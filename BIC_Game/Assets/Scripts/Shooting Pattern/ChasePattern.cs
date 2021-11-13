using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase Pattern", menuName = "Scriptable Object/Shooting Pattern/Chase Pattern")]
public class ChasePattern : ShootingPattern
{
    private Transform playerPos;
    public int repeatCount;
    public int amountPerShot;

    public float repeatDelay;

    public override IEnumerator DoPattern(string bulletName, Vector3 shootPos, float moveSpeed)
    {
        this.bulletName = bulletName;
        this.shootPos = shootPos;
        this.moveSpeed = moveSpeed;

        playerPos = GameObject.Find("Player").transform;

        for (int i = 0; i < repeatCount; i++)
        {
            yield return new WaitForSeconds(repeatDelay);

            

            for (int j = 0; j < amountPerShot; j++)
            {
                Vector3 dir = (playerPos.position - shootPos).normalized;
                base.Shoot(dir);

                yield return new WaitForSeconds(delay);
            }
        }

        yield return new WaitForSeconds(coolTime);
    }
}
