using System.Collections.ObjectModel;

namespace DataCore.Example;

public interface IExampleEntityValue
{
	public string NameReadOnly { get; }
	public int AgeReadOnly { get; }
	public DateTime DateTimeReadOnly { get; }
	public Guid ParEntityValue { get; }
	public ReadOnlyCollection<Guid> ExampleEntitiesValue { get; }
}