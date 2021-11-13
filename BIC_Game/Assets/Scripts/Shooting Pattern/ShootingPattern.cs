using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPattern : ScriptableObject
{
    public float coolTime;
    public float delay;

    protected string bulletName = string.Empty;
    protected Vector3 shootPos = Vector3.zero;
    protected float moveSpeed;

    public virtual IEnumerator DoPattern(string bulletName, Vector3 shootPos, float moveSpeed)
    {
        this.bulletName = bulletName;
        this.shootPos = shootPos;
        this.moveSpeed = moveSpeed;

        yield return null;
    }
    
    protected virtual void Shoot(float zRot)
    {
        Debug.Log(bulletName + " " + shootPos + " " + moveSpeed);

        GameObject obj = ObjectPool.Instance.SpawnObject(bulletName, shootPos);

        Quaternion nextRot = Quaternion.Euler(0f, 0f, zRot);
        obj.transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(0, 0, 180 + zRot));



        Vector3 moveDir = nextRot * Vector3.down;

        

        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.InitBullet(UnitType.ENEMY, moveDir, moveSpeed);
    }

    protected virtual void Shoot(Vector3 dir)
    {
        Debug.Log(bulletName + " " + shootPos + " " + moveSpeed);

        GameObject obj = ObjectPool.Instance.SpawnObject(bulletName, shootPos);

        Quaternion nextRot = Quaternion.LookRotation(dir);

        obj.transform.GetChild(0).rotation = nextRot;








        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.InitBullet(UnitType.ENEMY, dir, moveSpeed);
    }
}
