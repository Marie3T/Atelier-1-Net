public record Key : ICollectable
{
	public bool Use(Door door)
	{
		return door.TryToggleWith(this);
	}
}
