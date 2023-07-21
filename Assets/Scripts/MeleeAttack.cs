using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackStrength;
    public float damage;
    private bool canAttack = true;
    public Transform launchDir;
    public Animator animator;
    public List<AudioClip> audioClips = new List<AudioClip>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t") && canAttack)
        {
            StartCoroutine(DoAttack());
        }
    }

    private IEnumerator DoAttack()
    {
        GetComponentInParent<PlayerMovement>().canMove = false;
        GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;

        animator.SetBool("Attack", true);
        canAttack = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        animator.SetBool("Attack", false);

        canAttack = true;
        GetComponentInParent<PlayerMovement>().canMove = true;

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Logic where people take damage
        if (otherCollider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            SoundManager.Instance.PlaySound(PickRandomHitSound());

            Vector2 self = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 otherLoc = new Vector2(otherCollider.transform.position.x, otherCollider.transform.position.y);
            Vector2 dir = (Vector2)launchDir.position - self;

            float percentage = otherCollider.GetComponent<PlayerHealth>().percentage;

            otherCollider.gameObject.GetComponent<Rigidbody2D>().AddForce(((dir) * (attackStrength * (percentage/100f + 1))), ForceMode2D.Impulse);

            otherCollider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private AudioClip PickRandomHitSound()
    {
        AudioClip clip = audioClips[Random.Range(1, audioClips.Count)];
        return clip;
    }
}
