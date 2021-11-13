using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Pattern", menuName = "Scriptable Object/Shooting Pattern/Wave Pattern")]
public class WavePattern : ShootingPattern
{
    public float limitAngle = 0f;
    public float amountPerDir = 0f;

    public override IEnumerator DoPattern(string bulletName, Vector3 shootPos, float moveSpeed)
    {
        this.bulletName = bulletName;
        this.shootPos   = shootPos;
        this.moveSpeed  = moveSpeed;

        for (float i = -limitAngle; i <= limitAngle; i += (limitAngle * 2) / amountPerDir)
        {
            base.Shoot(i);
            yield return new WaitForSeconds(delay);
        }

        for (float i = limitAngle; i >= -limitAngle; i-= (limitAngle * 2) / amountPerDir)
        {
            base.Shoot(i);
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(coolTime);
    }
}
