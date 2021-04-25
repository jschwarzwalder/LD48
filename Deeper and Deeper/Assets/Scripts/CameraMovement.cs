using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float scrollSpeed = 10f;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxZ;
    [SerializeField] float minZ;
    bool withinRoom;

    void Update () {

        withinRoom = transform.position.x > minX && transform.position.x < maxX && 
                     transform.position.z > minZ && transform.position.z < maxZ;

        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (withinRoom){

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
                transform.position += moveSpeed * new Vector3(Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0) {
                transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
            } 
        }
         else {
              if (transform.position.x < minX) {
                  position.x = minX + .1f;
              } 
              if (transform.position.x > maxX) {
                  position.x = maxX - .1f;
              }
               if (transform.position.z < minZ) {
                  position.z = minZ + .1f;
              } 
              if (transform.position.z > maxZ) {
                  position.z = maxZ - .1f;
              }

              transform.position = position;
         }
    }

}
