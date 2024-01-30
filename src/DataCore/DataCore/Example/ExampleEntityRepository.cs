namespace DataCore.Example;

public class ExampleEntityRepository
{
	private readonly DataCore<ExampleContext> _dataCore;

	public ExampleEntityRepository(DataCore<ExampleContext> dataCore)
	{
		_dataCore = dataCore;
	}

	public void AddExampleEntity(IExampleEntityValue entity)
	{
	}

	public void RemoveExampleEntity(Guid id)
	{
		//Remove
	}

	public ExampleEntity GetExampleEntity(Guid id)
	{
		var dc = _dataCore.ActiveDataContext;

		return dc.ExampleEntities.Values.First();
	}

	public ExampleEntity SyncExampleEntity(IExampleEntityValue exampleEntityValue)
	{
		var dc = _dataCore.ActiveDataContext;

		if (dc.ExampleEntities.TryGetValue(exampleEntityValue.Id, out var exampleEntity))
		{
			return exampleEntity;
		}

		var newExampleEntity = new ExampleEntity
		{
			Name = exampleEntityValue.NameReadOnly,
			Age = exampleEntityValue.AgeReadOnly,
			DateTime = exampleEntityValue.DateTimeReadOnly,
			ParEntity = exampleEntityValue.ParEntityValue,
			Context = null
		};
		dc.ExampleEntities.Add(newExampleEntity.Id, newExampleEntity);

		return newExampleEntity;
	}
}