namespace DataCore;

public abstract class DataEntity<TContext> where TContext : DataContext<TContext>
{
	public Guid Id { get; } = Guid.NewGuid();

	public required DataContext<TContext> Context { get; init; }
	public DataCore<TContext> Core => Context.Core;

	//public abstract IDictionary<Guid, DataEntity<TContext>> ReferencedEntities { get; }
	//public IDictionary<Guid, DataEntity<TContext>> ReferencingEntities { get; } = new Dictionary<Guid, DataEntity<TContext>>(); //ToDo ConcurrentDict?
}