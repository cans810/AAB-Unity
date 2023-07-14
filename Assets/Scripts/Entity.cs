using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // stats
    public string side;
    public int level;
    public int strength;
    public int stamina;
    public int dexterity;
    public int vitality;
    public int offense;
    public int defence;
    public int aura;
    public int magic;
    // attributes
    public string entityName;
    public double heightInCm = 170;
    // strength attributes
    public float baseHitDamage = 2;
    public float hitDamage;
    public float heightChange = 0;
    // vitality attributes
    public float baseHP = 20;
    public float maxHP;
    public float HP;
    // dexterity attributes
    public float baseStepSize;
    public float stepSize;
    public float movementSpeed;
    // stamina attributes
    public float energy;
    // boolean values
    public bool alive;
    public bool played;
    public bool inBattle;

    public Animator animator;
    public Rigidbody2D rb;
    public bool movingLeft, movingRight;
    public float destinationX;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
