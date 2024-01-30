using System.Collections.ObjectModel;

namespace DataCore.Example;

public interface IExampleEntityReadOnly
{
	public string NameReadOnly { get; }
	public int AgeReadOnly { get; }
	public DateTime DateTimeReadOnly { get; }
	public IExampleEntityReadOnly ParEntityReadOnly { get; }
	public ReadOnlyCollection<IExampleEntityReadOnly> ExampleEntitiesReadOnly { get; }
}