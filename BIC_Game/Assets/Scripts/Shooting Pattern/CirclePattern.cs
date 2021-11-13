using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Circle Pattern", menuName = "Scriptable Object/Shooting Pattern/Circle Pattern")]
public class CirclePattern : ShootingPattern
{
    public int repeatCount;
    public int amountPerShot;

    public override IEnumerator DoPattern(string bulletName, Vector3 shootPos, float moveSpeed)
    {
        this.bulletName = bulletName;
        this.shootPos = shootPos;
        this.moveSpeed = moveSpeed;

        float zRot = 0f;
        for (int i = 0; i < repeatCount; i++)
        {
            yield return new WaitForSeconds(delay);
            zRot = 0f;
            for (int j = 0; j < amountPerShot; j++)
            {
                base.Shoot(zRot);
                Debug.Log(360 / amountPerShot);
                zRot += 360 / amountPerShot;
            }            
        }

        yield return new WaitForSeconds(coolTime);
    }
}
