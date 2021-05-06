using GXPEngine.Core;
using System.Linq;

public static class CollisionManager
{
    /// <summary>
    /// For the given collider, the collisions are being checked and if necessary resolved.
    /// </summary>
    /// <param name="collider">The collider which should be checked and resolved</param>
    public static void HandleCollision(Collider collider)
    {
        Collision _firstCollision = null;
        float _minTOI = float.MaxValue;

        for (int i = 0; i < MyGame.collisionObjects.Count(); i++)
        {
            Collider other = MyGame.collisionObjects[i];
            if (other == collider || collider.owner.ignoreColliders.Contains(other) || other.owner.ignoreColliders.Contains(collider)) break;

            Collision collision = collider.GetCollisionInfo(other);
            if (collision != null && collision.timeOfImpact < _minTOI)
            {
                _firstCollision = collision;
                _minTOI = collision.timeOfImpact;
            }
        }

        if (_firstCollision != null)
        {
            collider.ResolveCollision(_firstCollision);
            collider.owner.OnCollision(_firstCollision);
        }
    }
}
