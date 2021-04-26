using GXPEngine; // For GameObject

public class CollisionInfo
{
	public readonly Vec2 normal;
	public readonly Entity other;
	public readonly float timeOfImpact;

	public CollisionInfo(Vec2 _normal, Entity _other, float _timeOfImpact)
	{
		normal = _normal;
		other = _other;
		timeOfImpact = _timeOfImpact;
	}
}
