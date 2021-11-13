using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vertical Warning Pattern", menuName = "Scriptable Object/Shooting Pattern/Vertical Warning Pattern")]
public class VerticalWarningPattern : ShootingPattern
{
    public GameObject warningPrefab;

    Vector3 originPos = Vector3.zero;
    Vector3 spawnPos = Vector3.zero;
    public float cannotUseRange;
    public float range;

    public float maintainTime;
    public float fadeInTime;
    public float fadeOutTime;

    public override IEnumerator DoPattern(string bulletName, Vector3 shootPos, float moveSpeed)
    {
        this.bulletName = bulletName;
        this.shootPos = shootPos;
        this.moveSpeed = moveSpeed;

        float xValue = Random.Range(-range, range);
        if (xValue > 0f && xValue < cannotUseRange)
        {
            xValue = Mathf.Clamp(xValue, -range, -range + cannotUseRange);
        }
        else if (xValue < 0f && xValue > -cannotUseRange)
        {
            xValue = Mathf.Clamp(xValue, cannotUseRange, range);
        }

        spawnPos = shootPos + new Vector3(xValue, 0f, 0f);
        this.shootPos =spawnPos;
        GameObject obj = Instantiate(warningPrefab, spawnPos, Quaternion.identity);

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        Color color = sr.color;

        color.a = 0f;
        sr.color = color;

        while (color.a < 1f)
        {
            color.a += 0.01f;
            sr.color = color;
            yield return new WaitForSeconds(fadeInTime / 100f);
        }
        color.a = 1f;
        sr.color = color;
        Debug.Log(Time.time);
        yield return new WaitForSeconds(maintainTime);
        Debug.Log(Time.time);
        while (color.a > 0f)
        {
            color.a -= 0.01f;
            sr.color = color;
            yield return new WaitForSeconds(fadeOutTime / 100f);
        }
        color.a = 0f;
        sr.color = color;

        base.Shoot(0f);

        yield return new WaitForSeconds(coolTime);
    }
}
