using UnityEngine;

[ExecuteInEditMode]
public class TranslateRotate : MonoBehaviour
{
    private void Update()
    {
        var matrix =
            Matrix4x4.Translate(Vector3.forward * 2f)
            * Matrix4x4.Rotate(Quaternion.AngleAxis(45f, Vector3.up));

        transform.position = matrix.GetPosition();
        transform.rotation = matrix.GetRotation();
    }
}
