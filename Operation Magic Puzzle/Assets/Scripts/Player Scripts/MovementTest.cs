using System.Collections;
using UnityEngine;
 
public class MovementTest : MonoBehaviour
{

    public Grid grid;
    public GameObject player;
    public float moveSpeed = 5f;

    private Vector3Int _targetCell;
    private Vector3 _targetPosition;

    private bool isMoving = false;

    private void Start()
    {
        // Get initial position of the player on the world grid
        Vector3 initialPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        _targetCell = grid.WorldToCell(initialPosition);

        // Snap the player to the center of the initial cell
        _targetPosition = grid.CellToWorld(_targetCell);
    }

    private void Update()
    {
        
        Vector3Int gridMovement = new Vector3Int();

        if (Input.GetKeyDown(KeyCode.W))
        {
            gridMovement.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gridMovement.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            gridMovement.y += 1;
        } 
        if (Input.GetKeyDown(KeyCode.D))
        {
            gridMovement.y -= 1;
        }

        if (gridMovement != Vector3Int.zero)
        {
            _targetCell += gridMovement;
            _targetPosition = grid.CellToWorld(_targetCell);
        }
        MoveToward(_targetPosition);
    }

    private void MoveToward(Vector3 target)
    {
        isMoving = true;

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        isMoving = false;
    }
}
