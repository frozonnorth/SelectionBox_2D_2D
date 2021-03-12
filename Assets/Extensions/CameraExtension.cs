using UnityEngine;

public static class CameraExtensions
{
    /// <summary>
    /// Returns the first raycasthit (collider) from mouse postion
    /// </summary>
    /// <param name="camera">Camera to cast ray from</param>
    /// <param name="mousePosition">Position of user's mouse</param>
    /// <param name="raycastDist">Raycast distance</param>
    /// <returns></returns>
    public static RaycastHit GetFirstHitAtMouse(this Camera camera, Vector3 mousePosition, float raycastDist)
    {
        LayerMask layerMask = ~0;

        return GetFirstHitAtMouse(camera, mousePosition, raycastDist, layerMask);
    }

    /// <summary>
    /// Returns the first raycasthit (collider) from mouse postion
    /// </summary>
    /// <param name="camera">Camera to cast ray from</param>
    /// <param name="mousePosition">Position of user's mouse</param>
    /// <param name="raycastDist">Raycast distance</param>
    /// <param name="layermask">Raycast only specific layers</param>
    /// <returns></returns>
    public static RaycastHit GetFirstHitAtMouse(this Camera camera, Vector3 mousePosition, float raycastDist, int layermask)
    {
        Ray ray = camera.ScreenPointToRay(mousePosition);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, raycastDist, layermask);

        return hit;
    }

    /// <summary>
    /// Returns all raycasthits (colliders) from mouse postion
    /// </summary>
    /// <param name="camera">Camera to cast ray from</param>
    /// <param name="mousePosition">Position of user's mouse</param>
    /// <param name="raycastDist">Raycast distance</param>
    /// <returns></returns>
    public static RaycastHit[] GetHitsAtMouse(this Camera camera, Vector3 mousePosition, float raycastDist)
    {
        LayerMask layerMask = ~0;

        return GetHitsAtMouse(camera, mousePosition, raycastDist, layerMask);
    }

    /// <summary>
    /// Returns all raycasthits (colliders) from mouse postion
    /// </summary>
    /// <param name="camera">Camera to cast ray from</param>
    /// <param name="mousePosition">Position of user's mouse</param>
    /// <param name="raycastDist">Raycast distance</param>
    /// <param name="layermask">Raycast only specific layers</param>
    /// <returns></returns>
    public static RaycastHit[] GetHitsAtMouse(this Camera camera, Vector3 mousePosition, float raycastDist, int layermask)
    {
        Ray ray = camera.ScreenPointToRay(mousePosition);

        return Physics.RaycastAll(ray, raycastDist);
    }
}
