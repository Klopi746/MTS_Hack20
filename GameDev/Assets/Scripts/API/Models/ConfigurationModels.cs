using System;
using UnityEngine;


[Serializable]
public class ConfigurationOut<Attributes>
{
    public String id;
    public String created_at;
    public String updated_at;
    public Attributes configuration;
}


[Serializable]
public class ConfigurationCreate<Attributes>
{
    public Attributes configuration;

    public ConfigurationCreate(Attributes configuration) {
        this.configuration = configuration;
    }
}


[Serializable]
public class ConfigurationUpdate<Attributes>
{
    public Attributes configuration;

    public ConfigurationUpdate(Attributes configuration)
    {
        this.configuration = configuration;
    }
}


[Serializable]
public class CreateConfigurationResult
{
    public String _id;
}
