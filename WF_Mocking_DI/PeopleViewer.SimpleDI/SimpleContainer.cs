using System;
using System.Collections.Generic;
using System.Configuration;

namespace PeopleViewer
{
    public static class SimpleContainer
    {
        private static Dictionary<Type, object> InstanceCatalog;

        static SimpleContainer()
        {
            InstanceCatalog = new Dictionary<Type, object>();
        } //SimpleContainer

        // manually override configuration file
        public static void MapInstance<T>(object concreteType)
        {           
            Type instanceType = typeof(T);
            if (InstanceCatalog.ContainsKey(instanceType))
                InstanceCatalog.Remove(instanceType);
            InstanceCatalog.Add(instanceType, concreteType);
        } //MapInstance

        public static T Get<T>() where T : class
        {
            // try to get instance from Catalog
            T instance = GetFromInstanceCatalog<T>();
            if (instance == null)
                // try to get from Configuration
                instance = GetFromConfig<T>();
            return instance;
        } //Get

        private static T GetFromInstanceCatalog<T>() where T : class
        {
            object instance;
            InstanceCatalog.TryGetValue(typeof(T), out instance);
            return instance as T;
        } //GetFromInstanceCatalog

        // Works with any type
        private static T GetFromConfig<T>() where T : class
        {
            // look at config file
            string typeName = ConfigurationManager.AppSettings[typeof(T).ToString()];
            if (string.IsNullOrEmpty(typeName))
                return null;

            // get the correct type to instantiate
            Type repoType = Type.GetType(typeName);

            // load up assembly with reflection and create instance
            object repoInstance = Activator.CreateInstance(repoType);
            T repo = repoInstance as T;
            return repo;
        } //GetFromConfig
    }
}
