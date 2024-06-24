using UnityEngine;

public class Hemoglobin : MonoBehaviour
{
    [SerializeField] private Transform[] _startedPoints;
    [SerializeField] public float _speed;

    private int _indexCurrentPoint = 0;
    private bool _isRight = false;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _startedPoints[_indexCurrentPoint].position, _speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, _startedPoints[_indexCurrentPoint].position) <= 1f)
        {
            if(_indexCurrentPoint == _startedPoints.Length - 1)
            {
                _isRight = true;
            }
            else if(_indexCurrentPoint == 0)
            {
                _isRight = false;
            }

            if(!_isRight)
            {
                _indexCurrentPoint++;
            }
            else 
            {
                _indexCurrentPoint--;
            }
        }
    }
}