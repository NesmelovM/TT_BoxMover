using UnityEngine;

namespace Scritps
{
    public class BoxFactory : MonoBehaviour
    {
        private const string BoxPrefPath = "Prefabs/Box";
        private const string BoxSpawnPointPath = "Prefabs/Components/BoxSpawnPoint";

        private GameObject[] _box = new GameObject[3];
        private GameObject _spawnerPoint;

        private void Start()
        {
            CreateSpawnerPoint(new Vector3(6f, 0, -0f));

            _box[0] = CreateBox();

            _box[1] = CreateBox();

            _box[2] = CreateBox();
        }
        public GameObject CreateBox()
        {
            GameObject prefab = Resources.Load<GameObject>(BoxPrefPath);
            GameObject box = Instantiate(prefab, _spawnerPoint.transform.position, Quaternion.identity);
            return box;
        }

        private GameObject CreateSpawnerPoint(Vector3 position)
        {
            GameObject prefab = Resources.Load<GameObject>(BoxSpawnPointPath);
            return _spawnerPoint = Instantiate(prefab, position, Quaternion.identity);
        }
    }
}