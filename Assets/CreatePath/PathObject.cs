using UnityEngine;

public class PathObject : MonoBehaviour
{
    private Rigidbody PathRigidBody;
    private float moveDistance = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StraightTile"))
        {
            transform.position += transform.up * moveDistance;
        }
        else if (other.CompareTag("RightAngleTile"))
        {
            transform.position += transform.right * moveDistance;
        }

        Debug.Log("MOVening");
    }

}
