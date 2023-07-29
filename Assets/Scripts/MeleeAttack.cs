using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackStrength;
    public float damage;
    private bool canAttack = true;
    public Transform launchDir;
    public Animator animator;
    public List<AudioClip> audioClips = new List<AudioClip>();

    public float hitBoxDelay;
    public float hitBoxEnd;
    public float attackEnd;
    public float hitCoolDown;

    private bool hitCooledDown = true;

    private KeyCode attackButton;

    private void Start()
    {
        attackButton = GetComponentInParent<PlayerMovement>().attackButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackButton) && canAttack)
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
        yield return new WaitForEndOfFrame();
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(hitBoxDelay);
        gameObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(hitBoxEnd);
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(attackEnd);
        

        canAttack = true;
        GetComponentInParent<PlayerMovement>().canMove = true;

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Logic where people take damage
        if (otherCollider.gameObject.GetComponent<Rigidbody2D>() != null && hitCooledDown == true)
        {
            SoundManager.Instance.PlaySound(PickRandomHitSound());

            Vector2 self = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 otherLoc = new Vector2(otherCollider.transform.position.x, otherCollider.transform.position.y);
            Vector2 dir = (Vector2)launchDir.position - otherLoc;

            float percentage = otherCollider.GetComponent<PlayerHealth>().percentage;

            otherCollider.gameObject.GetComponent<Rigidbody2D>().AddForce(((dir) * (attackStrength * (percentage/100f + 1))), ForceMode2D.Impulse);

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
        AudioClip clip = audioClips[Random.Range(1, audioClips.Count)];
        return clip;
    }
}
