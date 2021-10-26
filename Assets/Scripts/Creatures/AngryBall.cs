using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AngryBall : MonoBehaviour
{
    [SerializeField] private int health = 3;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private float attackTime = 1f;
    private bool isAttacking;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int speed;
    [SerializeField] private Transform target;
    [SerializeField] private float attackRange;
    [SerializeField] private bool canDoDamage;
    
    public bool CanDoDamage
    {
        get => canDoDamage;
        set => canDoDamage = value;
    }
    public float AttackRange
    {
        get => attackRange;
        set => attackRange = value;
    }
    public Transform Target
    {
        get => target;
        set => target = value;
    }
    public bool IsAttacking
    {
        get => isAttacking;
        set => isAttacking = value;
    }

    public float AttackTime
    {
        get => attackTime;
        set => attackTime = value;
    }
    public Animator Animator => this.animator;

    private IState currentState;
    // Start is called before the first frame update

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        ChangeState(new FollowState());
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAttacking)
        {
            AttackTime += Time.deltaTime;
        }
        currentState.Update();
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            animator.SetBool("death", true);
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
    }

    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }

    public void MoveTo(Vector2 direction)
    {
        rigidbody2D.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Weapon"))
        {
            StartCoroutine(RedFlashlight());
            GetDamage(1);
        }
        if (other.tag.Contains("Player"))
        {
            target.GetComponent<Player>().Death();
        }
    }

    public IEnumerator RedFlashlight()
    {
        spriteRenderer.color = new Color(30, 0, 1);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1);
    }
}
