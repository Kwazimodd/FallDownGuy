using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Attacker: MonoBehaviour
{
    private Vector2 forceDirection;
    [SerializeField] private float pushHeight;
    private Animation animation;
    private TrailRenderer trailRenderer;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
    
    private List<String> collisionsList = new List<string>();

    private static Dictionary<Vector2, String> directionAnimDict => new Dictionary<Vector2, String>()
    {
        {Vector2.left, "AttackLeft"},
        {Vector2.right, "AttackAnim"},
        {Vector2.down, "AttackBottom"}
    };

    private void Awake()
    {
        animation = GetComponent<Animation>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();


        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        trailRenderer.enabled = false;
    }

    public void StartAttack()
    {
        spriteRenderer.enabled = true;
        collider2D.enabled = true;
        trailRenderer.enabled = true;
    }

    public void Attack(Vector2 direction)
    {
        
        animation.Play(directionAnimDict[direction]);
    }
    
    public void StopAttack()
    {
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        trailRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionsList.Add(other.tag);
        if (other.tag.Equals("Spikes"))
        {
            PushUpParent();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        collisionsList.Remove(other.tag);
    }

    private void PushUpParent()
    {
        GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, pushHeight);
    }

    private void Animate(int direction)
    {
     //   GetComponent<Animator>().SetInteger("x", direction);
    }

    private void Start()
    {
    }
}