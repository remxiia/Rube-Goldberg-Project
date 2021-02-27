using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    
    SpriteRenderer myRenderer; //specifiying what the hypothetical box in the program can hold (spriterenders)
    //variable myRenderer to type SpriteRenderer
    public Color floorColor; //box that only holds colors, and this specific one is just for the floor's color
    public color gateColor;
    RigidBody2D myBody;
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        //19: setting the var
        myRenderer = gameObject.GetComponent<SpriteRenderer>() //gameObj = the object being dealt with atm (the ball); getComp = refs components on the ball, and we want to change the spriteRenderer
        //in a game that has physics: you don't want to reference the object's transform the way we did in the previous tutorial
        //we need to move their body, not just their visual on the game screen
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){ //getkeydown: returns true once, not as if you're holding it down
            //myBody.AddForce(Vector3.right); //adding a teeny bit of force and rolling the object
            //Vector3.right is effectively writing it as 1, 0, 0; x, y, z | the same as: 
            myBody.AddForce(new Vector3(1, 0, 0) * power); //* power adds much more force, equal to [power] under [ball behavior] in [inspector]

            //in order to make the ball go up-right: We can add vectors together:
            myBody.AddForce((Vector3.right * Vector3.up) * power); //in the smaller parenthesis will be carried out first
            //OR w/coordinates you make yourself:
            //myBody.AddForce((new Vector3(1, 0, 0) + new Vector3(0, 1, 0)) * power); //or doing (1, 1, 0) would get the same result
        
        }  
    }

    //this code won't do anything bc there's nothing in the project, but it's here for future reference purposes
    //there are functions that will be called when a certain thing occurs, such as:
    void onCollisionEnter2D(Collision2D other){ //in paranthesis: parameter that says when the object hits something else, we get the info/data from that collision 
    //(how much force their was, what it collided with, etc.)
       if(other.gameObject.name == "Floor"){ //if the other game object is the floor, then...
            myRenderer.color = floorColor; //lowercase bc it's a property // can do this bc line 19
            Debug.Log("Hit something");//...display this message in the console.
       }
    }
        
    void OnTriggerEnter2D(Collider2D other){ //trigger's don't have anything to do with physics; don't need the extra data we get from Collision2D...
    //...we just need to know info about the other object
        if(other.gameObject.name == "Gate){
            myRenderer.color = gateColor;
        }
    }
}
