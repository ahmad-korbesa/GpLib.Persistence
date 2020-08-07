# General Purpose persistence library

This library adds an extra layer of abstraction to the repository pattern to decouple it from the underlaying concrete storage
in an attempt to seamlessly switch between various storage options when needed without having to break the application layer

# Usage

Create an interface for your domain repository that inherits from IRepository<T>

```csharp
interface IMyDomainSepceficRepo : IRepository<MyModel> {

    void DoSomethingSpecific();
}
```

Next, implement your domain repository inheriting from RepositoryBase from GpLib.Persistence.Repo library
BaseRepository will require a constructor taking IStorage as an external dependency
IStorage<T> will abstract over the concrete infrastructure you'd like to use

```csharp
class MyModelRepository : BaseRepository<MyModel>, IMyDomainSepceficRepo {

    public MyModelRepository(IStorage<MyModel> storage) : base(storage) {

    }

    public void DoSomethingSpecific() {
        //
    }
}
```
For using EntityFramework simply create a DbContext with all the domain mappings preferrably using FluentApi in order not to pollute your model with Attributes

Finally the repository will be built as follows

```csharp
var storage = new EFStorage<MyModel>(new MyDbContext("<your connectionstring>"));
var repo = new MyModelRepository(storage);

var obj1 = repo.Filter( p => ...);
var obj1 = repo.GetAll()
```

Using Microsoft dependency injection framework will help in Injecting the repository when needed if used as follows

```csharp
 private static ServiceProvider ConfigureServices() =>
            new ServiceCollection()
            .AddTransient<DbContext>(builder => new MyDbContext("<your connection string>"))
            .AddTransient<IStorage<MyModel>, EFStorage<MyModel>>()
            .AddTransient<IMyDomainSepceficRepo, MyModelRepository>()
            ///other dependencies
            .BuildServiceProvider();
```

Changing the underlaying storage used by your repository can be simply done by replacing the EFStorage with MongoStorage or your custom implementation of IStorage
