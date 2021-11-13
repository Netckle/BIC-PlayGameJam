using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType { NONE, PLAYER, ENEMY }

public class Unit : MonoBehaviour
{    
    public UnitType type = UnitType.NONE;

    protected Blink blink;

    [Header("About Shooting")]
    public Transform shootPos;

    public float bulletSpeed;
    public string bulletName = string.Empty;

    protected Vector3 bulletDir = Vector3.zero;

    [Header("About Sound")]
    public List<string> shootSound;
    public List<string> damageSound;

    protected AudioSource source;

    [Header("About Unit Data")]
    public float maxHealth;
    protected float health;

    public float moveSpeed;
    protected Vector3 moveDir = Vector3.zero;

    public bool isMoving = false;

    public bool canMove = true;
    public bool canDamage = true;   

    virtual protected void Start()
    {
        blink = GetComponent<Blink>();
        source = GetComponent<AudioSource>();
        health = maxHealth;
    }

    virtual protected void Update()
    {
        if (!canMove)
            return;
    }

    virtual protected void Shoot()
    {
        AudioManager.Instance.SimplePlaySound(shootSound[Random.Range(0, shootSound.Count)],
            source, 1f);

        Bullet bullet = ObjectPool.Instance.SpawnObject(bulletName, shootPos.position).
            GetComponent<Bullet>();

        bullet.InitBullet(type, bulletDir, bulletSpeed);
    }

    virtual protected void Damage()
    {
        if (health < 0)
        {
            Die();
            return;
        }
        AudioManager.Instance.SimplePlaySound(damageSound[Random.Range(0, shootSound.Count)],
            source, 1f);

        StartCoroutine(ChangeDamageableState());
        health--;
    }

    protected IEnumerator ChangeDamageableState()
    {
        canDamage = false;

        yield return StartCoroutine(blink.BlinkSprite());

        canDamage = true;
    }

    virtual protected void Die()
    {
        //
    }
}
