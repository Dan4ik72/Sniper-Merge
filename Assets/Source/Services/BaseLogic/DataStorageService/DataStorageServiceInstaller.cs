using UnityEngine;
using VContainer;

public class DataStorageServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<DataStorageService>(Lifetime.Singleton);
        builder.Register<IDataToJsonConverter, NewtonsoftJsonConverter>(Lifetime.Singleton);
        builder.Register<IDataSaveHandler, PlayerPrefsSaveHandler>(Lifetime.Singleton);
    }
}
