using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVector3
{
    public double x;
    public double y;
    public double z;


    public DVector3(Vector3 a)
    {
        x = a.x;
        y = a.y;
        z = a.z;
    }
    public DVector3(double a, double b, double c)
    {
        x = a;
        y = b;
        z = c;
    }
    public double sqrMagnitude
    {
        get { return x * x + y * y + z * z; }
    }

    public Vector3 ToVector3()
    {
        return new Vector3((float)x, (float)y, (float)z);
    }

    public override string ToString()
    {
        return string.Format("({0:0.00000}, {1:0.00000}, {2:0.00000})", x, y, z);
    }
    public DVector3 normalized
    {
        get { return new DVector3(x / System.Math.Sqrt(this.sqrMagnitude), y / System.Math.Sqrt(this.sqrMagnitude), z / System.Math.Sqrt(this.sqrMagnitude)); }
    }

    public static double Dot(DVector3 a, DVector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    public static DVector3 Cross(DVector3 a, DVector3 b)
    {
        return new DVector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
    }

    public static DVector3 operator -(DVector3 a, DVector3 b)
    {
        return new DVector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static DVector3 operator +(DVector3 a, DVector3 b)
    {
        return new DVector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static DVector3 operator *(DVector3 a, double b)
    {
        return new DVector3(a.x * b, a.y * b, a.z * b);
    }

    public static DVector3 operator /(DVector3 a, double b)
    {
        return new DVector3(a.x / b, a.y / b, a.z / b);
    }

}