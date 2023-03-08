using FluentAssertions;
using Newtonsoft.Json;
using System.Reflection;


namespace DeterRandomTests;

public abstract class JsonTests<T>
{
    protected abstract void AfterEveryTest();
    public abstract string FolderName { get; }
    private string SimpleToFromTestFullPath(long preseed) => SimpleToFromTestFullPath((ulong)preseed);
    private string SimpleToFromTestFullPath(ulong preseed) => $"{AssemblyData.SavePath}{FolderName}\\SimpleToFrom{preseed}.json";

    public T StaticCreate(long preseed)
    {
        MethodInfo mi = typeof(T).GetMethod("Create", new Type[] {typeof(long)});//;
        return (T)mi.Invoke(null, new object[] { preseed });
        //do something with items
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(42)]
    [InlineData(100)]
    [InlineData(-100)]
    [InlineData(1000)]
    public void CanSerializeToJson(long preseed)
    {
        var toJson = StaticCreate(preseed);
        string actual = JsonConvert.SerializeObject(toJson);
        //File.WriteAllText(SimpleToFromTestFullPath(preseed), actual); //temporary uncomment to regenerate testcases
        string expected = File.ReadAllText(SimpleToFromTestFullPath(preseed));
        actual.Should().Be(expected);
        AfterEveryTest();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(42)]
    [InlineData(100)]
    [InlineData(-100)]
    [InlineData(1000)]
    public void CanDeserializeFromJson(long preseed)
    {
        var actual = StaticCreate(preseed);
        string expectedAsJson = File.ReadAllText(SimpleToFromTestFullPath(preseed));
        

        T expected = JsonConvert.DeserializeObject<T>(expectedAsJson);

        actual.Should().Be(expected);
        /////////JsonConvert.SerializeObject(actual).Should().Be(expectedAsJson);
        AfterEveryTest();
    }
}
