//using UnityEngine;

//public class GridManager : MonoBehaviour
//{
//    public GameObject DropAreaPrefab;
//    public int gridWidth;
//    public int gridHeight;
//    public float cellSize;
//    public Vector3 startposition;
//    void Start()
//    {
//        GenerateGrid();
//    }
//    private void GenerateGrid()
//    {
//        if (transform.childCount > 0) return;

//        for (int x = 0; x < gridWidth; x++)
//        {
//            for (int y = 0; y < gridHeight; y++)
//            {
//                Vector3 pos = new Vector3
//                    (
//                    this.tranform.x + (x * cellSize),
//                    this.tranform.y + (y * cellSize),
//                    this.tranform.z
//                    );
//                GameObject DropArea = Instantiate(DropAreaPrefab, pos, Quaternion.identity, this.tranform);
//            }
//        }
//        Debug.Log("Grid had been created");
//    }
//}
