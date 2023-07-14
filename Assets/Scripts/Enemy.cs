using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : Entity
{
     // Start is called before the first frame update
    void Start(){
        side = "right";

        // strength defines hitDamage

        strength = 1;
        heightInCm = 170;
        hitDamage = baseHitDamage + strength;

        // agility defines stepSize
        dexterity = 1;
        baseStepSize = 
        stepSize = 

        // vitality defines HP
        vitality = 1;
        HP = vitality*2 + baseHP;

        // attack defines chances of attack action land
        // şimdilik atla
        offense = 1;

        // defence defines chances of blocking enemy attack
        // şimdilik atla
        defence = 1;

        // charisma reduces items prices that are in market,
        // şimdilik atla
        aura = 1;

        // stamina defines stamina point
        // şimdilik atla
        stamina = 1;

        // magicka defines magicDamage
        // şimdilik atla
        magic = 1;

        entityName = "Allah";
        //inBattle = false;
        //alive = false;
        
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 0.02f;
        stepSize = 1f;
        movingLeft = false;
        movingRight = false;


        if (side.Equals("right")){
            flip();
        }
    }

    // Update is called once per frame
    void Update(){

        if (movingRight){
            if (rb.position.x <= destinationX){
                rb.MovePosition(new Vector2(rb.position.x+moveSpeed,rb.position.y));
                animator.SetBool("Walking",true);
            }
            else{
                stopMovingRight();
            }
        }
        else if (movingLeft){
            if (rb.position.x >= destinationX){
                rb.MovePosition(new Vector2(rb.position.x-moveSpeed,rb.position.y));
                animator.SetBool("Walking",true);
            }
            else{
                stopMovingLeft();
            }
        }
        // if idle
        else{
            animator.SetBool("Walking",false);
            animator.SetBool("Idle",true);
        }
    }

    public void attackLight(){
        //animator.SetBool("Light_Attack",true);
        animator.SetBool("Walking",false);
        animator.SetBool("Idle",false);
        animator.SetBool("Light_Attack",true);
    }

    public void moveRight(){
        animator.SetBool("Idle",false);
        animator.SetBool("Walking",true);
        destinationX = rb.position.x + stepSize;
        movingRight = true;
    }

    public void stopMovingRight(){
        movingRight = false;
    }

    public void moveLeft(){
        animator.SetBool("Idle",false);
        animator.SetBool("Walking",true);
        destinationX = rb.position.x - stepSize;
        movingLeft = true;
    }

    public void stopMovingLeft(){
       movingLeft = false;
    }

    public void flip(){
        transform.Rotate(0f, 180f, 0f);
    }
}
