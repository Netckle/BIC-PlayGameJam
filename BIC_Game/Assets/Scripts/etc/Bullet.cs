using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public UnitType type = UnitType.NONE;

    public float moveSpeed;
    private Vector3 moveDir = Vector3.zero;

    public void InitBullet(UnitType type, Vector3 moveDir, float moveSpeed)
    {
        this.type = type;
        this.moveDir = moveDir;
        this.moveSpeed = moveSpeed;
    }

    private void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
