using UnityEngine;

// From SteamVR.
public static class Extensions
{
    private static float _copysign(float sizeval, float signval)
    {
        return Mathf.Sign(signval) == 1 ? Mathf.Abs(sizeval) : -Mathf.Abs(sizeval);
    }

    public static Quaternion GetRotation(this Matrix4x4 matrix)
    {
        Quaternion q = new Quaternion();
        q.w = Mathf.Sqrt(Mathf.Max(0, 1 + matrix.m00 + matrix.m11 + matrix.m22)) / 2;
        q.x = Mathf.Sqrt(Mathf.Max(0, 1 + matrix.m00 - matrix.m11 - matrix.m22)) / 2;
        q.y = Mathf.Sqrt(Mathf.Max(0, 1 - matrix.m00 + matrix.m11 - matrix.m22)) / 2;
        q.z = Mathf.Sqrt(Mathf.Max(0, 1 - matrix.m00 - matrix.m11 + matrix.m22)) / 2;
        q.x = _copysign(q.x, matrix.m21 - matrix.m12);
        q.y = _copysign(q.y, matrix.m02 - matrix.m20);
        q.z = _copysign(q.z, matrix.m10 - matrix.m01);
        return q;
    }

    public static Vector3 GetPosition(this Matrix4x4 matrix)
    {
        var x = matrix.m03;
        var y = matrix.m13;
        var z = matrix.m23;

        return new Vector3(x, y, z);
    }
}
