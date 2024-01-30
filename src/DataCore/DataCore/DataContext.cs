namespace DataCore;

public abstract class DataContext<TContext> where TContext : DataContext<TContext>
{
	public Guid Id { get; } = Guid.NewGuid();

	public required DataCore<TContext> Core { get; init; }
	public bool IsActive => Core.ActiveDataContext.Id == Id;

	public abstract IDictionary<Guid, DataEntity<TContext>> DataEntities { get; }
}