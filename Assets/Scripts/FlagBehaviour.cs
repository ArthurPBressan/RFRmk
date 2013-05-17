using UnityEngine;
using System.Collections;

public class FlagBehaviour : MonoBehaviour {

    public Team team = Team.Brown;

    private bool isBeingCarried;

	// Use this for initialization
	void Start () {
        isBeingCarried = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isBeingCarried)
        {
            this.transform.position = this.transform.parent.position;
        }
	}

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (!this.isBeingCarried)
        {
            VehicleController vc = collisionInfo.gameObject.GetComponent<VehicleController>();

            if (vc != null && vc.canCarryFlag && !vc.team.Equals(this.team))
            {
                //Debug.Log("transform.parent stuff");
                Physics.IgnoreCollision(this.gameObject.collider, collisionInfo.gameObject.collider);
                this.transform.position = collisionInfo.gameObject.transform.position;
                this.transform.parent = collisionInfo.gameObject.transform;
                this.isBeingCarried = true;
            }
        }
    } 
}
