using UnityEngine;

public class Vain : MonoBehaviour
{
    [SerializeField] private float _vertexResolutionRange;
    [SerializeField] private float _timeRange;

    private float _minVertexResolution;
    private float _maxVertexResolution;
    private Material _material;
    private float _currentTime;

    private void OnValidate()
    {
        _material = GetComponent<Renderer>().material;

        _minVertexResolution = _material.GetFloat("Vector1_B2CC132F") - (_vertexResolutionRange / 2);
        _maxVertexResolution = _material.GetFloat("Vector1_B2CC132F") + (_vertexResolutionRange / 2);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        _material.SetFloat("Vector1_B2CC132F", Mathf.Lerp(_minVertexResolution, _maxVertexResolution, _currentTime / _timeRange));

        if(_currentTime >= _timeRange)
        {
            _currentTime = 0;
        }
    }

}
