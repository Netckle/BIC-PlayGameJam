using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit
{
    public Transform startPos;
    public float upLimit;
    public float downLimit;
    public float sideLimit;

    protected override void Start()
    {
        base.Start();
        transform.position = startPos.position;
    }

    protected override void Update()
    {
        base.Update();

        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void Move()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, startPos.position.x - sideLimit,
            startPos.position.x + sideLimit),
            Mathf.Clamp(transform.position.y, startPos.position.y - downLimit,
            startPos.position.y + upLimit));

        isMoving = (moveDir.x != 0f || moveDir.y != 0f) ? true : false;
    }

    #region Override Function

    protected override void Shoot()
    {
        bulletDir = Vector3.up;
        base.Shoot();
    }

    protected override void Die()
    {
        canMove = false;
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || canDamage)
        {
            canDamage = false;

            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet.type == UnitType.ENEMY)
            {
                Damage();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (startPos == null)
            return;

        Gizmos.color = Color.white;
        Gizmos.DrawLine(new Vector2(startPos.position.x - sideLimit, startPos.position.y),
            new Vector2(startPos.position.x + sideLimit, startPos.position.y));

        Gizmos.DrawLine(new Vector2(startPos.position.x, startPos.position.y - downLimit),
            new Vector2(startPos.position.x, startPos.position.y + upLimit));
    }
}
