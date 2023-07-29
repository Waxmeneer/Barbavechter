using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Projectile : MonoBehaviour
{
    private bool hitCooledDown;
    public float attackStrength;
    public float damage;
    public Transform launchDir;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public float hitBoxDelay;
    public float hitBoxEnd;
    public float lifeTime;
    public float hitCoolDown;

    private void Start()
    {
        hitCooledDown = true;
        StartCoroutine(SetHitBox());
    }

    IEnumerator SetHitBox()
    {
        Collider2D cc = GetComponent<Collider2D>();
        yield return new WaitForSeconds(hitBoxDelay);
        cc.enabled = true;
        yield return new WaitForSeconds(hitBoxEnd);
        cc.enabled = false;
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        print("hit something");
        //Logic where people take damage
        if (otherCollider.gameObject.GetComponent<Rigidbody2D>() != null && hitCooledDown == true)
        {
            SoundManager.Instance.PlaySound(PickRandomHitSound());

            Vector2 self = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 otherLoc = new Vector2(otherCollider.transform.position.x, otherCollider.transform.position.y);
            Vector2 dir = (Vector2)launchDir.position - self;

            float percentage = otherCollider.GetComponent<PlayerHealth>().percentage;

            otherCollider.gameObject.GetComponent<Rigidbody2D>().AddForce(((dir) * (attackStrength * (percentage / 100f + 1))), ForceMode2D.Impulse);

            otherCollider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

            StartCoroutine(HitCoolDown());
        }
    }
    private IEnumerator HitCoolDown()
    {
        hitCooledDown = false;
        yield return new WaitForSeconds(hitCoolDown);
        hitCooledDown = true;
        yield return null;
    }

    private AudioClip PickRandomHitSound()
    {
        AudioClip clip = audioClips[Random.Range(0, audioClips.Count)];
        return clip;
    }
}
