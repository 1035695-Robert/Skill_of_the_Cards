using UnityEngine;

public class PathObject : MonoBehaviour
{
    private Rigidbody PathRigidBody;
    private float moveDistance = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("ArrowPlayerCollision"))
        {
            return;
        }

        if (other.CompareTag("UpTile"))
        {
            transform.position += transform.up * moveDistance;
        }
        else if (other.CompareTag("RightTile"))
        {
            transform.position += transform.right * moveDistance;
        }
        else if (other.CompareTag("LeftTile"))
        {
            transform.position -= transform.right * moveDistance;
        }
        else if (other.CompareTag("DownTile"))
        {
            transform.position -= transform.up * moveDistance;
        }

        Debug.Log("The player have moved");
    }

}
