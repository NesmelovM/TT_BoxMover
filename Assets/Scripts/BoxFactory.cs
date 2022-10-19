using UnityEngine;
using UnityEngine.Pool;

namespace Scritps
{
    public class BoxFactory : MonoBehaviour
    {
        [SerializeField] private int _countOfBox;

        private const string BoxPrefPath = "Prefabs/Box";
        private const string BoxSpawnPointPath = "Prefabs/Components/BoxSpawnPoint";

        public ObjectPool<GameObject> _poolOfBoxies;

        public GameObject _box;
        private GameObject _spawnerPoint;

        private void Awake()
        {
            _poolOfBoxies = new ObjectPool<GameObject>(CreateBox, TakeBox, HideBox);
        }
        private void Start()
        {
            CreateSpawnerPoint(new Vector3(6f, 0, -0f));
            //_poolOfBoxies.Get(out _box);
            DontDestroyOnLoad(this);
        }
        
        public GameObject CreateBox()
        {
            GameObject prefab = Resources.Load<GameObject>(BoxPrefPath);
            GameObject box = Instantiate(prefab, _spawnerPoint.transform.position, Quaternion.identity);
            return box;
        }
        private void HideBox(GameObject obj)
        {
            obj.SetActive(false);
        }

        public void TakeBox(GameObject obj)
        {
            obj.SetActive(true);
        }

        private GameObject CreateSpawnerPoint(Vector3 position)
        {
            GameObject prefab = Resources.Load<GameObject>(BoxSpawnPointPath);
            return _spawnerPoint = Instantiate(prefab, position, Quaternion.identity);
        }
    }
}