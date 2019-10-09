using UnityEngine;

namespace Game
{
    public class Land : MonoBehaviour
    {
        public int xSize;
        public int ySize;
        private Vector3[] vertices;
        private Mesh mesh;
        private MeshFilter mFilter;
        private EdgeCollider2D mCollider;

        [SerializeField]
        private Camera cam;
        private Vector2 camSize;


        private void Awake()
        {
            mCollider = GetComponent<EdgeCollider2D>();
            mFilter = GetComponent<MeshFilter>();
            camSize.y = cam.orthographicSize * 2f;
            camSize.x = cam.aspect * camSize.y;

            xSize = Mathf.CeilToInt(camSize.x);
        }

        private void Start()
        {
            Generate();

            //move land to bottom left coner
            float z = transform.localPosition.z;
            float y = -camSize.y / 2f;
            float x = -camSize.x / 2f;
            transform.localPosition = new Vector3(x, y, z);
        }

        private void Generate()
        {
            int Count = (xSize + 1) * (ySize + 1);
            vertices = new Vector3[Count];
            for (int i = 0, y = 0; y <= ySize; y++)
            {
                for (int x = 0; x <= xSize; x++, i++)
                {
                    vertices[i] = new Vector3(x, y * Random.value);
                }
            }
            var points = new Vector2[xSize + 1];
            for (int i = Count; i > points.Length; i--)
            {
                points[Count - i] = vertices[i - 1];
            }
            mCollider.points = points;

            //mCollider.sharedMesh = 
            mFilter.mesh = mesh = new Mesh();
            mesh.name = "Land";
            mesh.vertices = vertices;

            int[] triangles = new int[xSize * 6];
            for (int ti = 0, vi = 0, x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
            mesh.triangles = triangles;
        }
    }
}
