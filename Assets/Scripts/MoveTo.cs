using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// I would consider this code practically viable
// ~ looseleif
public class MoveTo : MonoBehaviour
{
    // Start is called before the first frame update
       public Transform goal;
       public Transform post1;
       public Transform post2;
       public Transform post3;

       public Transform parentModel;

       public GameObject parentOBJ;
       public bool moving = false;
       
       private NavMeshAgent agent;

       // public object made for easy manipulation

      public Transform[] locals;

      int i = 0;

       private void Start() {
          
          agent = parentOBJ.GetComponent<NavMeshAgent>();

          locals = new Transform[]{post1,post2,post3};

          // inital object assign

       }
       void Update () {

          // moving is a variable used to tell if the navmesh navigation should be used

          if(moving){

            //agent.enabled = true;
            agent.destination = goal.position;

          } else {

            //agent.enabled =false;

            agent.destination = locals[i].transform.position;

            float dist = Vector3.Distance(transform.position,locals[i].transform.position);

            if(dist<3){

               i++;

            }

            if(i>2){

               i=0;

            }

            // this is used as a basic path for the enemy to use when not engaged

            // parentModel.position =  new Vector3(parentModel.position.x + Mathf.Cos(Time.frameCount),
            //                                     parentModel.position.y,
            //                                     parentModel.position.z + Mathf.Sin(Time.frameCount));

          }
          
       }

      // Both of these trigger events are used for pathing purposes
       private void OnTriggerEnter(Collider other) {
          
            if(other.gameObject.tag=="Player"){

               moving = true;

            }

       }

       private void OnTriggerExit(Collider other) {
          
         if(other.gameObject.tag=="Player"){

            moving = false;

         }

       }

}
