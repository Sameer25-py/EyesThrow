using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class DartLauncher : MonoBehaviour
{
    [SerializeField] private Dart  dart;
    [SerializeField] private float dartMoveSpeed = 10f;

    private Dart _activeDart;
    public  bool IsGameStarted = false;

    private bool _isLaunching = false;

    private void Start()
    {
        GameManager.HitEye += OnEyeHit;
        _activeDart        =  Instantiate(dart);
    }

    private void OnEyeHit()
    {
        _isLaunching = false;
        _activeDart  = null;
        _activeDart  = Instantiate(dart);
    }

    public void ResumeLaunch()
    {
        if (_activeDart && _isLaunching)
        {
            _activeDart.Launch();
        }
    }

    public void LaunchDart()
    {
        if (_activeDart)
        {
            _activeDart.Launch();
        }
    }

    public void SpawnDart()
    {
        if (!_activeDart)
        {
            _activeDart = Instantiate(dart);
        }
    }

    public void StopCurrentDart()
    {
        if (_activeDart)
        {
            _activeDart.Stop();
        }
    }

    public void DestroyAllDarts()
    {
        GameObject.FindGameObjectsWithTag("Dart")
            .ToList()
            .ForEach(Destroy);
        _activeDart = null;
    }

    private void Update()
    {
        if (!IsGameStarted) return;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(0))
        {
            _isLaunching = true;
            LaunchDart();
        }
    }
}