using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveTo : MonoBehaviour
{
    // Start is called before the first frame update
       public Transform goal;

       public Transform parentModel;

       public GameObject parentOBJ;
       public bool moving = false;
       
       private NavMeshAgent agent;

       private void Start() {
          
          agent = parentOBJ.GetComponent<NavMeshAgent>();

       }
       void Update () {

          if(moving){

            agent.enabled = true;
            agent.destination = goal.position;

          } else {

            agent.enabled =false;
            parentModel.position = new Vector3(parentModel.position.x + Mathf.Cos(Time.frameCount),parentModel.position.y,parentModel.position.z + Mathf.Sin(Time.frameCount));

          }
          
       }

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
