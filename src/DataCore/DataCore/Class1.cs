namespace DataCore;

public class DataVersion
{
	public required DataEntity Entity { get; init; }
	public required DataVersion PreviousVersion { get; init; }

	public DateTime CreationTime { get; } = DateTime.Now;
	public Guid Id { get; } = Guid.NewGuid();

	public bool IsActive => Entity.ActiveVersion.Id == Id;
}

public class DataEntity
{
	public required DataVersion ActiveVersion { get; init; }

	public Guid Id { get; } = Guid.NewGuid();
	public IDictionary<Guid, DataVersion> DataVersions { get; } = new Dictionary<Guid, DataVersion>(); //ToDo ConcurrentDict?
}

public class DataContext
{
	public required DataCore Core { get; init; }

	public Guid Id { get; } = Guid.NewGuid();
	public IDictionary<Guid, DataEntity> DataEntities { get; } = new Dictionary<Guid, DataEntity>(); //ToDo ConcurrentDict?

	public bool IsActive => Core.ActiveDataContext.Id == Id;
}

public class DataCore
{
	public DataCore()
	{
		ActiveDataContext = new DataContext
		{
			Core = this
		};
	}

	public DataContext ActiveDataContext { get; }
	public IDictionary<Guid, DataContext> DataContexts { get; } = new Dictionary<Guid, DataContext>(); //ToDo ConcurrentDict?
}

public class ExampleEntity
{
	public required string Name { get; set; }
	public required int Age { get; set; }
	public required DateTime DateTime { get; set; }
	public IList<ExampleEntity> ExampleEntities { get; set; } = new List<ExampleEntity>();
	public required ExampleEntity ParEntity { get; set; }
}

public class ExampleEntityRepository
{
	private readonly DataCore _dataCore;

	public ExampleEntityRepository(DataCore dataCore)
	{
		_dataCore = dataCore;
	}

	public void AddExampleEntity(ExampleEntity entity)
	{
	}

	public void RemoveExampleEntity(Guid id)
	{
	}

	public ExampleEntity GetExampleEntity(Guid id)
	{
	}

	public ExampleEntity SyncExampleEntity(ExampleEntity entity)
	{
	}
}