public abstract class Tile
{
	public abstract bool IsTraversable { get; }

	public abstract void Pass();
}

public class Wall : Tile
{
	public override bool IsTraversable => false;

	public override void Pass()
	{
		throw new InvalidOperationException("Impossible de traverser un mur.");
	}
}

public class Room : Tile
{
	private ICollectable? collectable;
	public ICollectable? Collectable{
		get { var item = collectable; collectable = null; return item; }
		set { collectable = value ?? null; }
	}
	public override bool IsTraversable => true;

	public override void Pass()
	{
	}
}

public class Door : Tile
{
	private bool isOpen = false;
	private bool istaken = false;
	public Key? key = new Key();
	public Key Key {
		get { if (!istaken){
				 istaken = true; return key;
				}else return null; 
			}
	}

	public override bool IsTraversable => isOpen;

	public override void Pass()
	{
		if (!isOpen)
        {
            throw new InvalidOperationException("La porte est fermée.");
        }
	}

	internal bool TryToggleWith(Key key)
	{
		if (!ReferenceEquals(this.key, key))
		{
			return false;
		}

		isOpen = !isOpen;
		return true;
	}
}
