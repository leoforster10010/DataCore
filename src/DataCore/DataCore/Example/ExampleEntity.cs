using System.Collections.ObjectModel;

namespace DataCore.Example;

public class ExampleEntity : DataEntity<ExampleContext>, IExampleEntityReadOnly, IExampleEntityValue
{
	public required string Name { get; set; }
	public required int Age { get; set; }
	public required DateTime DateTime { get; set; }
	public required ExampleEntity ParEntity { get; set; }
	public IList<ExampleEntity> ExampleEntities { get; set; } = new List<ExampleEntity>();


	//ReadOnly
	public string NameReadOnly => Name;
	public int AgeReadOnly => Age;
	public DateTime DateTimeReadOnly => DateTime;
	public IExampleEntityReadOnly ParEntityReadOnly => ParEntity;
	public ReadOnlyCollection<IExampleEntityReadOnly> ExampleEntitiesReadOnly => ExampleEntities.Select(x => x as IExampleEntityReadOnly).ToList().AsReadOnly();

	//Value
	public Guid ParEntityValue => ParEntity.Id;
	public ReadOnlyCollection<Guid> ExampleEntitiesValue => ExampleEntities.Select(x => x.Id).ToList().AsReadOnly();
}