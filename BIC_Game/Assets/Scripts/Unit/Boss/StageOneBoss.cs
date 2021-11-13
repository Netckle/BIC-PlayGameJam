using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneBoss : Unit
{
    public Transform playerPos;
    private Vector3 startPos = Vector3.zero;

    public float horRange;

    public List<ShootingPattern> commonPatterns = new List<ShootingPattern>();

    protected override void Start()
    {
        base.Start();
        StartCoroutine(ShootPattern());
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || canDamage)
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet.type == UnitType.PLAYER)
            {
                Damage();
            }
        }
    }

    private IEnumerator MovePattern()
    {
        Vector3 leftPos = startPos + new Vector3(-horRange, 0, 0);
        Vector3 rightPos = startPos + new Vector3(horRange, 0, 0);

        while (Vector3.Distance(transform.position, leftPos) > 1f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            yield return null; 
        }
        while (Vector3.Distance(transform.position, rightPos) > 1f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            yield return null;
        }

        StartCoroutine(MovePattern());
    }

    private IEnumerator ShootPattern()
    {
        AudioManager.Instance.SimplePlaySound(shootSound[Random.Range(0, shootSound.Count)],
            source, 1f);

        yield return StartCoroutine(commonPatterns[Random.Range(0, commonPatterns.Count)].DoPattern(bulletName, shootPos.position, bulletSpeed));

        StartCoroutine(ShootPattern());
    }

    protected override void Shoot()
    {
        //
    }
}
