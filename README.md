# CQRS.WPF
A simple example to illustrate how to implement a CQRS and Hexagonal architecture in a WPF client.
The main idea is to clearly separate **presentation logic** (view model logics) and **core domain logic** (real business rules).

## Switch between local and remote calls to the core domain

Furthermore, this project implements in the WPF client, an easy switch :
- **direct calls** to the core domain loaded in memory
- **remote calls** to the core domain through WCF domain hosting

This is done only using IOC configuration :
```csharp
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
#if DEBUG
            Ioc.Instance.Init(new LocalDataAccess.ServiceRegistry(), new DialogService());
#else
            Ioc.Instance.Init(new RemoteDataAccess.ServiceRegistry(), new DialogService());
#endif
            await ((ViewModelLocator) Current.Resources["Locator"]).MainViewModel.Boot();
        }
    }
```

## The project is structured in 3 parts

### WPF Client, MVVM architecture.
The client interface to interact with the domain. You can CRUD customer, and place an order.

- **Client.Wpf.Presentation** : project with all the forms
- **Client.Wpf.Business** : project with the interface logic that is unit tested
- **Client.Wpf.LocalDataAccess** : project that reference the local end point implementation, to allow direct call the core (loaded in memory)
- **Client.Wpf.RemoteDataAccess** : project that reference a remote WCF server, to allow remote call to an hosted core.

### End point, remote or local.
The local or remote endpoint, contains the contracts to interact with the Core domain.
- **EndPoint.Contracts** (portable library) : centralize the communication object and services that are shared.
- **EndPoint** : service implementation that map contract to core domain models.
- **EndPoint.WCF** : WCF service that host routes to communication with core domain logic.

### Core domain, in CQRS pattern and hexagonal architecture.
Where the business logic is centralized.
- The **domain** layer with the business logic. No dependencies.
- The **application** layer with separated commands and queries. Domain dependency.
- The **infrastructure** layer with the implementation details of repository and finders. Application and domain dependencies.
- The **bootstrapper** layer to correctly register all services in the container. Application, Domain, Infrastructure dependencies.
