# Lab 2 - Add Dependency Injection

## Dependency Injection

1. Change the services of the MVVM application for using an interface (e.g. IBooksService, BooksService)
2. Change view-models to only use interfaces of the services (constructor dependency injection)

## Add a Dependency Injection Container

1. Add NuGet Package Microsoft.Extensions.DependencyInjection
2. Define and call RegisterServices, register service contracts (interfaces) and implementations, create IServiceProvider
3. Change instantiation of view-models in views to use the DI container

## Additional interface with WPF Dependency

1. Define IDialogService and use it from view-model
2. Implement IDialogService within WPF App






