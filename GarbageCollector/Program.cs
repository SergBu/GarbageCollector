
Console.WriteLine(GC.GetTotalMemory(false));

for (int i = 0; i < 10000000; i++)
{
    //боксим
    var obj = (object)i;
    int j = (int)obj;
}

Console.WriteLine(GC.GetTotalMemory(false));

//когда выходим из зоны видимости юзинга отрабатывает Dispose
using (var c = new MyClass())
{

}

Console.WriteLine(GC.GetTotalMemory(false));

GC.Collect();

Console.WriteLine(GC.GetTotalMemory(false));

Console.ReadLine();

class MyClass : IDisposable
{
    public MyClass() { }

    ~MyClass() { }

    //финализатор
    public void Dispose()
    {
        GC.Collect();
    }


}
