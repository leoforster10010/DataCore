using System.Collections.ObjectModel;

namespace DataCore.Example;

public interface IExampleContextReadOnly
{
	ReadOnlyDictionary<Guid, IExampleEntityReadOnly> ExampleEntitiesReadOnly { get; }
}

public interface IExampleContextValue
{
	ReadOnlyDictionary<Guid, IExampleEntityValue> ExampleEntitiesValue { get; }
}

public class ExampleContext : DataContext<ExampleContext>, IExampleContextReadOnly, IExampleContextValue
{
	public IDictionary<Guid, ExampleEntity> ExampleEntities { get; set; } = new Dictionary<Guid, ExampleEntity>();
	public override IDictionary<Guid, DataEntity<ExampleContext>> DataEntities => ExampleEntities.ToDictionary(key => key.Key, value => value.Value as DataEntity<ExampleContext>);

	public ReadOnlyDictionary<Guid, IExampleEntityReadOnly> ExampleEntitiesReadOnly => ExampleEntities.ToDictionary(key => key.Key, value => value.Value as IExampleEntityReadOnly).AsReadOnly();
	public ReadOnlyDictionary<Guid, IExampleEntityValue> ExampleEntitiesValue => ExampleEntities.ToDictionary(key => key.Key, value => value.Value as IExampleEntityValue).AsReadOnly();
}