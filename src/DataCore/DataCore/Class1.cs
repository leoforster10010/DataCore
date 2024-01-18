namespace DataCore;

public class DataVersion
{
	public required DataEntity Entity { get; init; }
	public required DataVersion PreviousVersion { get; init; }

	public DateTime CreationTime { get; } = DateTime.Now;
	public Guid Id { get; } = Guid.NewGuid();
	public IDictionary<Guid, DataVersion> ReferencingVersions { get; } = new Dictionary<Guid, DataVersion>(); //ToDo ConcurrentDict?
	public IDictionary<Guid, DataVersion> ReferencedVersions { get; } = new Dictionary<Guid, DataVersion>(); //ToDo ConcurrentDict?


	public bool IsActive => Entity.ActiveVersion.Id == Id;
	public DataContext Context => Entity.Context;
	public DataCore Core => Entity.Context.Core;
}

public class DataEntity
{
	public required DataVersion ActiveVersion { get; init; }
	public required DataContext Context { get; init; }

	public Guid Id { get; } = Guid.NewGuid();
	public IDictionary<Guid, DataVersion> DataVersions { get; } = new Dictionary<Guid, DataVersion>(); //ToDo ConcurrentDict?
	public IDictionary<Guid, DataEntity> ReferencingEntities => ActiveVersion.ReferencingVersions.ToDictionary(key => key.Value.Entity.Id, value => value.Value.Entity);
	public IDictionary<Guid, DataEntity> ReferencedEntities => ActiveVersion.ReferencedVersions.ToDictionary(key => key.Value.Entity.Id, value => value.Value.Entity);

	public DataCore Core => Context.Core;
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
	public required DataContext ActiveDataContext { get; init; }

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

public class ExampleContext : DataContext
{
	public IDictionary<Guid, ExampleEntity> ExampleEntities { get; set; } = new Dictionary<Guid, ExampleEntity>();
}

public class ExampleDataCore : DataCore
{
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
		var dc = _dataCore.ActiveDataContext;

		return dc.ExampleEntities.Values.First();
	}

	public ExampleEntity SyncExampleEntity(ExampleEntity entity)
	{
		var dc = _dataCore.ActiveDataContext;

		return dc.ExampleEntities.Values.First();
	}
}