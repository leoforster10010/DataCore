namespace DataCore;

public abstract class DataCore<TContext> where TContext : DataContext<TContext>
{
	public required TContext ActiveDataContext { get; init; }


	public IDictionary<Guid, TContext> DataContexts { get; } = new Dictionary<Guid, TContext>(); //ToDo ConcurrentDict?
}