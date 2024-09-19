using UnityEngine;
using Tools;

public class Hemoglobin : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private ShakeAnimationSO _shakeAnimationConfig;
 
    private int _indexCurrentPoint = 1;

    private void Start()
    {
        transform.position = _points[0].position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_indexCurrentPoint].position, _speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, _points[_indexCurrentPoint].position) <= 0.5f)
        {
            _indexCurrentPoint++;

            AnimationShortCuts.ShakeRotationAnimation(transform, _shakeAnimationConfig.config);

            if(_indexCurrentPoint == _points.Length)
            {

                _indexCurrentPoint = 0;
                transform.position = _points[0].position;
            }
        }
    }
}