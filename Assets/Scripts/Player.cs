using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Player : Entity
{

    // Start is called before the first frame update
    void Start(){

        side = "left";

        // strength defines hitDamage
        strength = CreateNewCharacter.strength;
        heightInCm = CreateNewCharacter.heightInCm;
        GetComponent<SpriteLibrary>().spriteLibraryAsset = CreateNewCharacter.skin;
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

        entityName = "Can";
        //inBattle = false;
        //alive = false;
        
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 0.02f;
        stepSize = 1f;
        movingLeft = false;
        movingRight = false;

        // adjust player size here
        // transform localscale and position
        Vector3 originalPosition = transform.position;

         // Calculate the new scale uniformly
        float newScale =  transform.localScale.x * math.pow(1.01f,strength);

        // Calculate the position adjustment based on the scale change
        Vector3 positionAdjustment = (newScale - transform.localScale.x) * 0.59f *  transform.up;

        // Apply the new scale and adjust the position
        transform.localScale = new Vector3(newScale, newScale,  transform.localScale.z);
        transform.position = originalPosition - positionAdjustment;

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
