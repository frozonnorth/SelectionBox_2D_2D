using UnityEngine;

public static class GeometryUtilityExtension
{
    //https://forum.unity.com/threads/managed-version-of-geometryutility-testplanesaabb.473575/
    //A bounding box is outside if all it's 8 corners are on the outside of any of the planes. 
    //A corner is outside of the plane if the (signed) distance to the plane is higher than zero. 
    //This distance can be calculated by taking the dot product between the corner position and the 
    //plane normal and then subtracting the plane distance (to the origin.)
    public enum TestPlanesResults
    {
        /// <summary>
        /// The AABB is completely in the frustrum.
        /// </summary>
        Inside = 0,
        /// <summary>
        /// The AABB is partially in the frustrum.
        /// </summary>
        Intersect,
        /// <summary>
        /// The AABB is completely outside the frustrum.
        /// </summary>
        Outside
    }

    /// <summary>
    /// This is crappy performant, but easiest version of TestPlanesAABBFast to use.
    /// </summary>
    /// <param name="planes"></param>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static TestPlanesResults TestPlanesAABBInternalFast(Plane[] planes, ref Bounds bounds)
    {
        var min = bounds.min;
        var max = bounds.max;

        return TestPlanesAABBInternalFast(planes, ref min, ref max);
    }

    /// <summary>
    /// This is a faster AABB cull than brute force that also gives additional info on intersections.
    /// Calling Bounds.Min/Max is actually quite expensive so as an optimization you can precalculate these.
    /// http://www.lighthouse3d.com/tutorials/view-frustum-culling/geometric-approach-testing-boxes-ii/
    /// </summary>
    /// <param name="planes"></param>
    /// <param name="boundsMin"></param>
    /// <param name="boundsMax"></param>
    /// <returns></returns>
    public static TestPlanesResults TestPlanesAABBInternalFast(Plane[] planes, ref Vector3 boundsMin, ref Vector3 boundsMax, bool testIntersection = false)
    {
        Vector3 vmin, vmax;
        var testResult = TestPlanesResults.Inside;

        for (int planeIndex = 0; planeIndex < planes.Length; planeIndex++)
        {
            var normal = planes[planeIndex].normal;
            var planeDistance = planes[planeIndex].distance;

            // X axis
            if (normal.x < 0)
            {
                vmin.x = boundsMin.x;
                vmax.x = boundsMax.x;
            }
            else
            {
                vmin.x = boundsMax.x;
                vmax.x = boundsMin.x;
            }

            // Y axis
            if (normal.y < 0)
            {
                vmin.y = boundsMin.y;
                vmax.y = boundsMax.y;
            }
            else
            {
                vmin.y = boundsMax.y;
                vmax.y = boundsMin.y;
            }

            // Z axis
            if (normal.z < 0)
            {
                vmin.z = boundsMin.z;
                vmax.z = boundsMax.z;
            }
            else
            {
                vmin.z = boundsMax.z;
                vmax.z = boundsMin.z;
            }

            var dot1 = normal.x * vmin.x + normal.y * vmin.y + normal.z * vmin.z;
            if (dot1 + planeDistance < 0)
                return TestPlanesResults.Outside;

            if (testIntersection)
            {
                var dot2 = normal.x * vmax.x + normal.y * vmax.y + normal.z * vmax.z;
                if (dot2 + planeDistance <= 0)
                    testResult = TestPlanesResults.Intersect;
            }
        }

        return testResult;
    }
}
